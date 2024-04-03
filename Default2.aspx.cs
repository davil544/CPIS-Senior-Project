using CPIS_Senior_Project.DataAccessLayer;
using CPIS_Senior_Project.DataModels;
using System;
using System.Web.UI.HtmlControls;

namespace CPIS_Senior_Project
{
    public partial class Default2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                TheaterTier theaterInfo = new TheaterTier();
                Movie[] movies = theaterInfo.GetMovies();
                int count = movies != null ? theaterInfo.GetMovieCount() : 0;

                bool isFirstItem = true;
                for (int i = 0; i < count; i++)
                {
                    HtmlGenericControl carouselItem = new HtmlGenericControl("div");
                    carouselItem.Attributes["class"] = isFirstItem ? "carousel-item active" : "carousel-item";
                    isFirstItem = false;

                    HtmlGenericControl imgContainer = new HtmlGenericControl("div");
                    imgContainer.Attributes["class"] = "d-flex justify-content-center";

                    for (int j = i; j < Math.Min(i + 3, count); j++)
                    {
                        HtmlGenericControl imgDiv = new HtmlGenericControl("div");
                        imgDiv.Attributes["class"] = "p-2";

                        HtmlGenericControl img = new HtmlGenericControl("img");
                        img.Attributes["src"] = $"/Handlers/MoviePoster.ashx?ID={j + 1}";
                        img.Attributes["alt"] = "Movie Poster";
                        img.Attributes["style"] = "max-height: 240px; width: auto;"; // Adjust size here

                        //Maybe replace these with a href buttons with bootstrap themes?
                        //This will allow you to link them to the movie status pages respectively
                        HtmlGenericControl button = new HtmlGenericControl("button");
                        button.Attributes["class"] = "btn btn-primary btn-movie-title";
                        button.InnerText = movies[j].Title;

                        imgDiv.Controls.Add(img);
                        imgDiv.Controls.Add(button);
                        imgContainer.Controls.Add(imgDiv);
                    }

                    carouselItem.Controls.Add(imgContainer);
                    carouselItems.Controls.Add(carouselItem);

                    i += 2; // Increment by 2 since we are displaying 3 items at a time
                }
            }
        }
    }
}