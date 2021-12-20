using DependencyInjectionNET6Demo.Services.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace DependencyInjectionNET6Demo.Services;

public class CacheService : ICacheService
{
    private readonly IMemoryCache _cache;

    public CacheService(IMemoryCache cache)
    {
        _cache = cache;
    }

    public void Add(string key, object value)
    {
        _cache.Set(key, value);
    }

    public T Get<T>(string key)
    {
        return _cache.Get<T>(key);
    }
}