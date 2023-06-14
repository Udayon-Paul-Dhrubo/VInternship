using JWTToken.Models;
using JWTToken.Helpers;
using AuthAPI.Services;

namespace JWTToken.Services
{
    public class AuthService : IAuthService
    {
        
        // -------------------------------- insert -------------------------------- .//
        public AuthRsp Insert(AuthReq req)
        {
            AuthRsp response = new AuthRsp();
            SecurityHelper securityHelper = new SecurityHelper();
            DbServices dbServices = new DbServices();

            try
            {               
                var hash = securityHelper.GetHash(req.UserId + req.UserPass);
                
                response = dbServices.Insert(req.UserId, hash);

                return response;

            }
            catch (Exception ex)
            {
                response.Status = "500";
                response.Message = ex.Message + " -- from AuthService.Insert";

                Console.WriteLine(ex);

                return response;
            }
        }


        // -------------------------------- login -------------------------------- .//

        public AuthRsp Auth(AuthReq values)
        {
            AuthRsp response = new AuthRsp();
            SecurityHelper securityHelper = new SecurityHelper();            

            try
            {
                var hash = securityHelper.GetHash(values.UserId + values.UserPass);
                var authData = CheckAuth(values.UserId, hash);

                if (authData.Status == "200")
                {
                    response.AuthType = "Bearer";
                    response.Token = securityHelper.GenerateJSONWebToken2(values.UserId);
                }

                return response;
            } 
            catch (Exception ex)
            {
                response.Status = "500";
                response.Message = ex.Message + " -- from AuthServices.Auth";

                return response;
            }

            
        }

        internal AuthRsp CheckAuth(string username, string hash)
        {
            AuthRsp auth = new AuthRsp();
            DbServices dbServices = new DbServices();

            try
            {
                auth = dbServices.Login(username, hash); 
            }
            catch (Exception ex)
            {
                auth.Status = "500";
                auth.Message = ex.Message + " -- from AuthServices.CheckAuth";
            }

            return auth;
        }

        
    }
}
