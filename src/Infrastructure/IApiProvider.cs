﻿using Refit;
using Domain.Responses;

namespace Infrastructure;

public interface IApiProvider
{
    [Get("/beststories.json")]
    Task<IEnumerable<int>> GetBestStoriesIds();

    [Get("/item/{id}.json")]
    Task<StoryResponse> GetStoryById(int id);
}
