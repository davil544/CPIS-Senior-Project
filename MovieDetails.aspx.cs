using CPIS_Senior_Project.DataAccessLayer;
using CPIS_Senior_Project.DataModels;
using System;
using System.Web.UI.WebControls;

namespace CPIS_Senior_Project.Management
{
    public partial class MovieDetails : System.Web.UI.Page
    {
        private string movieID; private Movie mv; private bool customer;
        protected void Page_Load(object sender, EventArgs e)
        {
            movieID = Request.QueryString["ID"];

            if (movieID != null)
            {
                //Load movie from DB here
                TheaterTier movieManager = new TheaterTier();
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
                    lblTicketPrice.Text = mv.Price.ToString();

                    if (!IsPostBack)
                    {
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
                                    lstMovieTheaters.Items.Insert(i, new ListItem(theater[i].ID, theater[i].TicketPrice.ToString()));
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
            //Store session information here such as amount of tickets, movie IDs, etc.
            //Possibly instead of using query strings, may be more secure this way too
            //Pass Movie object, selected theater, and price

            //TODO:  Add login check to purchase button
            Session["PurchasedMovie"] = mv;
            Session["Theater"] = lstMovieTheaters.SelectedItem.Text;
            Session["TicketPrice"] = int.Parse(lstMovieTheaters.SelectedValue) * int.Parse(txtTicketCount.Text);
            Response.Redirect("~/PurchaseTickets.aspx");
        }

        protected void ChooseTheater_Change(object sender, EventArgs e)
        {
            //Checks if theater has been selected here, pulls relevant
            //ticket price and enable the Purchase button when selected
            if (lstMovieTheaters.SelectedValue != "No theater selected")
            {
                lblTicketPrice.Text = int.Parse(lstMovieTheaters.SelectedValue) * int.Parse(txtTicketCount.Text) + "";
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
            {
                lblTicketPrice.Text = int.Parse(lstMovieTheaters.SelectedValue) * float.Parse(txtTicketCount.Text.TrimStart(new Char[] { '0' })) + "";
            }
            catch
            {
                lblTicketPrice.Text = "0 - No Theater Selected!";
            }
        }
    }
}