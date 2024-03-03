using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CPIS_Senior_Project.DataModels
{
    public class CreditCard
    {
        public int CreditCardNumber { get; set; }
        public string ExpirationDate { get; set; }    //TODO:  Convert Expiration date to DateTime before DB connection is complete
        public int CVV { get; set; }
    }
}