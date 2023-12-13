using Microsoft.AspNetCore.Mvc;

namespace MyRecipes.Web.Controllers
{
    public class GetRecipesController : Controller
    {
        public GetRecipesController() { }
        public IActionResult Index()
        {
            
            return View();
        }
    }
}
