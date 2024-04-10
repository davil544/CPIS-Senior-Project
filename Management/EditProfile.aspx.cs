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
                                    lstCreditCards.Items.Insert(i, new ListItem(account.CC[i].CardNumber, "Card #" + i));
                                }
                                debug.Text = "Card Count: " + (lstCreditCards.Items.Count - 1);
                            }
                            else
                            {
                                lstCreditCards.Items.Insert(0, new ListItem("Add New Card", "newcard"));
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
                    debug.Text = AccountManager.UpdateAccount(account);
                    break;

                case "Customer":
                    account.FullName = txtCustName.Text;
                    CreditCard newCard = new CreditCard();
                    //get CC ID here if not null, then make function to overwrite that card in the SQL DB
                    if (txtCC_number.Text != null && txtExpDate.Text != null && txtCVV.Text != null)  //Maybe check for "" here if null check fails?
                    {
                        newCard.CardNumber = txtCC_number.Text;
                        newCard.ExpirationDate = txtExpDate.Text;
                        newCard.CVV = txtCVV.Text;
                    }
                    if (newCard != new CreditCard())
                    {
                        //add cc info to function here, maybe overload it to support 2 inputs
                    }
                    else
                    {
                        //just change name here
                    }
                    break;
            }

            //debug.Text = AccountManager.UpdateCreditCard(account);
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Management");
        }

        protected void ListCC_Change(object sender, EventArgs e)
        {
            int ccID = lstCreditCards.SelectedIndex;
            if (ccID <= 0)
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