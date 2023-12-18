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

    // 1. ApplicationDbContext
    // 2. Repository
    // 3. Service
    public class HomeController : BaseController
    {
        public IGetCountsService CountsService { get; }

        public HomeController(IGetCountsService countsService)
        {
            this.CountsService = countsService;
        }

        public IActionResult Index()
        {
            var countsDto = this.CountsService.GetCounts();

            // var viewModel = this.Mapper.Map<IndexViewModel>(countsDto); //shorter version 
            var viewModel = new IndexViewModel
            {
                CategoriesCount = countsDto.CategoriesCount,
                ImagesCount = countsDto.ImagesCount,
                IngredientsCount = countsDto.IngredientsCount,
                RecipesCount = countsDto.RecipesCount,
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
