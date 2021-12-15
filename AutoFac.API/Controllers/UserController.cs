
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoFac.API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        

        public UserController()
        {
            
        }

        [HttpGet(Name ="GetUsers")]
        public ActionResult GetUsers()
        {
            return Ok();
        }
    }
}
