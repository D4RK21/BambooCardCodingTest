using Domain.Responses;

namespace Application.Contracts;

public interface IStoryProvider
{
    Task<IEnumerable<int>> GetBestStoriesIds();
    Task<StoryResponse> GetStoryById(int id);
}
