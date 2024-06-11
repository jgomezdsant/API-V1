using Hacker_New_API_V1.Models;

namespace Hacker_New_API_V1.Services.Contract
{
    public interface IHackerNewsService
    {
        Task<IEnumerable<int>> GetBestStoryIdsAsync(int n);
        Task<HackerNewsStoryDetail> GetStoryDetailsByIdAsync(int storyId);

    }
}
