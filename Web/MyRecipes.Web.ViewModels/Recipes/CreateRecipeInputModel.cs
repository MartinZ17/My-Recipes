namespace MyRecipes.Web.ViewModels.Recipes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Http;

    public class CreateRecipeInputModel : BaseRecipeInputModel
    {
        public IEnumerable<IFormFile> Images { get; set; }

        public IEnumerable<RecipeIngredientInputModel> Ingredients { get; set; }

        public IEnumerable<KeyValuePair<string, string>> CategoriesItems { get; set; }
    }
}
