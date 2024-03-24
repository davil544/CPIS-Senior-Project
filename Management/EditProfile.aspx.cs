using CPIS_Senior_Project.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CPIS_Senior_Project.Management
{
    public partial class EditProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Account account = (Account)Session["Account"];
            if (Session["Login"] != null && (bool)Session["Login"] == true && account.Role == "Theater")
            {
                if (account.MyTheater != null)
                {
                    theaterName.Text = account.FullName;
                    Address1.Text = account.MyTheater.Address1;
                    Address2.Text = account.MyTheater.Address2;
                    City.Text = account.MyTheater.City;
                    State.Text = account.MyTheater.State;
                    hours.Text = account.MyTheater.Hours;
                }
                else
                {
                    account.MyTheater = new Theater();
                }
            }

        }

        protected void mgmt_subchanges_Click(object sender, EventArgs e)
        {
            /* Incomplete at this time. This is for adding buttons for submitting */
            /* the changes made for editting theater information, as well as for  */
            /* clearing the fields in the edit theater form.                      */

        }

        protected void mgmt_clear_Click(object sender, EventArgs e)
        {
            
        }
    }
}