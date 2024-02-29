namespace CPIS_Senior_Project.DataModels
{
    public class Credentials
    {
        //Figure out a more secure way to do this!
        public string username { get; set; }
        public string password { get; set; }
        public string role { get; set; }

        public Credentials()
        {
            
        }
    }
}