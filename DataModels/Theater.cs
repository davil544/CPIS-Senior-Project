using System.Collections.Generic;

namespace CPIS_Senior_Project.DataModels
{
    public class Theater
    {
        public string ID {  get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Hours { get; set; }
        public List<Movie> Movies { get; set; }

        public Theater()
        {
            ID = "";
            Address1 = "";
            Address2 = "";
            City = "";
            State = "";
            PostalCode = "";
            Country = "";
            Hours = "";
        }
    }
}