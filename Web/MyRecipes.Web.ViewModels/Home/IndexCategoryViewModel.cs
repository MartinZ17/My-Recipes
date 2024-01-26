namespace MyRecipes.Web.ViewModels.Home
{
    using System.Collections.Generic;

    using MyRecipes.Data.Models;
    using MyRecipes.Services.Mapping;

    public class IndexCategoryViewModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Recipe> Recipes { get; set; }
    }
}
