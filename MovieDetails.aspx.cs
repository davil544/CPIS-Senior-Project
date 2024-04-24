using CPIS_Senior_Project.DataAccessLayer;
using CPIS_Senior_Project.DataModels;
using System;
using System.Web.UI.WebControls;

namespace CPIS_Senior_Project.Management
{
    public partial class MovieDetails : System.Web.UI.Page
    {
        private string movieID; private bool customer; private Theater t; private Movie mv; TheaterTier movieManager = new TheaterTier();
        protected void Page_Load(object sender, EventArgs e)
        {
            movieID = Request.QueryString["ID"];

            if (movieID != null)
            {
                //Load movie from DB here
                Account account = (Account)Session["Account"];
                mv = movieManager.GetMovie(int.Parse(movieID));

                //Shows movie info if it exists in DB
                if (mv.Title != "")
                {
                    pnlMovieInfo.Visible = true;
                    debug.Visible = false;
                    moviePoster.Src = "~/Handlers/MoviePoster.ashx?ID=" + movieID;
                    movieTitle.Text = mv.Title;
                    movieSummary.Text = mv.Summary;

                    if (!IsPostBack)
                    {
                        //lblTicketPrice.Text = mv.Price.ToString();
                        if (Session["Login"] != null && (bool)Session["login"] == true && account.Role == "Theater")
                        {
                            lstMovieTheaters.SelectedItem.Text = "Please note that theater accounts are unable to purchase tickets!";
                            lstMovieTheaters.SelectedItem.Value = account.MyTheater.TicketPrice.ToString();
                            lblTicketPrice.Text = lstMovieTheaters.SelectedItem.Value;
                        }
                        else
                        {
                            Theater[] theater = movieManager.GetTheaters();
                            if (theater.Length != 0)
                            {
                                for (int i = 0; i < theater.Length; i++)
                                {
                                    lstMovieTheaters.Items.Insert(i, new ListItem(theater[i].Name, theater[i].ID));
                                }
                            }
                        }
                    }
                }

                //Shows management tools if logged in as theater employee
                if (Session["Login"] != null && (bool)Session["login"] == true && account.Role == "Theater")
                {
                    customer = false;
                    if (mv.Title != "")
                    {
                        mgmt_Edit.Visible = true;
                    }
                }
                else { 
                    customer = true;
                }
            }
        }

        protected void EditMovie_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Management/EditMovie.aspx?ID=" + movieID);
        }

        protected void BtnPurchase_Click(object sender, EventArgs e)
        {
            //Stores session information here such as amount of tickets, movie IDs, etc.
            //then passes the information to the Purchase Tickets page
            if (Session["Login"] != null && (bool)Session["login"] == true)
            {
                Account account = (Account)Session["Account"];
                Ticket t = new Ticket
                {
                    PurchaserUsername = account.Username,
                    movie = mv,
                    TicketCount = int.Parse(txtTicketCount.Text),
                    theater = movieManager.GetTheater(lstMovieTheaters.SelectedValue)
                };
                //t.TicketCount = int.Parse(lblTicketPrice.Text.ToString());

                //Session["Theater"] = lstMovieTheaters.SelectedItem.Text;
                Session["Ticket"] = t;
                Session["TicketPrice"] = int.Parse(lblTicketPrice.Text);
                Response.Redirect("~/PurchaseTickets.aspx");
            }
            else
            {
                debug.Text = "<div style=\"text-align: center\">You must login before you can purchase movie tickets!</div>";
                debug.Visible = true;
            }

            
        }

        protected void ChooseTheater_Change(object sender, EventArgs e)
        {
            //Checks if theater has been selected here, pulls relevant
            //ticket price and enable the Purchase button when selected
            if (lstMovieTheaters.SelectedValue != "No theater selected")
            {
                t = movieManager.GetTheater(lstMovieTheaters.SelectedValue); //theater[i].TicketPrice.ToString()
                lblTicketPrice.Text = t.TicketPrice * int.Parse(txtTicketCount.Text) + "";
                if (customer)
                {
                    btnPurchase.Enabled = true;
                }
            }
            else
            {
                lblTicketPrice.Text = "0";
                btnPurchase.Enabled = false;
            }
        }

        protected void UpdatePrice_Change(object sender, EventArgs e)
        {
            //Checks for 0s at beginning of ticket quantity (Throws exception if not stripped out),
            //then multiplies it by the ticket price set by theaters and shows it to the customer
            try
            {   //TODO:  Clean this code up!  It's Messy!!!
                t = movieManager.GetTheater(lstMovieTheaters.SelectedValue);
                lblTicketPrice.Text = t.TicketPrice * float.Parse(txtTicketCount.Text.TrimStart(new Char[] { '0' })) + "";
            }
            catch
            {
                lblTicketPrice.Text = "0 - No Theater Selected!";
            }
        }
    }
}