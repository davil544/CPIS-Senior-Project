using CPIS_Senior_Project.DataAccessLayer;
using CPIS_Senior_Project.DataModels;
using System;

namespace CPIS_Senior_Project.Management
{
    public partial class AddMovie : System.Web.UI.Page
    {
        private Movie mv;
        protected void Page_Load(object sender, EventArgs e)
        {
            //This is to prevent everyone from being able to upload movies to this service
            Account account = (Account)Session["Account"];
            //TODO:  Add check for Theater role
            if (Session["Login"] != null && (bool)Session["Login"] == true && account.Role == "Theater")
            {
                mv = new Movie();
            }
            else if(Session["Login"] != null && (bool)Session["Login"] == true && account.Role == "Customer")
            {
                formAddMovie.Visible = false;
                lblDebug.Text = ErrorHandler.notPermitted;
                lblDebug.Visible = true;
            }
            else 
            {
                lblStatus.Text = ErrorHandler.invalidLoginToken;
                Response.Redirect("~/Management/Login.aspx");
            }
                
        }

        protected void BtnAddMovie_Click(object sender, EventArgs e)
        {
            TheaterTier theater = new TheaterTier();
            mv.Title = movieTitle.Text;
            mv.Summary = movieSummary.Text;
            mv.ReleaseYear = releaseYear.Text;
            mv.Genre = movieGenre.Text;
            mv.MPA_rating = movieRating.Text;
            mv.TimeSlot = timeSlot.Text;
            try
            {
                mv.Price = float.Parse(ticketPrice.Text);
            }
            catch 
            {
                //Put in better input validation here!
                mv.Price = 0;
            }
            if (posterUpload.HasFile)
            {
                //Add input validation to make sure only images are uploaded here!
                mv.Poster = (byte[])posterUpload.FileBytes;
            }

            string success = theater.AddMovie(mv);
            //fill in movie data and send it to DB with function in TheaterTier
            lblStatus.Text = success;

            //Either redirect back to management page with success prompt here
            //or to movie details page that will be dynamically generated
            //Response.Redirect("~/Management");
        }
        protected void BtnReturn_Click (object sender, EventArgs e)
        {
            Response.Redirect("~/Management");
        }
    }
}