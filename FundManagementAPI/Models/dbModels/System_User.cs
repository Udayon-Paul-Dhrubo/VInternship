namespace FundManagementAPI.Models.dbModels
{
    public class System_User
    {
        public int Id { get; set; }
        public required string User_Name { get; set; }
        public required string User_Password { get; set; }
        public ICollection<Linked_Account>? Linked_Accounts { get; set; } 
        
    }
}
