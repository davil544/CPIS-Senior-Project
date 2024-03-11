using System;
using CPIS_Senior_Project.DataAccessLayer;
using CPIS_Senior_Project.DataModels;

namespace CPIS_Senior_Project.Management
{
    public partial class LoginRegistration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["Login"] = null;
            State.Attributes.Add("maxlength", "2");
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
                auth.FullName = theaterName.Text;
                auth.MyTheater = new Theater();
            }
            else
            {
                auth.Role = "Customer";
                //check if null here, show error code if so, maybe use try catch for multiple error codes! (Input Validation too?)
                //TODO:  Move this if statement to the Authentication class to clean up redundant code
                //Already working there for the Theater role so may as well
                if (customerName.Text.Equals("") || cc_number.Text.Equals("") || cc_expiration.Text.Equals("") || cc_cvv.Text.Equals(""))
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
                    auth.FullName = customerName.Text;
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