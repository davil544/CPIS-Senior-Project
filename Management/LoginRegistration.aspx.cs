using System;
using System.Data.SqlClient;
using CPIS_Senior_Project.DataAccessLayer;
using CPIS_Senior_Project.DataModels;
using Microsoft.Ajax.Utilities;

namespace CPIS_Senior_Project.Management
{
    public partial class LoginRegistration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["Login"] = null;
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            //This creates the object used to connect to the SQL server for authentication
            Authentication loginManager = new Authentication();

            //This creates the object that stores the login credentials
            Account auth = new Account();
            auth.Username = mgmt_Username.Text;
            auth.Password = mgmt_Password.Text;

            bool valid = true;  string status = "";
            
            //Make new table for CC #s in SQL server, link cards to user via private key
            if (theaterRole.Checked)
            {
                auth.Role = "Theater";
            }
            else
            {
                auth.Role = "Customer";
                //check if null here, show error code if so, maybe use try catch for multiple error codes! (Input Validation too?)
                if (name.Text.Equals("") || cc_number.Text.Equals("") || cc_expiration.Text.Equals("") || cc_cvv.Text.Equals(""))
                {
                    status = "Reqired field is empty, try again!";
                    valid = false;
                }
                else
                {
                    try
                    {
                        //TODO:  Put in regex to strip out all characters except numbers and ensure the format is correct
                        auth.CC = new CreditCard();
                        auth.CC.CardNumber = cc_number.Text;
                        //auth.CC.ExpirationDate = cc_expiration.Text;  //Convert to DateTime
                        auth.CC.CVV = cc_cvv.Text;
                    }
                    catch (FormatException)
                    {
                        status = "Please only use numbers when filling out credit card info!";
                        valid = false;
                    }
                    auth.FullName = name.Text;
                }
            }

            if (valid)
            {
                status = loginManager.Registration(auth);
            }

            if (status == "success") {
                Session["Registered"] = true;
                Response.Redirect("~/Management/Login");
            }
            else
            {
                mgmt_status_message.Text = status;
            }
        }

        public void btnRole_Click(object sender, EventArgs e)
        {
            //Maybe reinitialize all text boxes when radio button is changed
            if (theaterRole.Checked)
            {
                theaterForm.Visible = true;
                customerForm.Visible = false;
            }
            else
            {
                theaterForm.Visible = false;
                customerForm.Visible = true;
            }
        }
    }
}