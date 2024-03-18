using System;

namespace CPIS_Senior_Project.Management
{
    public partial class MovieDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string movieID = Request.QueryString["ID"];
            testing.Text = "Movie ID: " + movieID;
        }
    }
}