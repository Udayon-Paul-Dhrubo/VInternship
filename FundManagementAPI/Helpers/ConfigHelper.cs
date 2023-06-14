using JWTAuthorization.Models;

namespace JWTAuthorization.Helpers
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
            configData.HMACKey = config["Security:HMACKey"];

            return configData;
        }
    }
}
