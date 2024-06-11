using Hacker_New_API_V1.Models;

namespace Hacker_New_API_V1.Services.Contract
{
    public interface IStoryService
    {
        Task<IEnumerable<HackerNewsStoryDetail>> GetBestStoriesAsync(int n);
    }
}
