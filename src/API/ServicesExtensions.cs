using Application;
using Application.Contracts;
using Infrastructure;
using Refit;

namespace API;

public static class ServicesExtensions
{
    public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddRefitClient<IApiProvider>()
            .ConfigureHttpClient(c => c.BaseAddress = new Uri(configuration["BaseApiUrl"] ?? string.Empty));
        
        services.AddScoped<IStoryService, StoryService>();
        services.AddScoped<ICacheProxy, CacheProxy>();
        services.AddScoped<IStoryProvider, StoryProvider>();

        return services;
    }
}
