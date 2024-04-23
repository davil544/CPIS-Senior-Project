using CPIS_Senior_Project.DataAccessLayer;
using CPIS_Senior_Project.DataModels;
using System;

namespace CPIS_Senior_Project
{
    public partial class SearchResults : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["query"] != null)
            {
                litSearchQuery.Text = Session["query"].ToString();
                litResults.Text = "<br />";
                TheaterTier theaterManager = new TheaterTier();
                Movie[] movies = theaterManager.GetMovies((string)Session["query"]);
                foreach (Movie movie in movies) {
                    litResults.Text += "<a href=\"MovieDetails.aspx?ID=" + movie.ID + "\">" + movie.Title + "</a><br />";
                }
            }
            else
            {
                heading2.Attributes["hidden"] = "hidden";
                litResults.Text = ErrorHandler.noMovie;
            }
        }
    }
}