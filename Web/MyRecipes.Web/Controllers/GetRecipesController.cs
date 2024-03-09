namespace MyRecipes.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using MoiteRecepti.Services;

    public class GetRecipesController : BaseController
    {
        public GetRecipesController()
        {
        }

        public IActionResult Index()
        {
            return this.View();
        }

    }
}
