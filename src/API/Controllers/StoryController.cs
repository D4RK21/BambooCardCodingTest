using Application.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("Api/[controller]")]
public class StoryController : ControllerBase
{
    private readonly IStoryService _storyService;

    public StoryController(IStoryService storyService)
    {
        _storyService = storyService;
    }

    [HttpGet("GetBestStories")]
    public async Task<IActionResult> GetBestStoriesAsync(int count)
    {
        if (count <= 0)
        {
            return BadRequest("Count must be more than 0");
        }
        
        var stories = await _storyService.GetBestStoriesAsync(count);
        return Ok(stories);
    }
}
