using System;
using System.Web.UI;

namespace CPIS_Senior_Project
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Login"] != null && (bool)Session["login"] == true)
            {
                //Populate Theater Owner Dashboard Here
                loginButton.InnerText = "Logout";
                //Todo:  Add a logout button!
            }
        }
    }
}