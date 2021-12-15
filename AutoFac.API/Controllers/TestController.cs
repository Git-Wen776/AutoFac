
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AutoFac.Extentions.Redis;

namespace AutoFac.API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ILogger<TestController> _logger;
        private readonly IRedisRepository _redis;

        public TestController(ILogger<TestController> logger ,IRedisRepository redis)
        {
            _logger = logger;
            _redis = redis;
        }

        [HttpGet(Name ="GetTest")]
        public ActionResult GetTest()
        {
            _logger.LogInformation($"当前redis数据库索引为{_redis.DatabaseIndex()}");
            return Ok();
        }
        [HttpGet(Name ="CastId")]
        public ActionResult CastId(int id)
        {
            _logger.LogInformation("正在测试");
            //_logger.LogInformation(_cureent.CurrentStr());
            return Ok();
        }
    }
}
