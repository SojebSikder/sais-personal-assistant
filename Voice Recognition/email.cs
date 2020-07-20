using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace Voice_Recognition
{
    public partial class email : Form
    {
        NetworkCredential login;
        SmtpClient client;
        MailMessage msg;

        public email()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void email_Load(object sender, EventArgs e)
        {

        }

        private void btn_Send_Click(object sender, EventArgs e)
        {
            login = new NetworkCredential(textUsername.Text, textPassword.Text);
            client = new SmtpClient(textSmtp.Text);
            client.Port = Convert.ToInt32(textPort.Text);
            client.EnableSsl = checkBoxSSl.Checked;
            client.Credentials = login;
            msg = new MailMessage { From = new MailAddress(textUsername.Text + textSmtp.Text.Replace("smtp", "@"), "Sojeb", Encoding.UTF8) };
            msg.To.Add(new MailAddress(textTo.Text));
            if (!string.IsNullOrEmpty(textCC.Text))
                msg.To.Add(new MailAddress(textCC.Text));
            msg.Subject = textSub.Text;
            msg.Body = textMes.Text;
            msg.BodyEncoding = Encoding.UTF8;
            msg.IsBodyHtml = true;
            msg.Priority = MailPriority.Normal;
            msg.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
            client.SendCompleted += new SendCompletedEventHandler(SendCompletedCallback);
            string userstate = "Sending...";
            client.SendAsync(msg,userstate);

        }
        private static void SendCompletedCallback(Object sender, AsyncCompletedEventArgs e)
        {
            if (e.Cancelled)
                MessageBox.Show(string.Format("{0 send canceled.",e.UserState),"Message",MessageBoxButtons.OK,MessageBoxIcon.Information);
            if (e.Error != null)
                MessageBox.Show(string.Format("{0} {1}", e.UserState), "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Your message has beeen sent.","Message",MessageBoxButtons.OK,MessageBoxIcon.Information);

        }
    }
}
