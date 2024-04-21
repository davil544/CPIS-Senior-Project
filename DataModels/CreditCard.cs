namespace CPIS_Senior_Project.DataModels
{
    public class CreditCard
    {
        public int CardID { get; set; }
        public string CardNumber { get; set; }
        public string ExpirationDate { get; set; }    //TODO:  Convert Expiration date to DateTime if feasible
        public string CVV { get; set; }
        public CreditCard()
        {
            CardID = -1;
        }
    }
}