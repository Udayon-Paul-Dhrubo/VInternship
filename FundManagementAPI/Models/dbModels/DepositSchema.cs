namespace FundManagementAPI.Models.dbModels
{
    public class DepositSchema
    {
        public int Id { get; set; }
        public required string Schema_Name { get; set; }
        public required double Schema_Rate { get; set; }
        public string? Schema_Description { get; set; }
        public ICollection<DepositAccount>? DepositAccounts { get; set; }

    }
}
