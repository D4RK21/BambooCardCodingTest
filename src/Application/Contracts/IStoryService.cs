using Domain.Entities;

namespace Application.Contracts;

public interface IStoryService
{
    Task<IEnumerable<Story>> GetBestStoriesAsync(int count);
}
