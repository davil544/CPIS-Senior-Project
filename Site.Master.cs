using CPIS_Senior_Project.DataModels;
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
                Account account = (Account)Session["Account"];
                loginButton.Visible = false;
                pnlDropdown.Visible = true;
                if (account.Role == "Theater")
                {
                    LoggedInItems.Text = "<li class=\"nav-item\"><a class=\"nav-link\" runat=\"server\" href=\"/Management\">Movie Management</a></li>";
                }
            }
        }

        protected void BtnSearch_Click (object sender, EventArgs e)
        {
            Session["query"] = txtSearch.Text;
            Response.Redirect("/SearchResults.aspx");
        }
    }
}