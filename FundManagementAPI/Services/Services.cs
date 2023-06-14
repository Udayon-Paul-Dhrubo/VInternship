using FundManagementAPI.Data;
using JWTAuthorization.Models;
using Microsoft.EntityFrameworkCore;

namespace FundManagementAPI.Services
{
    public class Services : IProductServices
    {
        private readonly DataContext _context;
        public Services(DataContext context)
        {
            _context = context;
        }

        private List<HeroText> generateDescriptions(string primary_description)
        {
            List<HeroText> descriptions = new List<HeroText>();


            // format : ##title$$subTitle$$subTitle##title$$subTitle$$subTitle$$subTitle
            if ( primary_description == null || primary_description == "")
            {
               return descriptions;
            }
            

            string[] withTitle = primary_description.Split("##");

            foreach (string str in withTitle)
            {
                string[] withSubTitle = str.Split("$$");

                HeroText _title = new HeroText();

                _title.HeroTitle = withSubTitle[0];

                List<HeroText> _subTitles = new List<HeroText>();

                for (int i = 1; i < withSubTitle.Length; i++)
                {
                    HeroText subTitles = new HeroText();
                    subTitles.HeroTitle = withSubTitle[i];

                    _subTitles.Add(subTitles);
                }

                _title.SubHeros = _subTitles;

                descriptions.Add(_title);
            }

            return descriptions;
        }


        public async Task<List<ProductRsp>> GetProducts()
        {
            
            var products = await _context.Products
                                        .Select(prod => new ProductRsp
                                        {
                                            ProductCode = prod.Id.ToString(),
                                            ProductTitle = prod.Product_Name
                                        })
                                        .ToListAsync();
            return products;
            
            
        }
        public async Task<ProductDetailsRsp> GetProduct(int id)
        {
            var product = await _context.Products
                                    .Where(prod => prod.Id == id)
                                    .Select(prod => new ProductDetailsRsp
                                    {
                                        ProductCode = prod.Id.ToString(),
                                        ProductTitle = prod.Product_Name,
                                        Primary_Description = prod.Product_Description
                                    })
                                    .FirstOrDefaultAsync();     

            
            product.HeroTexts = generateDescriptions(product.Primary_Description);

            return product;
        }


        public NewAccountInitRsp CreateNewAccountInit(NewAccountInitReq req)
        {
            NewAccountInitRsp rsp = new NewAccountInitRsp();

            rsp.Tenure = req.Tenure;
            rsp.MaturityDate = DateTime.Now
                                .AddMonths(Convert.ToInt32(req.Tenure));
            
            rsp.SourceAccount = "3555111122995";
            rsp.SourceAccountTitle = "IFTEKHAR UL ISLAM MONDOL";
            rsp.Amount = "100000";
            rsp.Balance = "154789";
            rsp.RenewalWithInterest = "1";
            rsp.AutoRenewal = "1";
            
            return rsp;
        }



    }
}
