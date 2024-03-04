namespace CPIS_Senior_Project.DataModels
{
    public class Account
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string FullName { get; set; }
        public CreditCard CC { get; set; }
        public Account() { CC = new CreditCard(); }
    }
}