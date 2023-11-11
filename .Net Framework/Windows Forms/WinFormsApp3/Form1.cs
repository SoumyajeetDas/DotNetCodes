using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp3
{
    public partial class Form1 : Form
    {
        string []month;
        public Form1()
        {
            InitializeComponent();
            month = new string[]{"January","February","March","April","May","June" };
        }

        private void comboBoxday_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Day");
        }

        private void comboBoxmonth_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxyear_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e) //Form1 Load means at the time when the Win Form will get loaded the inner code will carry on working
        {
            for (int i = 1; i < 31; i++)
            {
                comboBoxday.Items.Add(i);
            }

            for(int i =0;i<month.Length;i++)
            {
                comboBoxmonth.Items.Add(month[i]);
            }
            for (int i = 2000; i < 2021; i++)
            {
                comboBoxyear.Items.Add(i);
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = "Day : " + comboBoxday.SelectedItem.ToString() + " Month : " + comboBoxday.SelectedItem.ToString() + " Year : " + comboBoxyear.SelectedItem.ToString();

        }
    }
}
