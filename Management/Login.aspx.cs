using System;
using CPIS_Senior_Project.DataAccessLayer;
using CPIS_Senior_Project.DataModels;

namespace CPIS_Senior_Project.Management
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Registered"] != null && (bool)Session["Registered"])
            {
                mgmt_status_message.Text = "Your account has successfully been created!  Go ahead and try logging in!";
                Session["Registered"] = null;
            }
            Session["Login"] = null;
        }

        protected void mgmt_Login_Click(object sender, EventArgs e)
        {
            //This creates the object used to connect to the SQL server for authentication
            UserAuth loginManager = new UserAuth();

            //This creates the object that stores the login credentials
            Credentials auth = new Credentials();
            auth.username = mgmt_Username.Text; auth.password = mgmt_Password.Text;

            String authenticated = loginManager.Login(auth);

            if (authenticated.Equals("true"))
            {
                Session["Login"] = true;
                Response.Redirect("~/Management/");
            }
            else if (authenticated.Equals("false"))
            {
                mgmt_status_message.Text = "Username or Password is incorrect, please try again!";
            }
            else if (authenticated.Equals("404"))
            {
                mgmt_status_message.Text = "SQL Server unavailable, contact DB admin for assistance!";
            }
            else
            {
                mgmt_status_message.Text = "An unknown error has occured.  Please try again later.";
            }
        }
    }
}