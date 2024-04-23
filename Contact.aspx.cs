using System;
using System.Web.UI;
using CPIS_Senior_Project.DataAccessLayer;
using CPIS_Senior_Project.DataModels;


namespace CPIS_Senior_Project
{
    public partial class Contact : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Login"] != null && (bool)Session["Login"] == true)
            {
                Account user = (Account)Session["Account"];
                txtName.Text = user.Username;
                txtName.Enabled = false;
                txtEmail.Text = "N/A";
                txtEmail.Enabled = false;
                RegularExpressionValidator1.Enabled = false;
            }
        }

        protected void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           // Get form data
            Message msg = new Message();
            msg.Sender = txtName.Text;
            msg.Recipient = "Admin";
            if (Session["Login"] == null)
            {
                msg.MessageContents = "Email:&nbsp;" + txtEmail.Text + "<br />";
            }
            msg.MessageContents += "Subject:&nbsp;"+txtSubject.Text+ "<br />"+
                "Message:&nbsp;"+txtComments.Text;
            
            
            lblMessage.Text = Messenger.SendMessage(msg);



        }
    }
}