using CPIS_Senior_Project.DataAccessLayer;
using CPIS_Senior_Project.DataModels;
using Microsoft.Ajax.Utilities;
using System;
using System.ComponentModel.Design;


namespace CPIS_Senior_Project
{
    public partial class PurchaseTickets : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["Credit Card #"] = null;
            //State.Attributes.Add("maxlength", "16");


        }
    }
}
        /*
        protected void btnRegister_Click(object sender, EventArgs e)
        {

            Authentication CreditCardManager = new Authentication();


            Account cc = new Account();
            cc.number = cc_number.Text;
            cc.cvv = cc_cvv.Text;
            cc.expiration = cc_cvv.Text;

            bool valid = true; string status = "";
        }
        if (CreditCard.Checked)
            {
                cc.number = "Credit Number";
                cc.creditnumber = theaterName.Text;
                cc.Mynumber = new number();
    }
    else
            {
                cc.Role = "Credit ccv";
              
                if (ccv.Text.Equals("") || cc_number.Text.Equals("") || cc_expiration.Text.Equals("") || cc_cvv.Text.Equals(""))
                {
                    status = ErrorHandler.empty;
                    valid = false;

                }

                    else
                   {
                  try
                     {
                     auth.CC = new CreditCard();
                    auth.CC.CardNumber = cc_number.Text;
                    auth.CC.CVV = cc_cvv.Text;
      }
}
*/
