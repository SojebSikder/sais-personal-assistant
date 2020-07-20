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

namespace Voice_Recognition
{
    public partial class download : Form
    {
        public download()
        {
            InitializeComponent();
        }

        private void download_Load(object sender, EventArgs e)
        {
           

        }

        void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            MessageBox.Show("Download completed");
        }

        void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar1.Maximum = (int)e.TotalBytesToReceive / 100;
            progressBar1.Value = (int)e.TotalBytesToReceive / 100;
           
        }

        private void btn_download_Click(object sender, EventArgs e)
        {
            WebClient client = new WebClient();
            client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
            client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
            //client.DownloadFileAsync(new Uri("https://sojebsoftware.000webhostapp.com/index_files/sw.zip"), @"c:\users\sojeb sikder\Desktop\sw.zip");

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "All Files (*.*)|*.*";
           
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                client.DownloadFileAsync(new Uri(texturl.Text), sfd.FileName);
                

            }
        }
    }
}
