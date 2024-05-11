using CPIS_Senior_Project.DataAccessLayer;
using CPIS_Senior_Project.DataModels;
using System;

namespace CPIS_Senior_Project.Management
{
    public partial class ViewMessage : System.Web.UI.Page
    {
        private string msgID; private Message msg;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Login"] != null && (bool)Session["Login"] == true)
            {
                if (msgID != "")
                {
                    //This loads and populates the message info
                    msgID = Request.QueryString["ID"];
                    Account account = (Account)Session["Account"];
                    msg = Messenger.GetMessage(account.Username, int.Parse(msgID));

                    if (msg.ID != 0)
                    {
                        lblSender.Text = msg.Sender;
                        lblRecipient.Text = msg.Recipient;
                        lblSubject.Text = msg.Subject;
                        lblTime.Text = msg.TimeStamp.ToString();
                        litMessage.Text = msg.MessageContents;
                    }
                    else
                    {
                        //This runs when someone tries to read another user's message
                        //or if there is no message that matches the ID
                        pnlMessage.Visible = false;
                        debug.Text = ErrorHandler.emptyInbox;
                        debug.Visible = true;
                    }
                }
                else
                {
                    //This runs when there is no message ID specified in the URL
                    pnlMessage.Visible = false;
                    debug.Text = ErrorHandler.emptyInbox;
                    debug.Visible = true;
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

        protected void BtnReply_Click(object sender, EventArgs e)
        {
            Session["reply"] = msg;
            Response.Redirect("/Management/ComposeMessage");
        }
    }
}