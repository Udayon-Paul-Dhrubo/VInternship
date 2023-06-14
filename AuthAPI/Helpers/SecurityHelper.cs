using JWTToken.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using System.Text;

namespace JWTToken.Helpers
{
    public class SecurityHelper
    {
        ConfigData config;
        public SecurityHelper()
        {
            config = ConfigHelper.Config();
        }
        private static byte[] hashHMAC(byte[] key, byte[] message)
        {
            var hash = new HMACSHA256(key);

            return hash.ComputeHash(message);
        }

        internal string GetHash(string message)
        {
            var encoding = new UTF8Encoding();

            var encodedKey = encoding.GetBytes(config.HMACKey);
            var encodedMsg = encoding.GetBytes(message);

            var hmac = new HMACSHA256(encodedKey);
            var hash = hmac.ComputeHash(encodedMsg);
            var hashString = BitConverter.ToString(hash).Replace("-", "").ToLower();

            return hashString;
        }

        public string GenerateJSONWebToken2(string username)
        {
            var issuer = config.JwtIssuer;
            var jwtKey = config.JwtKey;

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
            
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            var claims = new[]
            {
                new System.Security.Claims.Claim("Username", username)
            };

            var token = new JwtSecurityToken(issuer,
              issuer,
              claims,
              expires: DateTime.Now.AddMinutes(20),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
