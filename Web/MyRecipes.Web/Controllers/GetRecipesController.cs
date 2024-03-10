namespace MyRecipes.Web.Controllers
{

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
