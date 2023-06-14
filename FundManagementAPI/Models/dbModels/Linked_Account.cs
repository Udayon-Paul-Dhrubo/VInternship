namespace FundManagementAPI.Models.dbModels
{
    public class Linked_Account
    {

        public int System_User_Id { get; set; }       
        public int Account_Id { get; set; }
        public required Account Account { get; set; }
        public required System_User System_User { get; set; }

    }
}
