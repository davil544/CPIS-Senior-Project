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
                if (Session["reply"] != null && !IsPostBack)
                {
                    msg = (Message)Session["Reply"];
                    txtRecipient.Text = msg.Sender;
                    txtSubject.Text = "RE: " + msg.Subject;
                    txtMessage.Text = "\r\n_____________________________________" +
                        "\r\nPrevious Message Contents:\r\nTo: " + msg.Recipient +
                        "\r\nFrom: " + msg.Sender + "\r\nTime: " + msg.TimeStamp.ToString() +
                        "\r\nSubject: " + msg.Subject +
                        "\r\nMessage: " + msg.MessageContents;
                }
            }

            else
            {
                //This runs when the user is not logged in
                pnlMessage.Visible = false;
                debug.Text = ErrorHandler.notPermitted;
                //debug.Visible = true;
            }
        }

        protected void BtnSend_Click(object sender, EventArgs e)
        {
            //Do necessary checks here then send the message!
            //debug.Text = Messenger.SendMessage(msg);
            Message msg = new Message();
            msg.Sender = account.Username;
            msg.Recipient = txtRecipient.Text;
            msg.Subject = txtSubject.Text;
            msg.MessageContents = txtMessage.Text;

            debug.Text = Messenger.SendMessage(msg);
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            Session["reply"] = null;
            Response.Redirect("/Management/Inbox");
        }
    }
}