using System;

namespace CPIS_Senior_Project.Management
{
    public partial class EditMovie : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //TODO:  Add check for login to ensure customers can't edit movie data
            string movieID = Request.QueryString["ID"];
            if (movieID != null)
            {
                debug.Text = "Movie ID: " + movieID;
            }
            else
            {
                debug.Text = "No Movie Found!";
            }
        }
    }
}