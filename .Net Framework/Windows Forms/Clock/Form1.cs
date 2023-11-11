using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clock
{
    public partial class Form1 : Form
    {
        int flag = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            labelclock.Text = DateTime.Now.ToString("hh : mm : ss");
        }

        private void labelclock_Click(object sender, EventArgs e)
        {
            
        }

        private void timer_tick(object sender, EventArgs e)  // To get this function add the function in the event at the right side in the properties of the timer
        {
            labelclock.Text = DateTime.Now.ToString("hh : mm : ss");
        }

        private void StartorStop_Click(object sender, EventArgs e)
        {
            if(flag==0)
            {
                timer1.Enabled = false;
                flag = 1;
                StartorStop.Text = "Start";
                StartorStop.BackColor = Color.LightSeaGreen;
            }
            else
            {
                timer1.Enabled = true;
                flag = 0;
                StartorStop.Text = "Stop";
                StartorStop.BackColor = Color.Red;
            }
        }
    }
}
