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
            panel19.Visible = false;
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

        private void volun_Paint(object sender, PaintEventArgs e)
        {

        }

        private void trashtypes_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button31_Click(object sender, EventArgs e)
        {
            panel42.Visible = true;
            panel36.Visible = false;
            panel38.Visible = false;
            panel37.Visible = false;
            panel58.Visible = false;
            panel59.Visible = false;
            panel52.Visible = false;
            panel53.Visible = false;
            panel50.Visible = false;
            panel51.Visible = false;
        }

        private void button36_Click(object sender, EventArgs e)
        {
            panel37.Visible = false;
        }

        private void button37_Click(object sender, EventArgs e)
        {
            panel37.Visible = false;
        }

        private void button38_Click(object sender, EventArgs e)
        {
            panel37.Visible = true;
        }

        private void button35_Click(object sender, EventArgs e)
        {
            panel36.Visible = true;
            panel38.Visible = true; 
            panel42.Visible = false;
            panel37.Visible = false;
            panel58.Visible = false;
            panel59.Visible = false;
            panel52.Visible = false;
            panel53.Visible = false;
            panel50.Visible = false;
            panel51.Visible = false;
        }

        private void button34_Click(object sender, EventArgs e)
        {
            panel58.Visible = true;
            panel42.Visible = false;
            panel36.Visible = false;
            panel38.Visible = false;
            panel37.Visible = false;
            panel59.Visible = false;
            panel52.Visible = false;
            panel53.Visible = false;
            panel50.Visible = false;
            panel51.Visible = false;
        }

        private void button33_Click(object sender, EventArgs e)
        {
            panel52.Visible = true;
            panel42.Visible = false;
            panel36.Visible = false;
            panel38.Visible = false;
            panel37.Visible = false;
            panel58.Visible = false;
            panel59.Visible = false;
            panel53.Visible = false;
            panel50.Visible = false;
            panel51.Visible = false;
        }

        private void button47_Click(object sender, EventArgs e)
        {
            panel59.Visible = true;
        }

        private void button45_Click(object sender, EventArgs e)
        {
            panel59.Visible = false;
        }

        private void button46_Click(object sender, EventArgs e)
        {
            panel59.Visible = false;
        }

        private void button44_Click(object sender, EventArgs e)
        {
            panel53.Visible = true;
        }

        private void button42_Click(object sender, EventArgs e)
        {
            panel53.Visible = false;
        }

        private void button43_Click(object sender, EventArgs e)
        {
            panel53.Visible = false;
        }

        private void button32_Click(object sender, EventArgs e)
        {
            panel50.Visible = true;
            panel42.Visible = false;
            panel36.Visible = false;
            panel38.Visible = false;
            panel37.Visible = false;
            panel58.Visible = false;
            panel59.Visible = false;
            panel52.Visible = false;
            panel53.Visible = false;
            panel51.Visible = false;
        }

        private void button41_Click(object sender, EventArgs e)
        {
            panel51.Visible = true;
        }

        private void button39_Click(object sender, EventArgs e)
        {
            panel51.Visible = false;
        }

        private void button40_Click(object sender, EventArgs e)
        {
            panel51.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel19.Visible = true;
            panel42.Visible = true;    
        }

        private void button29_Click(object sender, EventArgs e)
        {
            panel19.Visible = false;
        }

        private void panel36_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
