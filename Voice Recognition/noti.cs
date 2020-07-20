using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Voice_Recognition
{
    public partial class noti : UserControl
    {
        public noti()
        {
            InitializeComponent();
        }

        private void noti_Load(object sender, EventArgs e)
        {

        }
        public noti(string message, msgtype messagetype)
        {
            InitializeComponent();

            // Set the text in the bubble from the message in the parameter.
            lblmessage.Text = message;

            // Change Color based on Message type.
            if (messagetype.ToString() == "In")
            {
                // incoming User message
                this.BackColor = Color.Gray;
            }
            else
            {
                // Outgoing Bot Message
                this.BackColor = Color.FromArgb(0, 164, 147); 
            }
            Setheight();
        }


        // Sets Bubble height based on the message length.
        void Setheight()
        {
            // resize the bubble after its been called
            Graphics g = CreateGraphics();
            SizeF size = g.MeasureString(lblmessage.Text, lblmessage.Font, lblmessage.Width);

            // Set the height for the bubble
            lblmessage.Height = int.Parse(Math.Round(size.Height + 2, 0).ToString());
        }

        // Call this function when shit is getting resized
        // Not sure if its neccessary.
        private void bubble_Resize(object sender, EventArgs e)
        {
            Setheight();
        }

        private void lblmessage_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
                
        }
    }

    // Make a custom enumeration to easily determine in and out messages so we can set the color
    public enum msgtype
    {
        In,
        Out
    }
    }

