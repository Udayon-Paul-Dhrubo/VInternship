using JWTAuthorization.Models;

namespace FundManagementAPI.Services
{
    public interface IProductServices
    {
        Task<List<ProductRsp>> GetProducts();
        Task<ProductDetailsRsp> GetProduct(int id);
        
    }
}
