using System.Reflection.Emit;

namespace FundManagementAPI.Models.dbModels
{
    public class DepositAccount
    {
        public int Id { get; set; }
        public required int Balance { get; set; }
        
        public required Boolean status { get; set; } = true;

        public required Account Account { get; set; }
        public int Account_Id { get; set; }
        public required DepositSchema DepositSchema { get; set; }
        public int DepositSchema_Id { get; set; }
        public required int Block_no { get; set; }
        public required int autoRenewal { get; set; } = 0;
        
        public required int Renew_With_Interest { get; set; } = 0;
        public required DateTime Starting_Date { get; set; } = DateTime.Now;

        public required int Tenure { get; set; }

        public required DateTime Maturity_Date { get; set; }







    }
}
