namespace MyRecipes.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using MyRecipes.Web.ViewModels.Recipes;

    public interface IRecipesService
    {
        Task CreateAsync(CreateRecipeInputModel input, string userId, string imagePath);

        IEnumerable<T> GetAll<T>(int page, int itemsPerPage = 12);

        IEnumerable<T> GetRandom<T>(int count);

        int GetCount();

        T GetById<T>(int id);

        IEnumerable<T> GetLatest<T>(int count);

        Task UpdateAsync(int id, EditRecipeInputModel input);

        IEnumerable<T> GetByIngredients<T>(IEnumerable<int> ingredientsIds);

        IEnumerable<T> GetByCategoryId<T>(int categoryId);

        Task DeleteAsync(int id);

    }
}
