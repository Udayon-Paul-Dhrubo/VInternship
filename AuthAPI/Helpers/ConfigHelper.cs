using JWTToken.Models;

namespace JWTToken.Helpers
{
    public static class ConfigHelper
    {
        internal static ConfigData Config()
        {
            var config = WebConfig.IConfig;
            ConfigData configData = new ConfigData();
            
            configData.JwtIssuer = config["Jwt:Issuer"];
            configData.JwtAudience = config["Jwt:Audience"];
            configData.JwtKey = config["Jwt:Key"];
            configData.JWTExpiryMinute = Convert.ToInt32(config["Jwt:ExpiryMinute"]);

            configData.HMACKey = config["Security:HMACKey"];


            return configData;
        }
    }
}
