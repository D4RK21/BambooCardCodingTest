using Application.Contracts;
using Domain.Entities;

namespace Application;

public class StoryService : IStoryService
{
    private readonly ICacheProxy _cacheProxy;
    private readonly IStoryProvider _storyProvider;

    public StoryService(ICacheProxy cacheProxy, IStoryProvider storyProvider)
    {
        _cacheProxy = cacheProxy;
        _storyProvider = storyProvider;
    }

    public async Task<IEnumerable<Story>> GetBestStoriesAsync(int count)
    {
        var bestStoriesIds =
            await _cacheProxy.GetOrSet("bestStories", async () => await _storyProvider.GetBestStoriesIdsAsync());
        bestStoriesIds = bestStoriesIds.Take(count);
        
        var stories = new List<Story>();
        foreach (var id in bestStoriesIds)
        {
            var story = await _cacheProxy.GetOrSet($"story-{id}",
                async () => await _storyProvider.GetStoryByIdAsync(id));
            stories.Add(new Story
            {
                Title = story.Title,
                Uri = story.Url,
                PostedBy = story.By,
                Time = DateTimeOffset.UnixEpoch.AddSeconds(story.Time),
                Score = story.Score,
                CommentCount = story.Descendants
            });
        }
        
        return stories.OrderByDescending(s => s.Score);
    }
}
