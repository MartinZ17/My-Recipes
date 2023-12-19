namespace MyRecipes.Web.Controllers
{
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore.Storage;
    using MyRecipes.Services.Data;
    using MyRecipes.Web.ViewModels.Votes;
	using System.Security.Claims;
	using System.Threading.Tasks;

	[ApiController]
    [Route("api/[controller]")]
    public class VotesController : BaseController
    {
        private readonly IVotesService votesService;

        public VotesController(IVotesService votesService)
        {
            this.votesService = votesService;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<PostVoteResponseModel>> Post(PostVoteInputModel input)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value; // getting userId from the cookie
            await this.votesService.SetVoteAsync(input.RecipeId, userId, input.Value);
            var averageVotes = this.votesService.GetAverageVotes(input.RecipeId);
            return new PostVoteResponseModel { AverageVote = averageVotes };
        }
    }
}
