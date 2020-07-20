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


namespace Voice_Recognition
{
    public partial class commandText : Form
    {
        MySqlConnection con = new MySqlConnection("server=remotemysql.com;user id=mzBXch0LSO;password =Qz0NXr8Dt8 ;database=mzBXch0LSO;allowuservariables=True");
        database.database db = new database.database();

        
        public commandText()
        {
            InitializeComponent();
        }

        private void commandText_Load(object sender, EventArgs e)
        {
            try
            {


                string MyConnection2 = "server=remotemysql.com;user id=mzBXch0LSO;password =Qz0NXr8Dt8 ;database=mzBXch0LSO;allowuservariables=True";
                //Display query  
                string Query = "select * from voice;";
                MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                //  MyConn2.Open();  
                //For offline connection we weill use  MySqlDataAdapter class.  
                MySqlDataAdapter MyAdapter = new MySqlDataAdapter();
                MyAdapter.SelectCommand = MyCommand2;
                DataTable dTable = new DataTable();
                MyAdapter.Fill(dTable);
                dataGridView1.DataSource = dTable; // here i have assign dTable object to the dataGridView1 object to display data.               
                // MyConn2.Close();  
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }  
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cmd.add add = new cmd.add();
            add.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >=0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                txtID.Text = row.Cells["id"].Value.ToString();
                txtCmd.Text = row.Cells["text"].Value.ToString();
                txtRes.Text = row.Cells["response"].Value.ToString();
                
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
           
            try
            {
                

                //This is my connection string i have assigned the database file address path  
                string MyConnection2 = "server=remotemysql.com;user id=mzBXch0LSO;password =Qz0NXr8Dt8 ;database=mzBXch0LSO;allowuservariables=True";
                //This is my update query in which i am taking input from the user through windows forms and update the record.  
                string Query = "update voice set text='" + txtCmd.Text + "',response='" + txtRes.Text + "'  where id='" + txtID.Text + "';";
                //This is  MySqlConnection here i have created the object and pass my connection string.  
                MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                MySqlCommand MyCommand2 = new MySqlCommand(Query, con);
                MySqlDataReader MyReader2;
                con.Open();
                MyReader2 = MyCommand2.ExecuteReader();
                MessageBox.Show("Updated Data Successfully");
                while (MyReader2.Read())
                {
                }
                con.Close();//Connection closed here  
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }  
           

           
            
            
           
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
             try
            {
                string MyConnection2 = "server=remotemysql.com;user id=mzBXch0LSO;password =Qz0NXr8Dt8 ;database=mzBXch0LSO;allowuservariables=True";
                //string Query = "delete from student.studentinfo where idStudentInfo='" + this.IdTextBox.Text + "';";
                MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                MySqlCommand MyCommand2 = new MySqlCommand("delete from voice where id='"+txtID.Text+"'", con);
                MySqlDataReader MyReader2;
                con.Open();
                MyReader2 = MyCommand2.ExecuteReader();
                MessageBox.Show("Deleted Data Successfully");
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        }
        /*
         *  string source = "server=localhost;user id=root;database=test;allowuservariables=True";

            MySqlConnection con = new MySqlConnection(source);
            con.Open();
           // MessageBox.Show("Connected");

            string query = "select * from voice where id="+int.Parse(txtID.Text);
            MySqlCommand cmd = new MySqlCommand(query,con);

            MySqlDataReader dr = cmd.ExecuteReader();
            if(dr.Read())
            {
                txtCmd.Text = (dr["text"].ToString());
                txtRes.Text = (dr["response"].ToString());
            }
            con.Close();
         * */
    }

