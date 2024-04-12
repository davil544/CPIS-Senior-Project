using CPIS_Senior_Project.DataAccessLayer;
using CPIS_Senior_Project.DataModels;
using System;

namespace CPIS_Senior_Project
{
    public partial class TheaterDetails : System.Web.UI.Page
    {
        private string theaterID;
        protected void Page_Load(object sender, EventArgs e)
        {
            theaterID = Request.QueryString["ID"];
            Account account = (Account)Session["Account"];
            if (Session["Login"] != null && (bool)Session["Login"] == true && account.Role == "Theater")
            {
                btnEdit.Visible = true;
                lblThtrName.Text = account.FullName;
                lblThtrLoc.Text = account.MyTheater.Address1 + "<br />" + account.MyTheater.Address2 + "<br />" + account.MyTheater.City + ",&nbsp" + account.MyTheater.State + ",&nbsp" + account.MyTheater.PostalCode + ",&nbsp" + account.MyTheater.Country;
                lblThtrOH.Text = account.MyTheater.Hours;
            }
            else if (theaterID != null)
            {
                //Populate theater information here
                TheaterTier theaterManager = new TheaterTier();
                Theater theater = theaterManager.GetTheater(theaterID);

                lblThtrName.Text = theater.ID;
                lblThtrLoc.Text = theater.Address1 + "<br />" + theater.Address2 + "<br />" + theater.City + ",&nbsp" + theater.State + ",&nbsp" + theater.PostalCode + ",&nbsp" + theater.Country;
                lblThtrOH.Text = theater.Hours;
            }
            else
            {
                debug.Text = ErrorHandler.noTheater;
                debug.Visible = true;
                pnlInfo.Visible = false;
            }
        }

        protected void EditTheater_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Management/EditProfile");
        }
    }
}