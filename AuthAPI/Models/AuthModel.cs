namespace JWTToken.Models
{
    public class AuthRsp
    {
        public string Status { get; set; }
        public string Message { get; set; }

        public string? AuthType { get; set; }

        public string? Token { get; set; }
    }

    public class AuthReq
    {
        public string UserId { get; set; }
        public string UserPass { get; set; }
    }

}
