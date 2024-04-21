using CPIS_Senior_Project.DataAccessLayer;
using CPIS_Senior_Project.DataModels;
using System;
using System.Web.UI.WebControls;

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
                            if (account.CC.Length != 0)
                            {
                                for (int i = 0; i < account.CC.Length; i++)
                                {
                                    lstCreditCards.Items.Insert(i, new ListItem(account.CC[i].CardNumber, account.CC[i].CardID.ToString()));
                                }
                                debug.Text = "Card Count: " + (lstCreditCards.Items.Count - 2);
                            }
                            else
                            {
                                debug.Text = "Card Count: 0";
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
                    if (txtCC_number.Text != "" && txtExpDate.Text != "" && txtCVV.Text != "")
                    {
                        //This works but doesn't reflect in the EditProfile page until the project is restarted, why?
                        //Maybe move this to a separate function or something like that?
                        if (lstCreditCards.SelectedValue == "newcard")
                        {
                            account.CC[0] = new CreditCard();
                        }
                        account.CC[0].CardNumber = txtCC_number.Text;
                        account.CC[0].ExpirationDate = txtExpDate.Text;
                        account.CC[0].CVV = txtCVV.Text;
                    }
                    break;
            }
            debug.Text = AccountManager.UpdateAccount(account);
            //Response.Redirect("/Management/EditProfile");

        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            if (account.Role == "Theater")
            {
                Response.Redirect("/Management");
            }
            else
            {
                Response.Redirect("/");
            }
        }

        protected void ListCC_Change(object sender, EventArgs e)
        {
            int ccID = lstCreditCards.SelectedIndex;
            if (lstCreditCards.SelectedValue == "newcard")
            {
                formCCHTML.Visible = true;
            }
            else if (ccID <= 0)
            {
                try
                {
                    txtCC_number.Text = account.CC[ccID].CardNumber;
                    txtExpDate.Text = account.CC[ccID].ExpirationDate;
                    txtCVV.Text = account.CC[ccID].CVV;
                }
                catch
                {
                    //Code throws IndexOutOfRangeException if this
                    //block is not here and Add New Card is selected
                }
                formCCHTML.Visible = true;
            }
            
            else
            {
                formCCHTML.Visible = false;
            }
            
        }
    }
}