
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AutoFac.Extentions.Redis;
using Microsoft.Extensions.Caching.Distributed;
using System.Threading.Tasks;

namespace AutoFac.API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ILogger<TestController> _logger;
        private readonly IRedisRepository _redis;
        private readonly IDistributedCache _cache;

        public TestController(ILogger<TestController> logger ,IRedisRepository redis, IDistributedCache cache)
        {
            _logger = logger;
            _redis = redis;
            _cache = cache;
        }

        [HttpGet(Name ="GetTest")]
        public ActionResult GetTest()
        {
            if (_redis.IsConnected())
                _logger.LogInformation("redis连接成功");
            _logger.LogInformation($"当前redis数据库索引为{_redis.DatabaseIndex().ToString()}");
            return Ok(_redis.DatabaseIndex());
        }
        [HttpGet(Name ="CastId")]
        public ActionResult CastId(int id)
        {
            _logger.LogInformation("正在测试");
            //_logger.LogInformation(_cureent.CurrentStr());
            return Ok(id);
        }
        [HttpGet(Name = "GetRediskey")]
        public async Task<ActionResult> GetRediskey()
        {
            string p = await _cache.GetStringAsync("person");
            if (string.IsNullOrEmpty(p))
                _logger.LogWarning("缓存不存在");
            await _cache.SetStringAsync("person", "ma");
            p = await _cache.GetStringAsync("person");
            return Ok(p);
        }
        [HttpGet(Name = "Rediskey")]
        public async Task<ActionResult> Rediskey()
        {
            string p = await _cache.GetStringAsync("person");
            return Ok(p);
        }

        [HttpGet(Name = "SetRediskey")]
        public async Task<ActionResult> SetRediskey() {
            await _cache.SetStringAsync("pm", "laoma");
            return Ok(await _cache.GetStringAsync("pm"));
        }

        [HttpGet(Name = "SetCahce")]
        public async Task<ActionResult> SetCahce() {
            
            var t= await _cache.GetOrCreateAsync<string>("wen", 
              async (p) => { return await _redis.strGet("person"); }
            ,10,3);
            return Ok(t);
        }

    }
}
