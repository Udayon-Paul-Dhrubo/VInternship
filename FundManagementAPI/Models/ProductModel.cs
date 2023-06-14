namespace JWTAuthorization.Models
{
    public class ProductModel
    {
    }

    public class ProductRsp
    {
        public string ProductCode { get; set; }
        public string ProductTitle { get; set; }      

        
    }
    public class ProductDetailsRsp
    {
        public string ProductCode { get; set; }
        public string ProductTitle { get; set; }
        public string Primary_Description { get; set; } = "";
        public List<HeroText> HeroTexts { get; set; } = new List<HeroText>();      
    }
    public class HeroText
    {
        public string? HeroCode { get; set; }
        public string HeroTitle { get; set; }
        public List<HeroText> SubHeros { get; set;}
    }

    public class SubHeroText
    {
        public string SubHeroCode { get; set; }
        public string SubHeroTitle { get; set; }
    }


    public class NewAccountInitReq
    {
        public string? reqref { get; set; }
        public string Amount { get; set; }
        public int Tenure { get; set; }
        public string Rate { get; set; }
        public string SourceAccount { get; set; }
        public string OperatingBranch { get; set; }
        public string AutoRenewal { get; set; }
        public string RenewalWithInterest { get; set; }
    }

    public class NewAccountInitRsp
    {
        public string? regref { get; set; }
        public DateTime MaturityDate { get; set; }
        public int Tenure { get; set; }
        public string SourceAccount { get; set; }
        public string SourceAccountTitle { get; set; }
        public string Amount { get; set; }
        public string Balance { get; set; }
        public string AutoRenewal { get; set; }
        public string RenewalWithInterest { get; set; }
       
    }

    public class NewAccountConfirmReq
    {
        public string reqref { get; set; }
        public string regref { get; set; }
    }
    public class NewAccountConfirmRsp
    {
        public string reqref { get; set; }
        public string regref { get; set; }
        public string NewAccountNumber { get; set; }
        public string NewAccountTitle { get; set; }
        public string SourceAccount { get; set; }
        public string SourceAccountTitle { get; set; }
        public string StartDate { get; set; }
        public string Tenure { get; set; }
        public string Amount { get; set; }
        public string CurrentBalance { get; set; }
        public string AutoRenewal { get; set; }
        public string RenewalWithInterest { get; set; }
        public string OperatingBranch { get; set; }
    }

    public class NewAccountCancelRsp
    {
        public string reqref { get; set; }
        public string regref { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }
        public string SourceAccount { get; set; }
        public string SourceAccountTitle { get; set; }  
        public string Amount { get; set; }
        public string CurrentBalance { get; set; }        
    }



    public class AccountReq
    {
        public string AccountNumber { get; set; }    
    }

    public class AccountRsp
    {
        public string AccountNumber { get; set; }
        public string Amount { get; set; }
        public string Tennure { get; set; }
        public string Branch { get; set; }
        public string MuturityDate { get; set; }
        public string Income { get; internal set; }
        public string TotalAmount { get; internal set; }
    }
}
