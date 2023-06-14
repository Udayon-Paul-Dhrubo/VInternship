namespace FundManagementAPI.Models.dbModels
{
    public class Customer
    {
        public int Id { get; set; }
        public required string Customer_Name { get; set; }
        public required DateTime Customer_DOB { get; set; }
        public required string Customer_Phone { get; set; }
        public required ICollection<Account> Accounts { get; set; }

    }
}
