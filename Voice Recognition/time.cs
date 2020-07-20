using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Voice_Recognition
{
    public partial class time : Form
    {
        int mov;
        int movX;
        int movY;

        string timeDate;
        public time(string TimeDate)
        {
            timeDate = TimeDate;
            InitializeComponent();
        }

        private void time_Load(object sender, EventArgs e)
        {
            label1.Text = timeDate;
            timer1.Start();
        }

        private void time_MouseDown(object sender, MouseEventArgs e)
        {
            mov = 1;
            movX = e.X;
            movY = e.Y;
        }

        private void time_MouseMove(object sender, MouseEventArgs e)
        {
            if (mov == 1)
            {

                this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movY);
            }
        }

        private void time_MouseUp(object sender, MouseEventArgs e)
        {
            mov = 0;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
