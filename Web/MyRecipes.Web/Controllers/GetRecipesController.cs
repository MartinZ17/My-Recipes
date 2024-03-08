namespace MyRecipes.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using MoiteRecepti.Services;

    public class GetRecipesController : BaseController
    {
        private readonly IGotvachBgScraperService gotvachBgScraperService;

        public GetRecipesController(IGotvachBgScraperService gotvachBgScraperService)
        {
            this.gotvachBgScraperService = gotvachBgScraperService;
        }

        public IActionResult Index()
        {
            return this.View();
        }

    }
}
