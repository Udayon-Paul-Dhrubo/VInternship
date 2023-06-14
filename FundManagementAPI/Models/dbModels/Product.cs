namespace FundManagementAPI.Models.dbModels
{
    public class Product
    {
        public int Id { get; set; }        
        public required string Product_Name { get; set; }
        public string? Product_Description { get; set; } 
        
        public ICollection<Account>? Accounts { get; set; }
        
    }
}
