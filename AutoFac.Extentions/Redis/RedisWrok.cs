using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoFac.Extentions.Redis
{
    public class RedisWrok : IRedisWork
    {
        private readonly Appsetting _app;
        private readonly static object _locker = new object();
        private ConnectionMultiplexer _redis;
        private readonly ILogger<RedisWrok> _logger;
        public IDatabase _redisDb { get {
                return _db;
            } }
        private  IDatabase _db;

        public RedisWrok(Appsetting app,ILogger<RedisWrok> logger)
        {
            _app = app;
            _logger = logger;
            var connect = _app.settingStr(new string[] {"RedisConnect","connectStr" });
            if(string.IsNullOrEmpty(connect))
                throw new ArgumentException(nameof(connect));
            RedisInit(connect);
            _db=_redis.GetDatabase();
        }
        private void RedisInit(string connect)
        {
            if (_redis is not null&& _redis.IsConnected)
                return;
            if(_redis is null)
            {
                lock (_locker)
                {
                    if(_redis is null)
                    {
                        ConfigurationOptions options = new ConfigurationOptions()
                        {
                            DefaultDatabase = 1,
                            AbortOnConnectFail = false,
                            ConnectRetry = 4,
                            ClientName="wen",
                            Password = "123456",
                            ConnectTimeout = 3,
                            EndPoints = { { connect } }
                        };
                        _logger.LogInformation($"redis config is {connect}");
                        _redis=ConnectionMultiplexer.Connect(options);
                        if (!_redis.IsConnected)
                            _logger.LogWarning("redis未连接");
                    }

                }
            }
        }

        public bool IsConnected()
        {
            return _redis.IsConnected;
        }

        public void ChangeDb(int index)
        {
            _db=_redis.GetDatabase(index);
        }
    }

    public static class RedisWordSetup
    {
        public static void AddRediWorkSetup(this IServiceCollection service)
        {
            service.AddScoped<IRedisWork, RedisWrok>();
            service.AddScoped<IRedisRepository,RedisRepository>();
        }
    }
}
