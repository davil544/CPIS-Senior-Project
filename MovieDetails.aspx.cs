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

                moviePoster.Src = "~/Handlers/MoviePoster.ashx?ID=" + movieID;
                movieTitle.Text = mv.Title;
                movieSummary.Text = mv.Summary;
                ticketPrice.Text = mv.Price.ToString();

                //Shows management tools if logged in as theater employee
                if (Session["Login"] != null && (bool)Session["login"] == true && account.Role == "Theater")
                {
                    mgmt_Edit.Visible = true;
                }
            }
            else
            {
                debug.Text = ErrorHandler.noMovie + "<br />";
                debug.Visible = true;
            }
        }

        protected void EditMovie_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Management/EditMovie.aspx?ID=" + movieID);
        }
    }
}