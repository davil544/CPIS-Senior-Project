using CPIS_Senior_Project.DataAccessLayer;
using CPIS_Senior_Project.DataModels;
using System;
using System.Web.UI.WebControls;

namespace CPIS_Senior_Project.Management
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //This is to prevent customers from being able to manage movies on this service
            Account user = (Account)Session["Account"]; ;
            if (Session["Login"] != null && (bool)Session["Login"] == true && user.Role == "Theater") {
                greeting.Text = "Welcome, " + user.FullName + "!";

                TheaterTier theaterInfo = new TheaterTier();
                Movie[] movies = theaterInfo.GetMovies();

                int count;
                if (movies != null)
                {
                    count = theaterInfo.GetMovieCount();
                }
                else
                {
                     count = 0;
                }

                //This is for debug purposes, shows the number of movies found in the database
                lblMovieCount.Text = count.ToString();
                Literal movieText = new Literal
                {
                    Text = "<div class=\"row\" style=\"padding-top: 50px;\">"
                };
                for (int i = 0; i < count; i++)
                {
                    int dbCount = i + 1;
                    movieText.Text += "<div class=\"col-sm-6 col-md-4\">\r\n   <div class=\"thumbnail\">" +
                        "<img src=\"/Handlers/MoviePoster.ashx?ID=" + dbCount + "\" alt=\"Movie Poster Goes Here\" height=\"320px\" width=\"240px\">" +
                        "<div class=\"caption\"><h3><asp:Label ID=\"lblMovieTitle" + dbCount + "\" runat=\"server\" Text=\"\">" + movies[i].Title + "</asp:Label></h3>" +
                        "<p><asp:Label ID=\"lblMovieSummary" + dbCount + "\" runat=\"server\" Text=\"\">" + theaterInfo.TruncateString(movies[i].Summary, 150) + "</asp:Label></p>" +
                        "<p><asp:Label ID=\"lblMoviePrice" + dbCount + "\" runat=\"server\" Text=\"\">$" + movies[i].Price.ToString() + "</asp:Label></p>" +  // Will work once saving and fetching this is implemented
                        "<p><a href=\"EditMovie.aspx?ID=" + dbCount + "\" class=\"btn btn-primary btn-sm\">Modify</a>&nbsp;" +
                        "<a href=\"/MovieDetails.aspx?ID=" + dbCount + "\" class=\"btn btn-secondary btn-sm\">Details</a></p></div><br /><br /></div></div>";
                    
                }
                movieText.Text += "</div>";
                movieCatalog.Controls.Add(movieText);
            }
            else
            {
                greeting.Text = ErrorHandler.invalidLoginToken;
                Response.Redirect("~/Management/Login.aspx");
            }
        }
        //TODO:  Add function that allows showtimes to be set on a per theater basis
        protected void AddMovie_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Management/AddMovie");
        }
        //Might add a delete function, causes issues with Identity key though so may omit this for now

        protected void EditProfile_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Management/EditProfile");
        }
    }
}