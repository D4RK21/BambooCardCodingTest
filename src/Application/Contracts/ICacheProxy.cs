using Microsoft.Extensions.Caching.Memory;

namespace Application.Contracts;

public interface ICacheProxy
{
    T GetOrSet<T>(string key, Func<T> valueFactory, MemoryCacheEntryOptions? cacheOptions = null);
}
