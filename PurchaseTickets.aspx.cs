
using CPIS_Senior_Project.DataAccessLayer;
using CPIS_Senior_Project.DataModels;
using System;



namespace CPIS_Senior_Project
{
    public partial class PurchaseTickets : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Login"] != null && (bool)Session["Login"] == true && Session["Account"] != null)
            {
                string movieID = Request.QueryString["ID"];
                Account account = (Account)Session["Account"];
                CustomerName.Text = "Name: " + account.FullName;
                if (movieID != null)
                {
                    TheaterTier movieManager = new TheaterTier();
                    
                    Movie mv = movieManager.GetMovie(int.Parse(movieID));
                    MovieName.Text = "Movie Name: " + mv.Title;
                }
            }


        }



        protected void btnRegister_Click(object sender, EventArgs e)
        {

            Account customerAccount = new Account();
            

            bool valid = true; string status = "";

            if (customerAccount.CC != null)
            {
                //Code goes here to purchase ticket
                customerAccount.CC.CardNumber = cc_number.Text;
                customerAccount.CC.CVV = cc_cvv.Text;
                //customerAccount.CC.ExpirationDate = cc_cvv.Text;
            }
            else
            {
                Creditcard_Info.Visible = true;
                //cc.Role = "Credit ccv";

               /* if (ccv.Text.Equals("") || cc_number.Text.Equals("") || cc_expiration.Text.Equals("") || cc_cvv.Text.Equals(""))
                {
                    status = ErrorHandler.empty;
                    valid = false;

                } 

                else
                {
                    try
                    {
                        //auth.CC = new CreditCard();
                        //auth.CC.CardNumber = cc_number.Text;
                        //auth.CC.CVV = cc_cvv.Text;
                    }
                    catch { }
               }*/
            }
        }
    }
}
