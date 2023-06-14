using JWTAuthorization.Models;
using JWTAuthorization.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWTAuthorization.Controllers
{
    /// <summary>
    /// Product Controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        
        /// <summary>
        /// GET: {{fm-base-url}}/api/Product/Get
        /// </summary>
        /// <returns></returns>
        [HttpGet("Get")]        
        public async Task<ActionResult<ProductRsp>> GetProduct()
        {
            ProductServices services = new ProductServices();
            return Ok(services.GetProduct());
        }

        /// <summary>
        /// GET: {{fm-base-url}}/api/Product/Details?ProductCode=111   
        /// </summary>
        /// <param name="ProductCode"></param>
        /// <returns></returns>        
        [HttpGet("Details")]
        public async Task<ActionResult<ProductDetailsRsp>> GetProductDetails(string ProductCode)
        {
            ProductServices services = new ProductServices();
            return Ok(services.GetProductDetails(ProductCode));
        }
        /// <summary>
        /// POST {{fm-base-url}}/api/Product/OpenAccountInit
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        
        [HttpPost("OpenAccountInit")]
        public async Task<ActionResult<NewAccountInitRsp>> CreateNewAccountInit([FromBody] NewAccountInitReq values)
        {
            ProductServices services = new ProductServices();
            return Ok(services.CreateNewAccountInit(values));
        }

        /// <summary>
        /// POST {{fm-base-url}}/api/Product/OpenAccountConfirm
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        
        [HttpPost("OpenAccountConfirm")]
        public async Task<ActionResult<NewAccountConfirmRsp>> CreateNewAccountConfirm([FromBody] NewAccountConfirmReq values)
        {
            ProductServices services = new ProductServices();
            return Ok(services.CreateNewAccountConfirm(values));
        }
        /// <summary>
        /// POST {{fm-base-url}}/api/Product/OpenAccountCancel
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>      
        [HttpPost("OpenAccountCancel")]
        public async Task<ActionResult<NewAccountCancelRsp>> OpenAccountCancel([FromBody] NewAccountConfirmReq values)
        {
            ProductServices services = new ProductServices();
            return Ok(services.OpenAccountCancel(values));
        }


        /// <summary>
        /// GET: {{fm-base-url}}/api/Product/MyAccounts
        /// </summary>
        /// <returns></returns>
        [HttpGet("MyAccounts")]
        public async Task<ActionResult<List<AccountRsp>>> MyAccounts()
        {
            ProductServices services = new ProductServices();
            return Ok(services.MyAccounts());
        }


        /// <summary>
        /// GET: {{fm-base-url}}/api/Product/History
        /// </summary>
        /// <returns></returns>
        [HttpGet("History")]
        public async Task<ActionResult<List<AccountRsp>>> History()
        {
            ProductServices services = new ProductServices();
            return Ok(services.History());
        }
                
        /// <summary>
        /// GET: {{fm-base-url}}/api/Product/PendingAccounts
        /// </summary>
        /// <returns></returns>
        [HttpGet("PendingAccounts")]
        public async Task<ActionResult<List<AccountRsp>>> PendingAccounts()
        {
            ProductServices services = new ProductServices();
            return Ok(services.PendingAccounts());
        }
               
        /// <summary>
        /// POST {{fm-base-url}}/api/Product/Encashment
        /// </summary>
        /// <returns></returns>
        [HttpPost("Encashment")]
        public async Task<ActionResult<ProductRsp>> Encashment()
        {
            ProductServices services = new ProductServices();
            return Ok(services.Encashment());
        }
                
        /// <summary>
        /// POST {{fm-base-url}}/api/Product/EncashmentReq
        /// </summary>
        /// <param name="AccountNumber"></param>
        /// <returns></returns>
        [HttpPost("EncashmentReq")]
        public async Task<ActionResult<ProductRsp>> EncashmentReq([FromBody] string AccountNumber)
        {
            ProductServices services = new ProductServices();
            return Ok(services.EncashmentRequest(AccountNumber));
        }
                
        /// <summary>
        /// POST {{fm-base-url}}/api/Product/Interest
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        [HttpPost("Interest")]
        public async Task<ActionResult<ProductRsp>> InterestWithdraw([FromBody] AccountReq values)
        {
            ProductServices services = new ProductServices();
            return Ok(services.InterestWithdraw(values));
        }
                
        /// <summary>
        /// POST {{fm-base-url}}/api/Product/InterestReq
        /// </summary>
        /// <param name="AccountNumber"></param>
        /// <returns></returns>
        [HttpPost("InterestReq")]
        public async Task<ActionResult<ProductRsp>> InterestWithdrawReq([FromBody] string AccountNumber)
        {
            ProductServices services = new ProductServices();
            return Ok(services.InterestWithdrawRequest(AccountNumber));
        }
    }
}
