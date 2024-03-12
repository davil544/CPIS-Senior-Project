using CPIS_Senior_Project.DataAccessLayer;
using CPIS_Senior_Project.DataModels;
using System;
using System.Collections.Generic;

namespace CPIS_Senior_Project.Management
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //This is to prevent everyone from being able to upload movies to this service
            //TODO:  Add check for Theater role
            if (Session["Login"] != null && (bool)Session["Login"] == true) {
                Account user = (Account)Session["Account"];
                greeting.Text = "Welcome, " + user.FullName + "!";

                //Finish the for loop that populates the movies from the database
                //after page design is complete, store statically until then
                TheaterTier theaterInfo = new TheaterTier();
                List<Movie> movies = theaterInfo.getMoviesList();
                
                //int count = theaterInfo.GetMovieCount();  
                //Not sure if this function is necessary, may remove in a later update

                int count = movies.Count;
                lblMovieCount.Text = count.ToString();
                for (int i = 0; i < count; i++)
                {
                    lblMovieTitle.Text = movies[i].Title;
                    lblMovieSummary.Text = movies[i].Summary;
                    lblMoviePrice.Text = movies[i].Price.ToString();
                    imgMovie1.ImageUrl = "/Handlers/MoviePoster.ashx?ID=" + (i + 1);
                }

                //Check if i is a multiple of 3 using modulus, if it is add a br tag after inserting poster
            }
            else
            {
                greeting.Text = ErrorHandler.invalidLoginToken;
                Response.Redirect("~/Management/Login.aspx");
            }
        }
        protected void AddMovie_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Management/AddMovie");
        }
    }
}