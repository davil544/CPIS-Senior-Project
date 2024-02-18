using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CPIS_Senior_Project.DataModels;

namespace CPIS_Senior_Project.Management
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["Login"] = null;
        }

        protected void mgmt_Login_Click(object sender, EventArgs e)
        {
            Credentials login = new Credentials();
            login.username = mgmt_Username.Text; login.password = mgmt_Password.Text;

            //This will eventually be tied to the SQL server instead of hard coded in!
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
        }
    }
}