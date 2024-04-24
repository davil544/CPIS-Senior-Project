using CPIS_Senior_Project.DataAccessLayer;
using CPIS_Senior_Project.DataModels;
using System;
using System.Web.UI.WebControls;

namespace CPIS_Senior_Project
{
    public partial class PurchaseTickets : System.Web.UI.Page
    {
        Account account; Ticket t;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Login"] != null && (bool)Session["Login"] == true && Session["Account"] != null && !IsPostBack && Session["Ticket"] != null)
            {
                t = (Ticket)Session["Ticket"];
                account = (Account)Session["Account"];
                if (account.CC.Length != 0)
                {
                    for (int i = 0; i < account.CC.Length; i++)
                    {
                        lstCreditCards.Items.Insert(i, new ListItem(account.CC[i].CardNumber, account.CC[i].CardID.ToString()));
                    }
                }
                CustomerName.Text = "Name: " + account.FullName;
                MovieName.Text = "Movie Name: " + t.movie.Title;
                lblPrice.Text = "Price: $" + Session["TicketPrice"];
                lblTheaterSelection.Text = "Theater Selection:&nbsp" + t.theater.Name; //Add null check here before making next commit
            }
        }



        protected void BtnPurchase_Click(object sender, EventArgs e)
        {
            t = (Ticket)Session["Ticket"];
            if (lstCreditCards.SelectedItem.Text != "No Card Selected")
            {
                t.ccID = int.Parse(lstCreditCards.SelectedValue);
            }
            else
            {
                //Stop process here and tell the user to add a card in the settings
            }
            
            Session["Ticket"] = t;
            TheaterTier manager = new TheaterTier();
            string status = manager.BuyTickets(t);

            if (status == "Success!")
            {
                Response.Redirect("/ViewTickets");
            }
            else
            {
                //display status string to user here
            }
        }


        protected void BtnCancel_Click (object sender, EventArgs e)
        {
            Response.Redirect("~/");
        }
        protected void ListCC_Change (object sender, EventArgs e)
        {
            int ccID = lstCreditCards.SelectedIndex;
        }
    }
}
