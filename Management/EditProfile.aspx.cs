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
            if (Session["Login"] != null && Session["Loaded"] == null)
            {
                
                Session["Loaded"] = true;
            }
            else
            {
                //Response.Redirect("Default.aspx");
            }

            //This keeps overwriting the input values. why???
            //Maybe use query strings instead of session variables to load values?
            if (Session["Login"] != null && (bool)Session["Login"] == true && account.Role == "Theater")
            {
                if (account.MyTheater != null)
                {
                    account = (Account)Session["Account"];
                    txtTheaterName.Text = account.FullName;
                    txtAddress1.Text = account.MyTheater.Address1;
                    txtAddress2.Text = account.MyTheater.Address2;
                    txtCity.Text = account.MyTheater.City;
                    txtState.Text = account.MyTheater.State;
                    txtZipCode.Text = account.MyTheater.PostalCode;
                    txtCountry.Text = account.MyTheater.Country;
                    txtHours.Text = account.MyTheater.Hours;
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
            //firstAccess = false;
            account.FullName = txtTheaterName.Text;
            account.MyTheater = new Theater();
            account.MyTheater.Address1 = txtAddress1.Text;
            account.MyTheater.Address2 = txtAddress2.Text;
            account.MyTheater.City = txtCity.Text;
            account.MyTheater.State = txtState.Text;
            account.MyTheater.PostalCode = txtZipCode.Text;
            account.MyTheater.Country = txtCountry.Text;
            account.MyTheater.Hours = txtHours.Text;
            debug.Text = account.MyTheater.Address1;

            //Why isn't this passing on the new changes???
            Authentication loginManager = new Authentication();
            debug.Text = loginManager.UpdateAccount(account);
            //void firstaccess session after updating db
        }

        protected void mgmt_cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Management");
        }
    }
}