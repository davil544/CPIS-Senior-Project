using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CPIS_Senior_Project.DataAccessLayer;
using CPIS_Senior_Project.DataModels;

namespace CPIS_Senior_Project.Management
{
    public partial class LoginRegistration : System.Web.UI.Page
    {
        

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["Login"] = null;
            
            //mgmt_status_message.Text = "SQL Query Output: " + auth.output();
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            UserAuth loginManager = new UserAuth();
            Credentials auth = new Credentials();
            auth.username = mgmt_Username.Text;
            auth.password = mgmt_Password.Text;
            
            //This is hard coded in until the registration form is finished
            //Will eventually be able to choose between Theater & Customer
            auth.role = "Theater";

            //Maybe make this return a status code, if statement to show if it worked or not
            bool registered = loginManager.Registration(auth);

            if (registered) {
                Response.Redirect("yes.aspx");
            }
            else
            {
                mgmt_status_message.Text = "Registration Failed!";
            }
            //Session["Login"] = auth;

            //Maybe change this to try and upload it here, maybe using panes
            //Response.Redirect("yes.aspx");
        }

        /*
            protected void mgmt_Login_Click(object sender, EventArgs e)
        {
            //This code will all be removed and replaced with code that creates users in the db
            //Will have an option to select between customer & theater owner in same form
            
            Credentials login = new Credentials();
            login.username = mgmt_Username.Text; login.password = mgmt_Password.Text;

            //TODO:  Add code to upload credentials to SQL server
            if (login.username.Equals("movie") && login.password.Equals("theater"))
            {
                //login to management portal
                login.confirmed = true;
                Session["Login"] = login;
                Response.Redirect("~/Management/");
            }
            else
            {
                mgmt_status_message.Text = "Username or Password is incorrect, please try again!";
            }
        } */
    }
}