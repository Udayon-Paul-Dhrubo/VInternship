using JWTAuthorization.Models;
using System.Security.Principal;
using System;

namespace JWTAuthorization.Services
{
    public class ProductServices
    {
        ProductRsp product;
        public ProductServices() { }

        public List<ProductRsp> GetProduct()
        {

            List<ProductRsp> products = new List<ProductRsp>();

            //Note: You will fetch the data from the database from package -> Procedure -> Cursor 
            product = new ProductRsp();
            product.ProductCode = "111";
            product.ProductTitle = "Fixed Deposit Receipt";
            product.Status = "1";
            products.Add(product);

            product = new ProductRsp();
            product.ProductCode = "113";
            product.ProductTitle = "Target Based Small Deposit";
            product.Status = "1";
            products.Add(product);


            product = new ProductRsp();
            product.ProductCode = "105";
            product.ProductTitle = "Pubali Pension Scheme (PPS)";
            product.Status = "1";
            products.Add(product);

            return products;
        }

        public ProductDetailsRsp GetProductDetails(string productCode)
        {

            SubHeroText subHeroText;
            List<SubHeroText> subHeros;

            HeroText heroText;
            List<HeroText> heroTexts;

            ProductDetailsRsp rsp;

            //1 Customer Eligibility
            subHeros = new List<SubHeroText>();

            subHeroText = new SubHeroText();
            subHeroText.SubHeroCode = "1";
            subHeroText.SubHeroTitle = "Government Organization";
            subHeros.Add(subHeroText);

            subHeroText = new SubHeroText();
            subHeroText.SubHeroCode = "2";
            subHeroText.SubHeroTitle = "Autonomous and Semi Autonomous Organizations";
            subHeros.Add(subHeroText);

            subHeroText = new SubHeroText();
            subHeroText.SubHeroCode = "5";
            subHeroText.SubHeroTitle = "Non Finance Public Enterprise";
            subHeros.Add(subHeroText);

            subHeroText = new SubHeroText();
            subHeroText.SubHeroCode = "6";
            subHeroText.SubHeroTitle = "Local Authority";
            subHeros.Add(subHeroText);

            subHeroText = new SubHeroText();
            subHeroText.SubHeroCode = "7";
            subHeroText.SubHeroTitle = "Insurance Companies and Pension Funds";
            subHeros.Add(subHeroText);

            subHeroText = new SubHeroText();
            subHeroText.SubHeroCode = "8";
            subHeroText.SubHeroTitle = "Public Non Banking Financial Organizations";
            subHeros.Add(subHeroText);

            subHeroText = new SubHeroText();
            subHeroText.SubHeroCode = "9";
            subHeroText.SubHeroTitle = "Other Financial Public Organizations";
            subHeros.Add(subHeroText);

            subHeroText = new SubHeroText();
            subHeroText.SubHeroCode = "10";
            subHeroText.SubHeroTitle = "Others Bank";
            subHeros.Add(subHeroText);

            subHeroText = new SubHeroText();
            subHeroText.SubHeroCode = "11";
            subHeroText.SubHeroTitle = "Individual and Others";
            subHeros.Add(subHeroText);

            subHeroText = new SubHeroText();
            subHeroText.SubHeroCode = "12";
            subHeroText.SubHeroTitle = "Legal guardian can open term deposit account in the name of minor(s)";
            subHeros.Add(subHeroText);

            //
            heroTexts = new List<HeroText>();
            //
            heroText = new HeroText();
            heroText.HeroCode = "1";
            heroText.HeroTitle = "Customer Eligibility";
            heroText.SubHeros = subHeros;
            heroTexts.Add(heroText);

            //2 Account Opening Procedure
            subHeros = new List<SubHeroText>();

            subHeroText = new SubHeroText();
            subHeroText.SubHeroCode = "1";
            subHeroText.SubHeroTitle = "Prescribed application form";
            subHeros.Add(subHeroText);

            subHeroText = new SubHeroText();
            subHeroText.SubHeroCode = "2";
            subHeroText.SubHeroTitle = "Photograph of Account holder is required";
            subHeros.Add(subHeroText);

            subHeroText = new SubHeroText();
            subHeroText.SubHeroCode = "3";
            subHeroText.SubHeroTitle = "Photograph of the nominee(s) is/are required";
            subHeros.Add(subHeroText);

            subHeroText = new SubHeroText();
            subHeroText.SubHeroCode = "4";
            subHeroText.SubHeroTitle = "Specimen Signature required";
            subHeros.Add(subHeroText);

            heroText = new HeroText();
            heroText.HeroCode = "2";
            heroText.HeroTitle = "Account Opening Procedure";
            heroText.SubHeros = subHeros;
            heroTexts.Add(heroText);

            //3 Introducer
            subHeros = new List<SubHeroText>();

            subHeroText = new SubHeroText();
            subHeroText.SubHeroCode = "1";
            subHeroText.SubHeroTitle = "May not be required";
            subHeros.Add(subHeroText);

            heroText = new HeroText();
            heroText.HeroCode = "3";
            heroText.HeroTitle = "Introducer";
            heroText.SubHeros = subHeros;
            heroTexts.Add(heroText);

            //4 Withdrawal
            subHeros = new List<SubHeroText>();

            subHeroText = new SubHeroText();
            subHeroText.SubHeroCode = "1";
            subHeroText.SubHeroTitle = "Payment on maturity or premature encashment";
            subHeros.Add(subHeroText);

            heroText = new HeroText();
            heroText.HeroCode = "4";
            heroText.HeroTitle = "Withdrawal";
            heroText.SubHeros = subHeros;
            heroTexts.Add(heroText);

            //5 Interest withdrawal
            subHeros = new List<SubHeroText>();

            subHeroText = new SubHeroText();
            subHeroText.SubHeroCode = "1";
            subHeroText.SubHeroTitle = "Option to withdraw the accrued interest retaining the principal amount on or after maturity.";
            subHeros.Add(subHeroText);

            heroText = new HeroText();
            heroText.HeroCode = "5";
            heroText.HeroTitle = "Interest withdrawal";
            heroText.SubHeros = subHeros;
            heroTexts.Add(heroText);

            //6 Premature Encashment
            subHeros = new List<SubHeroText>();

            subHeroText = new SubHeroText();
            subHeroText.SubHeroCode = "1";
            subHeroText.SubHeroTitle = "Before 3 months - No interest and no penalty.";
            subHeros.Add(subHeroText);

            subHeroText = new SubHeroText();
            subHeroText.SubHeroCode = "2";
            subHeroText.SubHeroTitle = "After 3 months - Interest to be paid for 3 months on applicable rate but no interest for remaining days";
            subHeros.Add(subHeroText);

            subHeroText = new SubHeroText();
            subHeroText.SubHeroCode = "4";
            subHeroText.SubHeroTitle = "After 6 months - Interest to be paid for 6 months on applicable rate but no interest for remaining days.";
            subHeros.Add(subHeroText);

            subHeroText = new SubHeroText();
            subHeroText.SubHeroCode = "5";
            subHeroText.SubHeroTitle = "After 12 months - Interest to be paid for 12 months or multiple of 12 months on applicable rate but no interest for remaining days.";
            subHeros.Add(subHeroText);

            heroText = new HeroText();
            heroText.HeroCode = "6";
            heroText.HeroTitle = "Premature Encashment";
            heroText.SubHeros = subHeros;
            heroTexts.Add(heroText);

            //7 Renewal Procedure
            subHeros = new List<SubHeroText>();

            subHeroText = new SubHeroText();
            subHeroText.SubHeroCode = "1";
            subHeroText.SubHeroTitle = "Renewal is allowed on maturity if desired by the depositor.";
            subHeros.Add(subHeroText);

            subHeroText = new SubHeroText();
            subHeroText.SubHeroCode = "2";
            subHeroText.SubHeroTitle = "Instruction from the customer to be obtained at the time of issuing of FDR whether to be renewed for the same period at the prevailing rate";
            subHeros.Add(subHeroText);

            subHeroText = new SubHeroText();
            subHeroText.SubHeroCode = "3";
            subHeroText.SubHeroTitle = "No renewal is allowed after the death of the depositor.";
            subHeros.Add(subHeroText);

            heroText = new HeroText();
            heroText.HeroCode = "7";
            heroText.HeroTitle = "Renewal Procedure";
            heroText.SubHeros = subHeros;
            heroTexts.Add(heroText);

            //8 Auto Renewal
            subHeros = new List<SubHeroText>();

            subHeroText = new SubHeroText();
            subHeroText.SubHeroCode = "1";
            subHeroText.SubHeroTitle = "In absence of any instruction from the depositor, the FDR shall be treated renewed 1(one) time only for 3 (three) months term automatically at the prevailing rate";
            subHeros.Add(subHeroText);

            heroText = new HeroText();
            heroText.HeroCode = "8";
            heroText.HeroTitle = "Auto Renewal";
            heroText.SubHeros = subHeros;
            heroTexts.Add(heroText);

            //9 Overdue FDR
            subHeros = new List<SubHeroText>();

            subHeroText = new SubHeroText();
            subHeroText.SubHeroCode = "1";
            subHeroText.SubHeroTitle = "If not renewed the entire balance will be treated as Overdue Fixed Deposit.";
            subHeros.Add(subHeroText);

            subHeroText = new SubHeroText();
            subHeroText.SubHeroCode = "2";
            subHeroText.SubHeroTitle = "Interest ceases to accrue on overdue FDR.";
            subHeros.Add(subHeroText);

            heroText = new HeroText();
            heroText.HeroCode = "9";
            heroText.HeroTitle = "Overdue FDR";
            heroText.SubHeros = subHeros;
            heroTexts.Add(heroText);


            //10 Interest Rate
            subHeros = new List<SubHeroText>();

            subHeroText = new SubHeroText();
            subHeroText.SubHeroCode = "1";
            subHeroText.SubHeroTitle = "Period wise interest rate is different";
            subHeros.Add(subHeroText);

            subHeroText = new SubHeroText();
            subHeroText.SubHeroCode = "2";
            subHeroText.SubHeroTitle = "Interest rate changes time to time.";
            subHeros.Add(subHeroText);

            subHeroText = new SubHeroText();
            subHeroText.SubHeroCode = "3";
            subHeroText.SubHeroTitle = "Account wise separate interest rate is allowed";
            subHeros.Add(subHeroText);

            subHeroText = new SubHeroText();
            subHeroText.SubHeroCode = "4";
            subHeroText.SubHeroTitle = "Source Tax (if has TIN 10% or without TIN 15%) on interest";
            subHeros.Add(subHeroText);

            subHeroText = new SubHeroText();
            subHeroText.SubHeroCode = "5";
            subHeroText.SubHeroTitle = "Excise duty applicable";
            subHeros.Add(subHeroText);

            heroText = new HeroText();
            heroText.HeroCode = "10";
            heroText.HeroTitle = "Interest Rate";
            heroText.SubHeros = subHeros;
            heroTexts.Add(heroText);

            rsp = new ProductDetailsRsp();
            rsp.ProductCode = "111";
            rsp.ProductTitle = "Fixed Deposit Receipt";
            rsp.HeroTexts = heroTexts;


            return rsp;
        }

