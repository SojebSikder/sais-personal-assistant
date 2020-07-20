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
namespace Voice_Recognition
{
    public partial class note : Form
    {
        Data data = new Data();
        public note()
        {
            InitializeComponent();
        }

        private void txtClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtAdd_Click(object sender, EventArgs e)
        {
            try
            {

                data.Note = txtNote.Text;



                XmlManager.XmlDataWriter(data, "note.xml");
                MessageBox.Show("data successfully saved!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.ToString());
            }
        }

        private void note_Load(object sender, EventArgs e)
        {
            txtNote.Focus();
            if (File.Exists("note.xml"))
            {
                data = XmlManager.XmlDataReader("note.xml");

                txtNote.Text = data.Note;

            }
        }
    }
}
