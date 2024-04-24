namespace CPIS_Senior_Project.DataModels
{
    public class Ticket
    {
        public int ID { get; set; }
        public string PurchaserUsername { get; set; }
        public int TicketCount { get; set; }
        public int ccID { get; set; }
        //public int MovieID { get; set; }
        //public string TheaterID { get; set; }
        public Movie movie { get; set; }
        public Theater theater { get; set; }

        public Ticket()
        {
            movie = new Movie();
            theater = new Theater();
        }
    }
}