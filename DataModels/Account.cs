namespace CPIS_Senior_Project.DataModels
{
    public class Account
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string FullName { get; set; }
        public string status { get; set; }  //Used to check if logged in or to store error messages
        public CreditCard[] CC { get; set; }  //Will only be used by Customer accounts, make this an array for more than 1 card
        public Theater MyTheater { get; set; }  //Will only be used by Theater accounts
    }
}