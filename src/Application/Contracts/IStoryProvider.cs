using Domain.Responses;

namespace Application.Contracts;

public interface IStoryProvider
{
    Task<IEnumerable<int>> GetBestStoriesIdsAsync();
    Task<StoryResponse> GetStoryByIdAsync(int id);
}
