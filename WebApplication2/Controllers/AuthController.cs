using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

using System.Text;

using WebApplication2.Services;

namespace WebApplication2.Controllers
{
    public class JwtSettings
    {
        public string SecretKey { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int AccessTokenExpirationMinutes { get; set; }
    }

    //[ApiKey]
    [ApiController]
    [Route("api/auth")]    
    public class AuthController:ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly JwtSettings _jwtSettings;

        public AuthController(IConfiguration config)
        {
            _config = config;
            _jwtSettings = new JwtSettings();
            _config.GetSection("JwtSettings").Bind(_jwtSettings);
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDto loginDto)
        {
            // Verify user credentials here, e.g. by checking against a database
            // ...




            DatabaseServices db = new DatabaseServices();
            LoginResponseDto logres = new LoginResponseDto();
            logres = db.verifyAndLogin(loginDto);


            if (!logres.status.Equals("200"))
            {
                return Unauthorized(new { logres });
            }

            // If the credentials are valid, generate a JWT token
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.AccessTokenExpirationMinutes),
                signingCredentials: credentials
            );         

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);


            logres.token = tokenString;


            return Ok(new { logres });
        }
        [AllowAnonymous]
        [HttpPost("registration")]
        public IActionResult Register([FromBody] RegisterDto loginDto)
        {
          


            DatabaseServices db = new DatabaseServices();
            RegistrationResponseDto logres = new RegistrationResponseDto();
            logres = db.InsertUser(loginDto);


        

            return Ok(new { logres });
        }
    }
}
public class RegisterDto
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }

}
        public class LoginDto
        {
            public string username { get; set; }
            public string Password { get; set; }
        }
        public class LoginResponseDto
        {
            public string status { get; set; }
            public string message { get; set; }
            public string token { get; set; }

        }public class RegistrationResponseDto
        {
            public string status { get; set; }
            public string message { get; set; }

        }
