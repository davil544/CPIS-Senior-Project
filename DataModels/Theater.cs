using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CPIS_Senior_Project.DataModels
{
    public class Theater
    {
        public string name {  get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string postalCode { get; set; }
        public string country { get; set; }
        public string hours { get; set; }
    }
}