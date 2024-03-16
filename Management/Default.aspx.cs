using CPIS_Senior_Project.DataAccessLayer;
using CPIS_Senior_Project.DataModels;
using System;

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
                Movie[] movies = theaterInfo.getMoviesList();

                int count;
                if (movies != null)
                {
                    count = theaterInfo.GetMovieCount();
                }
                else
                {
                     count = 0;
                }

                lblMovieCount.Text = count.ToString();
                movieList.Text = "<div class=\"row\" style=\"padding-top: 50px;\">";
                for (int i = 0; i < count; i++)
                {
                    int dbCount = i + 1;
                    if (i % 3 == 0 && i != 0)
                    {
                        movieList.Text += "<br />";
                    }
                    movieList.Text += "<div class=\"col-sm-6 col-md-4\">\r\n   <div class=\"thumbnail\">" +
                        "<img src=\"/Handlers/MoviePoster.ashx?ID=" + dbCount + "\" alt=\"Movie Poster Goes Here\" height=\"320px\" width=\"240px\">" +
                        "<div class=\"caption\"><h3><asp:Label ID=\"lblMovieTitle" + dbCount + "\" runat=\"server\" Text=\"\">" + movies[i].Title + "</asp:Label></h3>" +
                        "<p><asp:Label ID=\"lblMovieSummary" + dbCount + "\" runat=\"server\" Text=\"\">" + theaterInfo.TruncateString(movies[i].Summary, 150) + "</asp:Label></p>" +
                        "<p><asp:Label ID=\"lblMoviePrice" + dbCount + "\" runat=\"server\" Text=\"\">$" + movies[i].Price.ToString() + "</asp:Label></p>" +  // Will work once saving and fetching this is implemented
                        "<p><asp:Button ID=\"btnAddMovie" + dbCount + "\" runat=\"server\" BackColor=\"#337AB7\" ForeColor=\"White\" Height=\"30px\" Text=\"Modify\" />&nbsp;" +
                        "<asp:Button ID=\"btnDetailsMovie" + dbCount + "\" runat=\"server\" Height=\"30px\" Text=\"Details\"  /></p></div></div></div>";

                    //Buttons not working properly with loop, maybe use Placeholder or Panels to hold above code?  Maybe even HtmlGenericControls?
                    lblMovieTitle.Text = movies[i].Title;
                    lblMovieSummary.Text = theaterInfo.TruncateString(movies[i].Summary, 150);
                    lblMoviePrice.Text = "$" + movies[i].Price.ToString();
                    imgMovie1.ImageUrl = "/Handlers/MoviePoster.ashx?ID=" + (i + 1);
                }

                movieList.Text += "</div>";
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
        //Might add a delete function, causes issues with Identity key though so may omit this for now
    }
}