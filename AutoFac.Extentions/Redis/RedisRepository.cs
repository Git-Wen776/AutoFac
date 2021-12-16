using Microsoft.Extensions.Logging;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoFac.Extentions.Redis
{
    public class RedisRepository:IRedisRepository
    {
        private readonly IRedisWork _work;
        private readonly IDatabase db;
        private readonly ILogger<RedisRepository> _logger;

        public RedisRepository(IRedisWork work,ILogger<RedisRepository> logger)
        {
            _logger = logger;
            _work = work;
            db = work._redisDb;
        }

        public int DatabaseIndex()
        {
            return db.Database;
        }

        public bool IsConnected()
        {
            return _work.IsConnected();
        }
    }
}
