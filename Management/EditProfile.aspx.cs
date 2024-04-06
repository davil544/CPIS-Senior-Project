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
            if (Session["Login"] != null && (bool)Session["Login"] == true)
            {
                account = (Account)Session["Account"];
                switch (account.Role)
                {
                    case "Theater":
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
                        break;

                    case "Customer":
                        editTheater_form.Visible = false;
                        editCustomer_form.Visible = true;
                        if (!IsPostBack)
                        {
                            txtCustName.Text = account.FullName;
                            if (account.CC[0] != null)
                            {
                            //TODO: Add for loop to pull all available credit cards available for use by customers
                                txtCC_number.Text = account.CC[0].CardNumber;
                                txtExpDate.Text = account.CC[0].ExpirationDate;
                                txtCVV.Text = account.CC[0].CVV;
                            }
                        }
                        break;

                    //This runs when the role is configured incorrectly
                    default:
                        debug.Text = ErrorHandler.invalidLoginToken;
                        Response.Redirect("~/Management/Login.aspx");
                        break;
                }
                
                
            }
            else
            {
                //This redirects the user to the login page if they are not yet authenticated
                //or if they attempt to access this page as a customer.  May show an error
                //message to customers instead of signing them out in a future update
                debug.Text = ErrorHandler.invalidLoginToken;
                Response.Redirect("~/Management/Login.aspx");
            }
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            switch (account.Role)
            {
                case "Theater":
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
                    break;

                case "Customer":
                    account.FullName = txtCustName.Text;
                    if (txtCC_number.Text != null && txtExpDate.Text != null && txtCVV.Text != null)  //Maybe check for "" here if null check fails?
                    {
                        account.CC[0].CardNumber = txtCC_number.Text;
                        account.CC[0].ExpirationDate = txtExpDate.Text;
                        account.CC[0].CVV = txtCVV.Text;
                    }
                    break;
            }

            debug.Text = AccountManager.UpdateAccount(account);
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Management");
        }
    }
}