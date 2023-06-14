namespace FundManagementAPI.Models.dbModels
{
    public class Branch
    {
        public int Id { get; set; }
        public required string Branch_Name { get; set; }
        public required string Branch_Address { get; set; }

        public ICollection<Account>? Accounts { get; set; }
    }
}
