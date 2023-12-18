namespace MyRecipes.Web.ViewModels.Recipes
{
    using System;
    using System.Collections.Generic;

    using MyRecipes.Web.ViewModels;

    public class RecipesListViewModel : PagingViewModel
    {
        public IEnumerable<RecipeInListViewModel> Recipes { get; set; }
    }
}
