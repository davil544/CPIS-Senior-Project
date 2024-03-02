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
                loginButton.InnerText = "Logout";
            }
            //Populate Theater Owner Dashboard Here
        }
    }
}