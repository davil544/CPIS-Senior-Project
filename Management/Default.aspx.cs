using System;

namespace CPIS_Senior_Project.Management
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //greeting.Text = null;

            if (Session["Login"] != null && (bool)Session["login"] == true) {
                //Populate Theater Owner Dashboard Here
                greeting.Text = "Welcome, Theater Name Here!";
                //Create a for loop that populates the movies from the database
                //after page design is complete, store statically until then
            }
            else
            {
                greeting.Text = "Something went wrong, redirecting back to the login page...";
                Response.Redirect("~/Management/Login.aspx");
            }
        }
    }
}