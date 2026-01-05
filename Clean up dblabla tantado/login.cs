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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
            panel1.Visible = false;
            panel3.Visible = false;
            button2.Enabled = false;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                button2.Enabled = true;
                button2.BackColor = Color.Black;
            }
            else
            {
                button2.Enabled = false;
                button2.BackColor = Color.Gray;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox6.Text) || //check for empty fields in registration
            string.IsNullOrEmpty(textBox4.Text) ||
            string.IsNullOrEmpty(textBox3.Text))
            {
                button2.Enabled = false;
                button2.BackColor = Color.Gray;
                MessageBox.Show("Please enter the correct username and password.");
                return;
            }
            else
            {
                button2.Enabled = true;
                button2.BackColor = Color.Black;
            }

            MessageBox.Show("You have successfully registered!");
            panel2.Visible = false;
            panel1.Visible = true;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panel3.Visible = true;
            panel1.Visible = false;
            panel2.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != textBox6.Text ||
                textBox5.Text != textBox3.Text)
            {
                MessageBox.Show("Please enter the correct information!");
                return;
            }
            else
            {
                dashboard dashboard = new dashboard();
                dashboard.Show();
                this.Hide();
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panel2.Visible = true;
            panel1.Visible = false;
            panel3.Visible = false;
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = false;
            panel3.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = false;
            panel3.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {

            panel1.Visible = true;
            panel2.Visible = false;
            panel3.Visible = false;
        }
    }
}
