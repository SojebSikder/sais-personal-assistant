using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.Win32;
namespace Voice_Recognition
{
    public partial class Setting : Form
    {
        Data data = new Data();
        public Setting()
        {
            InitializeComponent();
        }
        public object XmlFileManager { get; private set; }

        private void Setting_Load(object sender, EventArgs e)
        {
           // textVoice.Text = Properties.Settings.Default.Voice;
           // text.Text = Properties.Settings.Default.Name;
            if (File.Exists("data.xml"))
            {
                data = XmlManager.XmlDataReader("data.xml");
               
                Stext.Text = data.Name;
                
            }
        }

        

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Properties.Settings.Default.Name = text.Text;
           // Properties.Settings.Default.Save();
            try
            {
               
                data.Name = Stext.Text;
               
               

                XmlManager.XmlDataWriter(data, "data.xml");
                MessageBox.Show("data successfully saved!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.ToString());
            }

           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void Stext_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnstartUp_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                RegistryKey reg = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                reg.SetValue("sojeb assistant", Application.ExecutablePath.ToString());
                MessageBox.Show("You have been successfully saved", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                RegistryKey reg = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                // reg.SetValue("sojeb assistant", Application.ExecutablePath.ToString());
                reg.DeleteValue("sojeb assistant");
                MessageBox.Show("Delete successfully saved", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
