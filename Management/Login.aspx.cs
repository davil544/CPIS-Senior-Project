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
            this.Form.DefaultButton = mgmt_login.UniqueID;
        }

        protected void mgmt_Login_Click(object sender, EventArgs e)
        {
            //This creates the object that stores the login credentials
            Account auth = new Account();
            auth.Username = mgmt_Username.Text; auth.Password = mgmt_Password.Text;

            auth = AccountManager.Login(auth);

            if (auth.status.Equals("valid"))
            {
                Session["Login"] = true;
                Session["Account"] = auth;
                if (auth.Role.Equals("Theater"))
                {
                    Response.Redirect("~/Management/");
                }
                else if (auth.Role.Equals("Customer"))
                {
                    Response.Redirect("~/");
                }
                else
                {
                    mgmt_status_message.Text = ErrorHandler.acctIssue;
                    Session["Login"] = null; Session["Account"] = null;
                }
            }
            else
            {
                //This will show an error message if authentication fails
                mgmt_status_message.Text = auth.status;
            }
        }
    }
}