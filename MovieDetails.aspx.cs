using CPIS_Senior_Project.DataAccessLayer;
using CPIS_Senior_Project.DataModels;
using System;

namespace CPIS_Senior_Project.Management
{
    public partial class MovieDetails : System.Web.UI.Page
    {
        private string movieID;
        protected void Page_Load(object sender, EventArgs e)
        {
            movieID = Request.QueryString["ID"];

            if (movieID != null)
            {
                //Load movie from DB here
                TheaterTier movieManager = new TheaterTier();
                Account account = (Account)Session["Account"];
                Movie mv = movieManager.GetMovie(int.Parse(movieID));

                //Shows movie info if it exists in DB
                if (mv.Title != "")
                {
                    pnlMovieInfo.Visible = true;
                    debug.Visible = false;
                    moviePoster.Src = "~/Handlers/MoviePoster.ashx?ID=" + movieID;
                    movieTitle.Text = mv.Title;
                    movieSummary.Text = mv.Summary;
                    ticketPrice.Text = mv.Price.ToString();
                }

                //Shows management tools if logged in as theater employee
                if (Session["Login"] != null && (bool)Session["login"] == true && account.Role == "Theater")
                {
                    mgmt_Edit.Visible = true;
                }
            }
            /* else
            {
                pnlMovieInfo.Visible = false;
                debug.Text = ErrorHandler.noMovie + "<br />";
                debug.Visible = true;
            } */
        }

        protected void EditMovie_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Management/EditMovie.aspx?ID=" + movieID);
        }

        protected void ChooseTheater_Change(object sender, EventArgs e)
        {
            //Check if theater has been selected here, pull relevant
            //ticket price and enable the Purchase button when complete
        }
    }
}