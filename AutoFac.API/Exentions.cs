using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace AutoFac.API
{
    public static class Exentions
    {
        static DistributedCacheEntryOptions CreateOptions(int stime,int pow)
        {
            DistributedCacheEntryOptions options = new DistributedCacheEntryOptions();
            TimeSpan sp = TimeSpan.FromSeconds(Random.Shared.RandomDouble(stime*pow, stime));
            options.SetAbsoluteExpiration(sp);
            options.SetSlidingExpiration(TimeSpan.FromSeconds(stime));
            return options;
        }
        public static async Task<TResult> GetOrCreateAsync<TResult>(this IDistributedCache _cache,string key,
            Func<DistributedCacheEntryOptions, Task<TResult>> valuefactory
            ,int ab,int pow)
        {
            string value = await _cache.GetStringAsync(key);
            if (string.IsNullOrEmpty(value))
            {
                var options = CreateOptions(ab,pow);
                TResult? reslut = await valuefactory(options);
                var resultKey = JsonSerializer.Serialize(reslut);
                await _cache.SetStringAsync(key, resultKey, options);
                return JsonSerializer.Deserialize<TResult>(await _cache.GetStringAsync(key));
            }
            _cache.Refresh(key);
            return JsonSerializer.Deserialize<TResult>(value);
        }
    }
}
