using CPIS_Senior_Project.DataAccessLayer;
using System;
using System.Web;

namespace CPIS_Senior_Project.Handlers
{
    /// <summary>
    /// This pulls the movie poster from the database and returns it for use on the aspx pages
    /// </summary>
    public class MoviePoster : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            byte[] theImage = null;
            TheaterTier theTier = new TheaterTier();
            Int32 ImageID = Int32.Parse(context.Request.QueryString["ID"]);

            /// if statement goes here to check for null.  If it is, load alternate image.
            if (ImageID <= 2)
            {
                theImage = theTier.GetPoster(ImageID);
            }
            else
            {
                theImage = theTier.GetPoster(-1);
            }

            context.Response.BinaryWrite(theImage);
        }

        public bool IsReusable
        {
            get
            {
                return true;
            }
        }
    }
}