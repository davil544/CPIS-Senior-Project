using CPIS_Senior_Project.DataModels;
using System;

namespace CPIS_Senior_Project.Management
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Login"] != null && (bool)Session["Login"] == true) {
                Account user = (Account)Session["Account"];
                //Populate Theater Owner Dashboard Here
                if (user.FullName == null || user.FullName.Equals("")) {
                    greeting.Text = "Welcome, Theater Name Here!"; //May not be necessary once user field is marked as required in DB
                }
                else
                {
                    greeting.Text = "Welcome, " + user.FullName + "!";
                }
                
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