using CPIS_Senior_Project.DataModels;
using System;
using System.Web.UI;

namespace CPIS_Senior_Project
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Account account = (Account)Session["Account"];
            if (Session["Login"] != null && (bool)Session["login"] == true)
            {
                loginButton.InnerText = "Logout";
                if (account.Role == "Theater")
                {
                    LoggedInItems.Text = "<li class=\"nav-item\"><a class=\"nav-link\" runat=\"server\" href=\"/Management\">Movie Management</a></li>";
                }
            }
        }

        protected void BtnSearch_Click (object sender, EventArgs e)
        {
            //TODO:  Implement search function here, allow searching for movies?  Theaters?  Both?
        }
    }
}