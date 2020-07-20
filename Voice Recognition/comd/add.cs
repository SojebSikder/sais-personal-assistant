using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MySql.Data.MySqlClient;

namespace Voice_Recognition.cmd
{
    public partial class add : Form
    {
        public add()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void add_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //This is my connection string i have assigned the database file address path  
                MySqlConnection con = new MySqlConnection("server=remotemysql.com;user id=mzBXch0LSO;password =Qz0NXr8Dt8 ;database=mzBXch0LSO;allowuservariables=True");
                //This is my insert query in which i am taking input from the user through windows forms  
                string Query = "insert into voice(text,response) values('" + txtCmd.Text + "','" + txtRes.Text +"');";
                //This is  MySqlConnection here i have created the object and pass my connection string.  
              //  MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                //This is command class which will handle the query and connection object.  
                MySqlCommand MyCommand2 = new MySqlCommand(Query, con);
                MySqlDataReader MyReader2;
                con.Open();
                MyReader2 = MyCommand2.ExecuteReader();     // Here our query will be executed and data saved into the database.  
                MessageBox.Show("Insert Data Successfully");
                while (MyReader2.Read())
                {
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }  
        }
    }
}
