using AuthAPI.Services;
using JWTToken.Models;
using JWTToken.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWTToken.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _service;

        public AuthController(IAuthService service)
        {
            _service = service;
        }

        //{{base-url}}/api/Auth/register
        [HttpPost("register")]
        public ActionResult<AuthRsp> Register(AuthReq value)
        {           
            var result = _service.Insert(value);
            return result;             
        }

        //{{base-url}}/api/Auth/login
        [HttpPost("login")]
        public ActionResult<AuthRsp> Login(AuthReq value)
        {
            var result = _service.Auth(value);
            return result;
        }
    }
}
