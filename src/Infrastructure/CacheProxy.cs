using Application.Contracts;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;

namespace Infrastructure;

public class CacheProxy : ICacheProxy
{
    private readonly IMemoryCache _memoryCache;
    private readonly MemoryCacheEntryOptions _defaultCacheOptions;

    public CacheProxy(IConfiguration configuration, IMemoryCache memoryCache)
    {
        _memoryCache = memoryCache;
        _defaultCacheOptions = new MemoryCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow =
                TimeSpan.FromMinutes(configuration.GetValue<int>("Cache:AbsoluteExpirationRelativeToNowInMin")),
            SlidingExpiration = TimeSpan.FromMinutes(configuration.GetValue<int>("Cache:SlidingExpirationInMin"))
        };
    }
    
    public T GetOrSet<T>(string key, Func<T> valueFactory, MemoryCacheEntryOptions? cacheOptions = null)
    {
        if (!_memoryCache.TryGetValue(key, out T value))
        {
            value = valueFactory();
            _memoryCache.Set(key, value, cacheOptions ?? _defaultCacheOptions);
        }

        return value;
    }
}
