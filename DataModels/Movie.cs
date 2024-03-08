namespace CPIS_Senior_Project.DataModels
{
    public class Movie
    {
        public int ID {  get; set; }
        public string title { get; set; }
        public string summary { get; set; }
        public string releaseYear { get; set; }
        public string genre { get; set; }
        public string MPA_rating { get; set; }
        public string timeSlot { get; set; } //Move this to Theater class
        public byte[] poster { get; set; }
        public float price { get; set; } //Will also be moved to Theater class
    }
}