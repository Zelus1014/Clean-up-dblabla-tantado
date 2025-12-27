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
    public partial class dashboard : Form
    {
        public dashboard()
        {
            InitializeComponent();
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            dash.Visible = true;
            cleanupd.Visible = false;
            myCleanups.Visible = false;
            trashtypes.Visible = false;
            volun.Visible = false;
            adminm.Visible = false;
            sett.Visible = false;
            helpsupport.Visible = false;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            dash.Visible = false;
            cleanupd.Visible = true;
            myCleanups.Visible = false;
            trashtypes.Visible = false;
            volun.Visible = false;
            adminm.Visible = false;
            sett.Visible = false;
            helpsupport.Visible = false;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            dash.Visible = false;
            cleanupd.Visible = false;
            myCleanups.Visible = true;
            trashtypes.Visible = false;
            volun.Visible = false;
            adminm.Visible = false;
            sett.Visible = false;
            helpsupport.Visible = false;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            dash.Visible = false;
            cleanupd.Visible = false;
            myCleanups.Visible = false;
            trashtypes.Visible = true;
            volun.Visible = false;
            adminm.Visible = false;
            sett.Visible = false;
            helpsupport.Visible = false;
        }

        private void button20_Click(object sender, EventArgs e)
        {
            dash.Visible = false;
            cleanupd.Visible = false;
            myCleanups.Visible = false;
            trashtypes.Visible = false;
            volun.Visible = true;
            adminm.Visible = false;
            sett.Visible = false;
            helpsupport.Visible = false;
        }

        private void button21_Click(object sender, EventArgs e)
        {
            dash.Visible = false;
            cleanupd.Visible = false;
            myCleanups.Visible = false;
            trashtypes.Visible = false;
            volun.Visible = false;
            adminm.Visible = true;
            sett.Visible = false;
            helpsupport.Visible = false;
        }

        private void button22_Click(object sender, EventArgs e)
        {
            dash.Visible = false;
            cleanupd.Visible = false;
            myCleanups.Visible = false;
            trashtypes.Visible = false;
            volun.Visible = false;
            adminm.Visible = false;
            sett.Visible = true;
            helpsupport.Visible = false;
        }

        private void button30_Click(object sender, EventArgs e)
        {
            dash.Visible = false;
            cleanupd.Visible = false;
            myCleanups.Visible = false;
            trashtypes.Visible = false;
            volun.Visible = false;
            adminm.Visible = false;
            sett.Visible = false;
            helpsupport.Visible = true;
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void claenupd_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
