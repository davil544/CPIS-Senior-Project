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
            else if (Session["Login"] != null && (bool)Session["login"] == true)
            {
                mgmt_status_message.Text = "You have successfully been logged out!";
            }
            Session["Login"] = null; Session["Account"] = null;
        }

        protected void mgmt_Login_Click(object sender, EventArgs e)
        {
            //This creates the object used to connect to the SQL server for authentication
            Authentication loginManager = new Authentication();

            //This creates the object that stores the login credentials
            Account auth = new Account();
            auth.Username = mgmt_Username.Text; auth.Password = mgmt_Password.Text;

            string authenticated = loginManager.Login(auth);

            if (authenticated.Equals("true"))
            {
                Session["Login"] = true;
                Session["Account"] = auth;
                Response.Redirect("~/Management/");
            }
            else
            {
                //This will show an error message if authentication fails
                mgmt_status_message.Text = authenticated;
            }
        }
    }
}