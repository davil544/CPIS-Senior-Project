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
            msg.MessageContents = "Subject:"+txtSubject.Text+ "<br />"+
                "Message:"+txtComments.Text;
            
            
            lblMessage.Text = Messenger.SendMessage(msg);



        }
    }
}