using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CPIS_Senior_Project.DataModels;

namespace CPIS_Senior_Project.Management
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            portalStatus.Text = null;
            //Credentials login = (Credentials)Session["Login"];

            if (Session["Login"] != null && (bool)Session["login"] == true) {
                //Populate Theater Owner Dashboard Here
                portalStatus.Text = "You have successfully logged in to the theater owner portal!  More features coming soon...";
                //Todo:  Add a logout button!
            }
            else
            {
                portalStatus.Text = "Something went wrong, redirecting back to the login page...";
                Response.Redirect("~/Management/Login.aspx");
            }
        }
    }
}