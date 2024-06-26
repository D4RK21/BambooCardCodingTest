﻿using Application.Contracts;
using Domain.Responses;

namespace Infrastructure;

public class StoryProvider : IStoryProvider
{
    private readonly IApiProvider _apiProvider;

    public StoryProvider(IApiProvider apiProvider)
    {
        _apiProvider = apiProvider;
    }

    public async Task<IEnumerable<int>> GetBestStoriesIdsAsync()
    {
        return await _apiProvider.GetBestStoriesIds();
    }

    public async Task<StoryResponse> GetStoryByIdAsync(int id)
    {
        return await _apiProvider.GetStoryById(id);
    }
}
