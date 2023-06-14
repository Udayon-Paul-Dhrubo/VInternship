using JWTToken.Models;

namespace AuthAPI.Services
{
    public interface IAuthService
    {
        AuthRsp Auth(AuthReq req);

        AuthRsp Insert(AuthReq req);

    }
}
