namespace MyRecipes.Web.Controllers
{
    using System.Diagnostics;
    using System.Linq;

    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using MyRecipes.Data;
    using MyRecipes.Data.Common.Repositories;
    using MyRecipes.Data.Models;
    using MyRecipes.Services.Data;
    using MyRecipes.Web.ViewModels;
    using MyRecipes.Web.ViewModels.Home;

    public class HomeController : BaseController
    {
        private readonly IRecipesService recipesService;
        private readonly IGetCountsService countsService;
        private readonly ICategoriesService categoriesService;

        public HomeController(IGetCountsService countsService, IRecipesService recipesService, ICategoriesService categoriesService)
        {
            this.countsService = countsService;
            this.recipesService = recipesService;
            this.categoriesService = categoriesService;
        }

        public IActionResult Index()
        {
            var countsDto = this.countsService.GetCounts();

            // var viewModel = this.Mapper.Map<IndexViewModel>(countsDto); //shorter version
            var viewModel = new IndexViewModel
            {
                CategoriesCount = countsDto.CategoriesCount,
                ImagesCount = countsDto.ImagesCount,
                IngredientsCount = countsDto.IngredientsCount,
                RecipesCount = countsDto.RecipesCount,
                RandomRecipes = this.recipesService.GetRandom<IndexPageRecipeViewModel>(3),
                LatestRecipes = this.recipesService.GetLatest<IndexPageRecipeViewModel>(3),
                PopularCategories = this.categoriesService.GetPopular<IndexCategoryViewModel>(),
                TrendingRecipes = this.recipesService.GetTrending<IndexPageRecipeViewModel>(),
            };
            return this.View(viewModel);
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
