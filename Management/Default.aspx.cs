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
                //Populate Theater Owner Dashboard Here

                greeting.Text = "Welcome, " + user.FullName + "!";

                //Create a for loop that populates the movies from the database
                //after page design is complete, store statically until then
                TheaterTier theaterInfo = new TheaterTier();
                int count = theaterInfo.GetMovieCount();
                List<Movie> movies = new List<Movie>();
                lblMovieCount.Text += count.ToString();
                
                for (int i = 0; i < count; i++)
                {
                  movies[i] = new Movie();
                }

                //Check if i is a multiple of 3 using modulus, if it is add a br tag after inserting poster
            }
            else
            {
                greeting.Text = "Something went wrong, redirecting back to the login page...";
                Response.Redirect("~/Management/Login.aspx");
            }
        }
        protected void AddMovie_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Management/AddMovie");
        }
    }
}