using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Pubali_Bank_FundManagement.Database;
using Pubali_Bank_FundManagement.Models;
using System.Diagnostics.CodeAnalysis;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Pubali_Bank_FundManagement.Controllers
{
    
    [ApiController]
    [Route("api/auth")]
    //ANY {base_url}/api/auth
    public class AuthController : ControllerBase
    {
        private static User user = new User();
        private readonly IConfiguration _config;
        public AuthController(IConfiguration config)
        {
            this._config = config;
        } 
        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username)
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_config.GetSection("Jwt:Token").Value!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: creds
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;

        }



        //POST {base_url}/api/auth/register
        [HttpPost("register")]
        public IActionResult Register(Auth_Registration_Req req)
        {
            User newUser = new User();

            newUser.Username = req.Username;
            newUser.Password = BCrypt.Net.BCrypt.HashPassword(req.Username + req.Password);

            AuthService authService = new AuthService();
            Auth_Registration_Res res = authService.InsertUser(newUser);

            return Ok(new { res });
        }


        //POST {base_url}/api/auth/login
        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login(Auth_Login_Req req)
        {
            User user = new User();
            user.Username = req.Username;
            user.Password = req.Password;


            AuthService authService = new AuthService();
            User newuser = authService.VerifyUser(user);

            if( user.Password == "null")
            {
                return BadRequest("fault : Username or password is incorrect");
            }

            Console.WriteLine(newuser.Password);

            if(!BCrypt.Net.BCrypt.Verify(req.Username + req.Password, newuser.Password))
            {
                return BadRequest("Username or password is incorrect");
            }

            string token = CreateToken(user);

            return Ok(token);
           
        }
    }
}
