namespace CPIS_Senior_Project.DataModels
{
    public class Movie
    {
        public int ID {  get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string ReleaseYear { get; set; }
        public string Genre { get; set; }
        public string MPA_rating { get; set; }
        public string TimeSlot { get; set; } //Move this to Theater class
        public byte[] Poster { get; set; }
        public float Price { get; set; } //Will also be moved to Theater class
    }
}