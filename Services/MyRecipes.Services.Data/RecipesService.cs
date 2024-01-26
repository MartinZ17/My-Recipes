namespace MyRecipes.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using MyRecipes.Data.Common.Repositories;
    using MyRecipes.Data.Models;
    using MyRecipes.Services.Mapping;
    using MyRecipes.Web.ViewModels.Recipes;

    public class RecipesService : IRecipesService
    {
        private readonly IDeletableEntityRepository<Recipe> recipesRepository;
        private readonly IDeletableEntityRepository<Ingredient> ingredientsRepository;

        public RecipesService(
            IDeletableEntityRepository<Recipe> recipesRepository,
            IDeletableEntityRepository<Ingredient> ingredientsRepository)
        {
            this.recipesRepository = recipesRepository;
            this.ingredientsRepository = ingredientsRepository;
        }

        public async Task CreateAsync(CreateRecipeInputModel input, string userId, string imagePath)
        {
            var recipe = new Recipe()
            {
                CategoryId = input.CategoryId,
                CookingTime = TimeSpan.FromMinutes(input.CookingTime),
                Instructions = input.Instructions,
                Name = input.Name,
                PortionCount = input.PortionCount,
                PreparationTime = TimeSpan.FromMinutes(input.PreparationTime),
                AddedByUserId = userId,
            };

            foreach (var inputIngredient in input.Ingredients)
            {
                var ingredient = this.ingredientsRepository.All().FirstOrDefault(x => x.Name == inputIngredient.IngredientName);
                if (ingredient == null)
                {
                    ingredient = new Ingredient { Name = inputIngredient.IngredientName };
                }

                recipe.Ingredients.Add(new RecipeIngredient
                {
                    Ingredient = ingredient,
                    Quantity = inputIngredient.Quantity,
                });
            }

            var allowedExtensions = new[] { "jpg", "png", "gif" };

            foreach (var image in input.Images)
            {
                var extension = Path.GetExtension(image.FileName).TrimStart('.');
                if (!allowedExtensions.Any(x => extension.EndsWith(x)))
                {
                    throw new Exception($"Invalid image extension {extension}!");
                }

                var dbImage = new Image
                {
                    AddedByUserId = userId,
                    Recipe = recipe,
                    Extension = extension,
                };
                recipe.Images.Add(dbImage);

                var physicalPath = $"wwwroot/images/recipes/{dbImage.Id}.{dbImage.Extension}";
                using (Stream fileStream = new FileStream(physicalPath, FileMode.Create))
                {
                    await image.CopyToAsync(fileStream);
                }
            }

            await this.recipesRepository.AddAsync(recipe);
            await this.recipesRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var recipe = this.recipesRepository.All().FirstOrDefault(x => x.Id == id);
            this.recipesRepository.Delete(recipe);
            await this.recipesRepository.SaveChangesAsync();
        }

        public IEnumerable<T> GetAll<T>(int page, int itemsPerPage = 12)
        {
            var recipes = this.recipesRepository.AllAsNoTracking()
                .OrderByDescending(x => x.Id)
                .Skip((page - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .To<T>()
                .ToList();
            return recipes;
        }

        public IEnumerable<T> GetByCategoryId<T>(int categoryId)
        {
            return this.recipesRepository.All()
                .Where(x => x.CategoryId == categoryId)
                .To<T>()
                .ToList();
        }

        public T GetById<T>(int id)
        {
           var recipe = this.recipesRepository.AllAsNoTracking()
                .Where(x => x.Id == id)
                .To<T>().FirstOrDefault();
           return recipe;
        }

        public IEnumerable<T> GetByIngredients<T>(IEnumerable<int> ingredientsIds)
        {
            var query = this.recipesRepository.All().AsQueryable();
            foreach (var ingredientId in ingredientsIds)
            {
                query = query.Where(x => x.Ingredients.Any(i => i.IngredientId == ingredientId));
            }

            return query.To<T>().ToList();
        }

        public int GetCount()
        {
            return this.recipesRepository.All().Count();
        }

        public IEnumerable<T> GetLatest<T>(int count)
        {
            return this.recipesRepository.All().OrderByDescending(x => x.Id)
                .Take(count)
                .To<T>()
                .ToList();
        }

        public IEnumerable<T> GetRandom<T>(int count)
        {
            return this.recipesRepository.All()
                .OrderBy(x => Guid.NewGuid()) // Selecting random recipes
                .Take(count)
                .To<T>().ToList();
        }

        public async Task UpdateAsync(int id, EditRecipeInputModel input)
        {
            var recipes = this.recipesRepository.All().FirstOrDefault(x => x.Id == id);
            recipes.Name = input.Name;
            recipes.Instructions = input.Instructions;
            recipes.CookingTime = TimeSpan.FromMinutes(input.CookingTime);
            recipes.PreparationTime = TimeSpan.FromMinutes(input.PreparationTime);
            recipes.PortionCount = input.PortionCount;
            recipes.CategoryId = input.CategoryId;

            await this.recipesRepository.SaveChangesAsync();
        }
    }
}
