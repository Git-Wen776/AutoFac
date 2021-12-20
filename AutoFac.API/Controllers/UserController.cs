
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoFac.Models;
using AutoFac.Models.ViewModel;

namespace AutoFac.API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;

        public UserController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet(Name ="GetUsers")]
        public ActionResult GetUsers()
        {
            return Ok();
        }

        [HttpGet(Name = "MapperUser")]
        public ActionResult MapperUser()
        {
            User user = new User()
            {
                Age = 18,
                Name="weizhi",
                Phone="17363955980",
                UserId=564565
            };
            UserDto dto=_mapper.Map<User,UserDto>(user);
            return Ok(dto);
        }
    }
}
