using CPIS_Senior_Project.DataAccessLayer;
using CPIS_Senior_Project.DataModels;
using System;

namespace CPIS_Senior_Project.Management
{
    public partial class EditProfile : System.Web.UI.Page
    {
        Account account;
        protected void Page_Load(object sender, EventArgs e)
        {
            account = (Account)Session["Account"];
            if (Session["Login"] != null && (bool)Session["Login"] == true && account.Role == "Theater")
            {
                if (account.MyTheater != null)
                {
                    theaterName.Text = account.FullName;
                    Address1.Text = account.MyTheater.Address1;
                    Address2.Text = account.MyTheater.Address2;
                    City.Text = account.MyTheater.City;
                    State.Text = account.MyTheater.State;
                    txtZipCode.Text = account.MyTheater.PostalCode;
                    txtCountry.Text = account.MyTheater.Country;
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
            /* Incomplete at this time. This function is for submitting */
            /* the changes made for editing theater information in the  */
            /* edit theater form.                                       */
            Account updated = new Account();
            updated.FullName = theaterName.Text;
            updated.MyTheater = new Theater();
            updated.MyTheater.Address1 = Address1.Text;
            updated.MyTheater.Address2 = Address2.Text;
            updated.MyTheater.City = City.Text;
            updated.MyTheater.State = State.Text;
            updated.MyTheater.PostalCode = txtZipCode.Text;
            updated.MyTheater.Country = txtCountry.Text;
            updated.MyTheater.Hours = hours.Text;

            Authentication loginManager = new Authentication();
            debug.Text = loginManager.UpdateAccount(account.Username, updated);
        }

        protected void mgmt_cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Management");
        }
    }
}