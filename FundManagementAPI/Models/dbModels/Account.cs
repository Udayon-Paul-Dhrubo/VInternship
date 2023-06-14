namespace FundManagementAPI.Models.dbModels
{
    public class Account
    {
        public int Id { get; set; }
        public int Balance { get; set; }

        public required Branch Branch { get; set; }
        public int Branch_Id { get; set; }

        public required Product Product { get; set; }
        public int Product_Id { get; set; }

        public required Customer Customer{ get; set; }
        public int Customer_Id { get; set; }


        public Linked_Account? Linked_Account { get; set; }
        public int Account_Id { get; set; }

        public ICollection<DepositAccount>? DepositAccounts { get; set; }

        

    }
}
