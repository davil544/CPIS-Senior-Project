using System;
using System.Web.UI;
using System.Net.Mail;

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
            try
            {
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress("blacknationanimation@gmail.com");
                mailMessage.To.Add("blacknationanimation@gmail.com");
                mailMessage.Subject = txtSubject.Text;
                mailMessage.Body = "<b>Sender Name : </b>" + txtName.Text + "<br/>"
                    + "<b>Sender Email : </b>" + txtEmail.Text + "<br/>"
                    + "<b>Comments : </b>" + txtComments.Text;
                mailMessage.IsBodyHtml = true;


                SmtpClient smtpClient = new SmtpClient("smtpClient.gmail.com", 587);
                smtpClient.EnableSsl = true;
                smtpClient.Credentials = new System.Net.NetworkCredential("blacknationanimation@gmail.com", "joeene2003");
                smtpClient.Send(mailMessage);

                Label1.ForeColor = System.Drawing.Color.Blue;
                Label1.Text = "Thank You For The Feedback";

                txtName.Enabled = false;
                txtEmail.Enabled = false;
                txtComments.Enabled = false;
                txtSubject.Enabled = false;
                Button1.Enabled = false;
            }
            catch(Exception ex) 
            {
            //Log - Event View or Table

                Label1.ForeColor = System.Drawing.Color.Blue;
                 Label1.ForeColor = System.Drawing.Color.DarkRed;
                Label1.Text = "Unfortunatly there was an error on our end, Try again later";
            }
        }
    }
}