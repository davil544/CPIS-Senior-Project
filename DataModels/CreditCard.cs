﻿using System;

namespace CPIS_Senior_Project.DataModels
{
    public class CreditCard
    {
        public string CardNumber { get; set; }
        public DateTime ExpirationDate { get; set; }    //TODO:  Convert Expiration date to DateTime before DB connection is complete
        public string CVV { get; set; }
    }
}