using CPIS_Senior_Project.DataAccessLayer;
using CPIS_Senior_Project.DataModels;
using CPIS_Senior_Project.Handlers;
using System;

namespace CPIS_Senior_Project.Management
{
    public partial class EditMovie : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //TODO:  Add check for login to ensure customers can't edit movie data
            string movieID = Request.QueryString["ID"];
            if (movieID != null)
            {
                //Load movie from DB here
                TheaterTier movieManager = new TheaterTier();
                Account account = (Account)Session["Account"];
                Movie mv = movieManager.GetMovie(int.Parse(movieID));

                txtMovieName.Text = mv.Title;
                txtMovieDesc.Text = mv.Summary;
                txtReleaseYear.Text = mv.ReleaseYear;
                txtMovieGenre.Text = mv.Genre;
                txtMovieRating.Text = mv.MPA_rating;
                txtTimeSlot.Text = mv.TimeSlot;
                txtTicketPrice.Text = mv.Price.ToString();

                //Make new movie object when saving info to compare to the new object,
                //only upload changed fields maybe instead of recreating the entry
            }
            else
            {
                debug.Text = "No Movie Found! <br />";
                debug.Visible = true;
            }
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            //Clear out session variable here before redirecting if necessary!
            Response.Redirect("Default.aspx");
        }
    }
}