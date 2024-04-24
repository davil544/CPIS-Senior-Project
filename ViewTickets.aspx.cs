using CPIS_Senior_Project.DataAccessLayer;
using CPIS_Senior_Project.DataModels;
using System;

namespace CPIS_Senior_Project
{
    public partial class ViewTickets : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Account account = (Account)Session["Account"];
            if (Session["Login"] != null && (bool)Session["Login"] == true && account.Role == "Customer")
            {
                //Populate movie ticket info here
                if (Session["Ticket"] != null)
                {
                    Ticket t = (Ticket)Session["Ticket"];

                    lblCusName.Text = t.PurchaserUsername;
                    lblMovName.Text = t.movie.Title;
                    lblTotal.Text = "$" + Session["TicketPrice"];
                    lblThtrName.Text = t.theater.Name;
                    lblDoP.Text = DateTime.Now.ToString();
                }
                else {
                    debug.Text = "An error has occured! Please try again...";
                }

            }
            else
            {
                debug.Text = ErrorHandler.invalidLoginToken;
                Response.Redirect("~/Management/Login.aspx");
            }
        }
    }
}