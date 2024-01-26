namespace MyRecipes.Web.ViewModels.Home
{
    using System.Collections.Generic;

    public class IndexViewModel
    {
        public IEnumerable<IndexPageRecipeViewModel> RandomRecipes { get; set; }

        public IEnumerable<IndexPageRecipeViewModel> LatestRecipes { get; set; }

        public IndexPageRecipeViewModel[] TrendingRecipes { get; set; }

        public IEnumerable<IndexCategoryViewModel> PopularCategories { get; set; }

        public int RecipesCount { get; set; }

        public int CategoriesCount { get; set; }

        public int IngredientsCount { get; set; }

        public int ImagesCount { get; set; }
    }
}
