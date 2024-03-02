using System;
using CPIS_Senior_Project.DataAccessLayer;
using CPIS_Senior_Project.DataModels;

namespace CPIS_Senior_Project.Management
{
    public partial class LoginRegistration : System.Web.UI.Page
    {
        

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["Login"] = null;
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            //This creates the object used to connect to the SQL server for authentication
            UserAuth loginManager = new UserAuth();

            //This creates the object that stores the login credentials
            Credentials auth = new Credentials();
            auth.username = mgmt_Username.Text;
            auth.password = mgmt_Password.Text;
            
            //This is hard coded in until the registration form is finished
            //Will eventually be able to choose between Theater & Customer
            auth.role = "Theater";

            String registered = loginManager.Registration(auth);

            if (registered == "success") {
                Session["Registered"] = true;
                Response.Redirect("~/Management/Login");
            }
            else if (registered == "exists")
            {
                mgmt_status_message.Text = "Account Already Exists!";
            }
            else if (registered == "404")
            {
                mgmt_status_message.Text = "SQL Server unavailable, contact DB admin for assistance!";
            }
            else if (registered == "emptyField")
            {
                mgmt_status_message.Text = "Reqired field is empty, try again!";
            }
            else
            {
                mgmt_status_message.Text = "Registration Failed!";
            }
        }
    }
}