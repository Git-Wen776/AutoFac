
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AutoFac.API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ILogger<TestController> _logger;

        public TestController(ILogger<TestController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name ="GetTest")]
        public ActionResult GetTest()
        {
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
