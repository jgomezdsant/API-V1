using Hacker_New_API_V1.Models;
using Hacker_New_API_V1.Services.Contract;
using Microsoft.AspNetCore.Mvc;

namespace Hacker_New_API_V1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BestStoriesController : Controller
    {

        private readonly IStoryService _storyService;

        public BestStoriesController(IStoryService storyService)
        {
            _storyService = storyService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HackerNewsStory>>> GetBestStories(int n)
        {
            var bestStories = await _storyService.GetBestStoriesAsync(n);
            return Ok(bestStories);
        }
    }


}
