using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clean_up_dblabla_tantado
{
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
            panel8.Visible = false;
            panel9.Visible = false;
            panel14.Visible = false;
            panel15.Visible = false;
            panel16.Visible = false;
            panel17.Visible = false;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            panel17.Visible = false;
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label74_Click(object sender, EventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {
            panel17.Visible = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel3.Visible = true; //show the waste data panel
            panel4.Visible = true; //show the waste data overview panel
            panel8.Visible = false;
            panel9.Visible = false;
            panel14.Visible = false;
            panel15.Visible = false;
            panel16.Visible = false;
            panel17.Visible = false;
            panel18.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel8.Visible = true; //show the volunteer panel
            panel3.Visible = false;
            panel4.Visible = false;
            panel9.Visible = false;
            panel14.Visible = false;
            panel15.Visible = false;
            panel16.Visible = false;
            panel17.Visible = false;
            panel18.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel18.Visible = true; //show the tools panel
            panel3.Visible = false;
            panel4.Visible = false;
            panel8.Visible = false;
            panel9.Visible = false;
            panel14.Visible = false;
            panel15.Visible = false;
            panel16.Visible = false;
            panel17.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel15.Visible = true; //show the timeline panel
            panel3.Visible = true;
            panel4.Visible = true;
            panel8.Visible = false;
            panel9.Visible = false;
            panel14.Visible = false;
            panel16.Visible = false;
            panel17.Visible = false;
            panel18.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel14.Visible = true;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            panel14.Visible = false;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            panel14.Visible = false;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            panel17.Visible = false;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            panel16.Visible = true;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            panel16.Visible = false;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            panel16.Visible = false;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            panel9.Visible = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            panel9.Visible = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            panel9.Visible = false;
        }
    }
}
