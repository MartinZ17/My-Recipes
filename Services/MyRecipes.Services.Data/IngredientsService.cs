namespace MyRecipes.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using MyRecipes.Data.Common.Repositories;
    using MyRecipes.Data.Models;
    using MyRecipes.Services.Mapping;

    public class IngredientsService : IIngredientsService
    {
        private readonly IDeletableEntityRepository<Ingredient> ingredientsRepository;

        public IngredientsService(IDeletableEntityRepository<Ingredient> ingredientsRepository)
        {
            this.ingredientsRepository = ingredientsRepository;
        }

        public IEnumerable<T> GetAllPopular<T>()
        {
            return this.ingredientsRepository.All()
                .Where(x => x.Recipes.Count() >= 1)
                .OrderByDescending(x => x.Recipes.Count())
                .To<T>().ToList();
        }
    }
}
