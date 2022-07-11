using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoFac.Extentions.Redis
{
    public interface IRedisRepository
    {
        int DatabaseIndex();
        bool IsConnected();
        Task<RedisValue> strGet(string key);


    }
}
