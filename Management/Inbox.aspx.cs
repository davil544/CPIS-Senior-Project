using CPIS_Senior_Project.DataAccessLayer;
using CPIS_Senior_Project.DataModels;
using System;
using System.Web.UI.WebControls;

namespace CPIS_Senior_Project.Management
{
    public partial class Inbox : System.Web.UI.Page
    {
        private Message[] msgs; private Account account;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Login"] != null && (bool)Session["Login"] == true)
            {
                account = (Account)Session["Account"];
                msgs = Messenger.GetMessages(account.Username, "recieve");
                LoadMessages(msgs);
            }
            else
            {
                pnlMessages.Visible = false;
                debug.Text = ErrorHandler.notPermitted;
                debug.Visible = true;
            }
        }

        private void LoadMessages(Message[] msgs)
        {
            if (msgs != null)
            {
                for (int i = 0; i < msgs.Length; i++)
                {
                    litMessages.Text = "<tr onclick=\"location.href='ViewMessage.aspx?ID=" + msgs[i].ID + "'\">" +
                          "<td>" + msgs[i].Sender + "</td>" +
                          "<td>" + msgs[i].MessageContents + "</td>" +
                          "<td>" + msgs[i].TimeStamp.ToString() + "</td>" +
                        "</tr>";
                }
            }
            else
            {
                litMessages.Text = "<tr><td class=\"tblNone\" /><td class=\"tblNone\">" + ErrorHandler.emptyInbox + "</td></tr>";
            }
        }

        protected void BtnInOutbox_Click(object sender, EventArgs e)
        {
            if ((sender as Button).Text == "View Sent Messages")
            {   //Figure out why this is only showing the most recently sent message!
                msgs = Messenger.GetMessages(account.Username, "send");
                LoadMessages(msgs);
                BtnInOut.Text = "View Recieved Messages";
                lblInOut.Text = "Outbox:";
            }
            else
            {
                msgs = Messenger.GetMessages(account.Username, "recieve");
                LoadMessages(msgs);
                BtnInOut.Text = "View Sent Messages";
                lblInOut.Text = "Inbox:";
            }
        }
        protected void BtnCompose_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Management/ComposeMessage.aspx");
        }
    }
}