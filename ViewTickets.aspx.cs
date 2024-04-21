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
                if (Session["PurchasedMovie"] != null)
                {
                    Movie mv = (Movie)Session["PurchasedMovie"];

                    lblCusName.Text = "Name: " + account.FullName;
                    lblMovName.Text = "Movie Name: " + mv.Title;
                    lblTotal.Text = "Price: $" + Session["TicketPrice"];
                    lblThtrName.Text = "Theater Selection:&nbsp" + Session["Theater"];
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