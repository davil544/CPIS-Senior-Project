using CPIS_Senior_Project.DataAccessLayer;
using CPIS_Senior_Project.DataModels;
using System;

namespace CPIS_Senior_Project.Management
{
    public partial class EditMovie : System.Web.UI.Page
    {
        private string movieID;
        protected void Page_Load(object sender, EventArgs e)
        {
            //TODO:  Add check for login to ensure customers can't edit movie data
            movieID = Request.QueryString["ID"];
            if (movieID != null)
            {
                if (!IsPostBack)
                {
                    //Load movie from DB here
                    //Account account = (Account)Session["Account"];
                    TheaterTier movieManager = new TheaterTier();
                    Movie mv = movieManager.GetMovie(int.Parse(movieID));

                    txtMovieName.Text = mv.Title;
                    txtMovieDesc.Text = mv.Summary;
                    txtReleaseYear.Text = mv.ReleaseYear;
                    txtMovieGenre.Text = mv.Genre;
                    txtMovieRating.Text = mv.MPA_rating;

                    //This will work once Showcases SQL table is tied in
                    txtTimeSlot.Text = mv.TimeSlot;

                    //Maybe move this from Theater class to Showcases one
                    //txtTicketPrice.Text = mv.Price.ToString();
                }
            }
            else
            {
                debug.Text = ErrorHandler.noMovie + "<br />";
                debug.Visible = true;
            }
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            TheaterTier theaterManager = new TheaterTier();
            Movie updated = new Movie
            {
                Title = txtMovieName.Text,
                Summary = txtMovieDesc.Text,
                ReleaseYear = txtReleaseYear.Text,
                Genre = txtMovieGenre.Text,
                MPA_rating = txtMovieRating.Text
            };
            if (movieID != null)
            {
                updated.ID = int.Parse(movieID);
            }
            if (posterUpload.HasFile)
            {
                //Add input validation to make sure only images are uploaded here!
                updated.Poster = (byte[])posterUpload.FileBytes;
            }
            debug.Text = theaterManager.UpdateMovie(updated);
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}