        public NewAccountInitRsp CreateNewAccountInit(NewAccountInitReq values)
        {
            NewAccountInitRsp rsp = new NewAccountInitRsp();

            //Data should be fetched from database
            rsp.MaturityDate = "10-OCT-2024";
            rsp.Tenure = "6 Months";
            rsp.SourceAccount = "3555111122995";
            rsp.SourceAccountTitle = "IFTEKHAR UL ISLAM MONDOL";
            rsp.Amount = "100000";
            rsp.Balance = "154789";
            rsp.RenewalWithInterest = "1";
            rsp.AutoRenewal = "1";
            rsp.OperatingBranch = "1";
            return rsp;
        }


        public NewAccountConfirmRsp CreateNewAccountConfirm(NewAccountConfirmReq values)
        {
            NewAccountConfirmRsp rsp = new NewAccountConfirmRsp();

            //Data should be fetched from database
            rsp.reqref = "user req ref";
            rsp.regref = "uniqueid from register DB";
            rsp.NewAccountNumber = "3555111000001";
            rsp.NewAccountTitle = "IFTEKHAR UL ISLAM";
            rsp.SourceAccount = "3555101000001";
            rsp.SourceAccountTitle = "IFTEKHAR UL ISLAM";
            rsp.StartDate = "07-Jun-2023";
            rsp.Tenure = "6 Months";
            rsp.Amount = "100000";
            rsp.CurrentBalance = "2501452.00";
            rsp.AutoRenewal = "1";
            rsp.RenewalWithInterest = "1";
            rsp.OperatingBranch = "Principal Branch";
            return rsp;
        }
        public NewAccountCancelRsp OpenAccountCancel(NewAccountConfirmReq values)
        {
            NewAccountCancelRsp rsp = new NewAccountCancelRsp();

            rsp.reqref = "user req ref";
            rsp.regref = "uniqueid from register DB";
            rsp.Status = "200";
            rsp.Message = "Canceled";
            rsp.SourceAccount = "3555101000001";
            rsp.SourceAccountTitle = "IFTEKHAR UL ISLAM";
            rsp.Amount = "100000";
            rsp.CurrentBalance = "2501452.00";

            return rsp;
        }

       
        public List<AccountRsp> MyAccounts()
        {
            List<AccountRsp> rsps = new List<AccountRsp>();
            AccountRsp rsp = new AccountRsp();

            rsp.AccountNumber = "3555111000001";
            rsp.Amount = "100000";
            rsp.Tennure = "6 Months";
            rsp.Branch = "Principal Branch";
            rsp.MuturityDate = "07-Dec-2023";
            rsps.Add(rsp);
                
            rsp = new AccountRsp();
            rsp.AccountNumber = "3555113000001";
            rsp.Amount = "50000";
            rsp.Tennure = "N/a";
            rsp.Branch = "Principal Branch";
            rsp.MuturityDate = "N/A";
            rsps.Add(rsp);

            return rsps;
        }
        public List<AccountRsp> History()
        {
            List<AccountRsp> rsps = new List<AccountRsp>();
            AccountRsp rsp = new AccountRsp();

            rsp.AccountNumber = "3555111000001";
            rsp.Amount = "100000";
            rsp.Tennure = "6 Months";
            rsp.Branch = "Principal Branch";
            rsp.MuturityDate = "07-Dec-2023";
            rsps.Add(rsp);

            rsp = new AccountRsp();
            rsp.AccountNumber = "3555113000001";
            rsp.Amount = "50000";
            rsp.Tennure = "N/a";
            rsp.Branch = "Principal Branch";
            rsp.MuturityDate = "N/A";
            rsps.Add(rsp);

            return rsps;
        }
        public List<AccountRsp> PendingAccounts()
        {
            List<AccountRsp> rsps = new List<AccountRsp>();
            AccountRsp rsp = new AccountRsp();

            rsp.AccountNumber = "3555111000001";
            rsp.Amount = "100000";
            rsp.Tennure = "6 Months";
            rsp.Branch = "Principal Branch";
            rsp.MuturityDate = "07-Dec-2023";
            rsps.Add(rsp);

            rsp = new AccountRsp();
            rsp.AccountNumber = "3555113000001";
            rsp.Amount = "50000";
            rsp.Tennure = "N/a";
            rsp.Branch = "Principal Branch";
            rsp.MuturityDate = "N/A";
            rsps.Add(rsp);

            return rsps;
        }
        public List<AccountRsp> Encashment()
        {
            List<AccountRsp> rsps = new List<AccountRsp>();
            AccountRsp rsp = new AccountRsp();

            rsp.AccountNumber = "3555111000001";
            rsp.Amount = "100000";
            rsp.Tennure = "6 Months";
            rsp.Branch = "Principal Branch";
            rsp.MuturityDate = "07-Dec-2023";
            rsps.Add(rsp);

            rsp = new AccountRsp();
            rsp.AccountNumber = "3555113000001";
            rsp.Amount = "50000";
            rsp.Tennure = "N/a";
            rsp.Branch = "Principal Branch";
            rsp.MuturityDate = "N/A";
            rsps.Add(rsp);

            return rsps;
        }
        public List<AccountRsp> InterestWithdraw(AccountReq values)
        {
            List<AccountRsp> rsps = new List<AccountRsp>();
            AccountRsp rsp = new AccountRsp();

            rsp.AccountNumber = "3555111000001";
            rsp.Amount = "100000";
            rsp.Tennure = "6 Months";
            rsp.Branch = "Principal Branch";
            rsp.MuturityDate = "07-Dec-2023";
            rsps.Add(rsp);

            rsp = new AccountRsp();
            rsp.AccountNumber = "3555113000001";
            rsp.Amount = "50000";
            rsp.Tennure = "N/a";
            rsp.Branch = "Principal Branch";
            rsp.MuturityDate = "N/A";
            rsps.Add(rsp);

            return rsps;
        }
        
        public AccountRsp EncashmentRequest(string accountNumber)
        {
            
            AccountRsp rsp = new AccountRsp();

            rsp.AccountNumber = "3555111000001";
            rsp.Amount = "100000";
            rsp.Tennure = "6 Months";
            rsp.Branch = "Principal Branch";
            rsp.MuturityDate = "07-Dec-2023";       
            rsp.Income = "10000";
            rsp.TotalAmount = "110000";
           

            return rsp;
        }         
       
        public AccountRsp InterestWithdrawRequest(string accountNumber)
        {
            
            AccountRsp rsp = new AccountRsp();

            rsp.AccountNumber = "3555111000001";
            rsp.Amount = "100000";
            rsp.Tennure = "6 Months";
            rsp.Branch = "Principal Branch";
            rsp.MuturityDate = "07-Dec-2023";       
            rsp.Income = "10000";
            rsp.TotalAmount = "110000";
           

            return rsp;
        }         
      
    }
}
