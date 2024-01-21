namespace MyRecipes.Web.ViewModels.SearchRecipes
{
    using System.Collections.Generic;

    using MyRecipes.Web.ViewModels.Recipes;

    public class SearchIndexViewModel
    {
        public IEnumerable<IngredientNameIdViewModel> Ingredients { get; set; }
    }
}
