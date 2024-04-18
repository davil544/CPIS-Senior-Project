using CPIS_Senior_Project.DataAccessLayer;
using CPIS_Senior_Project.DataModels;
using System;

namespace CPIS_Senior_Project.Management
{
    public partial class ComposeMessage : System.Web.UI.Page
    {
        Account account; Message msg;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Login"] != null && (bool)Session["Login"] == true)
            {
                account = (Account)Session["Account"];
                if (Session["reply"] != null)
                {
                    //Populate reply email info here
                }
            }
            else
            {
                //This runs when the user is not logged in
                pnlMessage.Visible = false;
                debug.Text = ErrorHandler.notPermitted;
                debug.Visible = true;
            }
        }

        protected void BtnSend_Click(object sender, EventArgs e)
        {
            //Do necessary checks here then send the message!
            //debug.Text = Messenger.SendMessage(msg);
        }
    }
}