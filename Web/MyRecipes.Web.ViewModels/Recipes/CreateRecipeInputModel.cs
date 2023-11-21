namespace MyRecipes.Web.ViewModels.Recipes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using MyRecipes.Data.Models;

    public class CreateRecipeInputModel
    {
        [Required]
        [MinLength(4)]
        public string Name { get; set; }

        [Required]
        [MinLength(100)]
        public string Instructions { get; set; }

        [Range(0, 24 * 60)] // One day
        [Display(Name="Preparation time (in minutes)")]
        public int PreparationTime { get; set; }

        [Range(0, 24 * 60)] // One day
        [Display(Name = "Cooking time (in minutes)")]
        public int CookingTime { get; set; }

        [Required]
        [Range(1, 100)]
        public int PortionCount { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public IEnumerable<RecipeIngredientInputModel> Ingredients { get; set; }

        public IEnumerable<KeyValuePair<string, string>> CategoriesItems { get; set; }
    }
}
