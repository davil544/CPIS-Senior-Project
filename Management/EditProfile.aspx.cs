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
                if (!IsPostBack)
                {
                    if (account.MyTheater != null)
                    {

                        txtTheaterName.Text = account.FullName;
                        txtAddress1.Text = account.MyTheater.Address1;
                        txtAddress2.Text = account.MyTheater.Address2;
                        txtCity.Text = account.MyTheater.City;
                        txtState.Text = account.MyTheater.State;
                        txtZipCode.Text = account.MyTheater.PostalCode;
                        txtCountry.Text = account.MyTheater.Country;
                        txtHours.Text = account.MyTheater.Hours;
                        txtTicketPrice.Text = account.MyTheater.TicketPrice.ToString();
                    }
                    else
                    {
                        //Not sure if this code will ever run, may delete in a future update
                        account.MyTheater = new Theater();
                    }
                }
                
            }
            else
            {
                debug.Text = ErrorHandler.invalidLoginToken;
                Response.Redirect("~/Management/Login.aspx");
            }
        }

        protected void mgmt_subchanges_Click(object sender, EventArgs e)
        {
            account.FullName = txtTheaterName.Text;
            account.MyTheater = new Theater
            {
                Address1 = txtAddress1.Text,
                Address2 = txtAddress2.Text,
                City = txtCity.Text,
                State = txtState.Text,
                PostalCode = txtZipCode.Text,
                Country = txtCountry.Text,
                Hours = txtHours.Text,
                TicketPrice = float.Parse(txtTicketPrice.Text)
            };

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