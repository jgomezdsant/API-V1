using Hacker_New_API_V1.Models;
using Hacker_New_API_V1.Services.Contract;

namespace Hacker_New_API_V1.Services.Implementation
{
    public class HackerNewsService : IHackerNewsService
    {
        private readonly HttpClient _httpClient;

        public HackerNewsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<int>> GetBestStoryIdsAsync(int n)
        {
            var response = await _httpClient.GetAsync("https://hacker-news.firebaseio.com/v0/beststories.json");
            response.EnsureSuccessStatusCode();
            var bestStoryIds = await response.Content.ReadAsAsync<IEnumerable<int>>();
            return bestStoryIds.Take(n);
        }

        public async Task<HackerNewsStoryDetail> GetStoryDetailsByIdAsync(int storyId)
        {
            var response = await _httpClient.GetAsync($"https://hacker-news.firebaseio.com/v0/item/{storyId}.json");
            response.EnsureSuccessStatusCode();
            var storyDetails = await response.Content.ReadAsAsync<HackerNewsStory>();

            var detail = new HackerNewsStoryDetail
            {
                Title = storyDetails.Title,
                Url = storyDetails.Url,
                PostedBy = storyDetails.By,
                Time = storyDetails.Time,
                Score = storyDetails.Score,
                commentCount = storyDetails.Descendants
            };

            return detail;
        }
    }
}
