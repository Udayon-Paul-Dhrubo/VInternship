namespace JWTAuthorization.Models
{
    public static class WebConfig
    {
        internal static IConfiguration IConfig { get; set; }
    }

    public class ConfigData
    {
        internal string JwtKey { get; set; }
        internal string JwtIssuer { get; set; }
        internal string JwtAudience { get; set; }
        internal string HMACKey { get; set; }
    }
}
