using CPIS_Senior_Project.DataAccessLayer;
using System;

namespace CPIS_Senior_Project
{
    public partial class TheaterDetails : System.Web.UI.Page
    {
        private string theaterID;
        protected void Page_Load(object sender, EventArgs e)
        {
            theaterID = Request.QueryString["ID"];
            if (theaterID != null)
            {
                //Populate theater information here
            }
            else
            {
                debug.Text = ErrorHandler.noTheater;
                debug.Visible = true;
            }
        }
    }
}