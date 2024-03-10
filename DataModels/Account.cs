using System.Security.Permissions;

namespace CPIS_Senior_Project.DataModels
{
    public class Account
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string FullName { get; set; }
        public string status { get; set; }  //Used to check if logged in or to store error messages
        public CreditCard CC { get; set; }  //Will only be used by Customer accounts
        public Theater MyTheater { get; set; }  //Will only be used by Theater accounts
    }
}