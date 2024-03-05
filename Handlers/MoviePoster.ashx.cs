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
            /// TheaterTier theTier = new TheaterTier(); ///Uncomment this once TheaterTier has been created
            Int32 ImageID = Int32.Parse(context.Request.QueryString["ID"]);

            /// if statement goes here to check for null.  If it is, load alternate image.
            if (ImageID <= 2)
            {
                /// theImage = theTier.getImage(ImageID); ///Uncomment this once TheaterTier has been created
            }
            else
            {
                /// theImage = theTier.getImage(-1); ///Uncomment this once TheaterTier has been created
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