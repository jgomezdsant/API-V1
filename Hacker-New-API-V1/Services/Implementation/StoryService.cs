using Hacker_New_API_V1.Models;
using Hacker_New_API_V1.Services.Contract;

namespace Hacker_New_API_V1.Services.Implementation
{
    public class StoryService : IStoryService
    {
        private readonly IHackerNewsService _hackerNewsService;

        public StoryService(IHackerNewsService hackerNewsService)
        {
            _hackerNewsService = hackerNewsService;
        }
        public async Task<IEnumerable<HackerNewsStoryDetail>> GetBestStoriesAsync(int n)
        {
            var bestStoryIds = await _hackerNewsService.GetBestStoryIdsAsync(n);

            var storyTasks = bestStoryIds
                .Select(storyId => _hackerNewsService.GetStoryDetailsByIdAsync(storyId));

            var bestStories = await Task.WhenAll(storyTasks);

            return bestStories
                .Where(story => story != null)
                .OrderByDescending(story => story.Score);
        }

        /**
        public async Task<IEnumerable<HackerNewsStoryDetail>> GetBestStoriesAsync(int n)
        {
            var bestStoryIds = await _hackerNewsService.GetBestStoryIdsAsync(n);
            var bestStories = new List<HackerNewsStoryDetail>();

            foreach (var storyId in bestStoryIds)
            {
                var storyDetails = await _hackerNewsService.GetStoryDetailsByIdAsync(storyId);
                if (storyDetails != null)
                {
                    bestStories.Add(storyDetails);
                }
            }

            return bestStories.OrderByDescending(s => s.Score);
        }

        */

    }
}
