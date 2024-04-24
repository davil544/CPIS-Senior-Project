using CPIS_Senior_Project.DataAccessLayer;
using CPIS_Senior_Project.DataModels;
using System;

namespace CPIS_Senior_Project.Management
{
    public partial class OrderHistory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Account user = (Account)Session["Account"];
            if (Session["Login"] != null && (bool)Session["Login"] == true && user.Role == "Customer") {
                TheaterTier theaterManager = new TheaterTier();
                Ticket[] tickets = theaterManager.GetTickets(user.Username);
                if (tickets != null && tickets[0] != null)
                {
                    litTicketOrders.Text = "<table cellpadding = \"10px\">";
                    foreach (Ticket ticket in tickets)
                    {
                        litTicketOrders.Text +=
                            "<tr>" +
                                "<td width=\"50%\">" +
                                    "<table>" + 
                                        "<tr>" +
                                            "<td>Ticket #</td>" +
                                            "<td>" + ticket.ID + "</td>" +
                                        "</tr>" +
                                        "<tr>" +
                                            "<td>Purchaser Name:&nbsp;&nbsp;</td>" +
                                            "<td>" + user.FullName + "</td>" +
                                        "</tr>" +
                                        "<tr>" +
                                            "<td>Theater:</td>" +
                                            "<td>" + theaterManager.GetTheater(ticket.theater.ID).Name + "</td>" +
                                        "</tr>" +
                                        "<tr>" +
                                            "<td>Movie:</td>" +
                                            "<td>" + theaterManager.GetMovie(ticket.movie.ID).Title + "</td>" +
                                        "</tr>" +
                                        "<tr>" +
                                            "<td>Admit Count:</td>" +
                                            "<td>" + ticket.TicketCount + "</td>" +
                                        "</tr>" +
                                    "</table>" +
                                    "<hr class=\"msgBreak\" /><br />" +
                                "</td>" + //Maybe turn bottom border black instead of using dotted hr tag?
                                "<td align=\"right\" width=\"50%\"> Bar code goes here </td>" +
                            "</tr>";

                        //"<a href=\"MovieDetails.aspx?ID=" + movie.ID + "\">" + movie.Title + "</a><br />";
                    }
                    litTicketOrders.Text += "</table>";
                }
                else
                {
                    //handle no tickets here
                    litTicketOrders.Text = "<br />&nbsp;" + ErrorHandler.noOrders;
                }
            }
            else
            {
                //handle no login here
                litTicketOrders.Text = ErrorHandler.invalidLoginToken;
                Response.Redirect("~/Management/Login.aspx");
            }
        }
    }
}