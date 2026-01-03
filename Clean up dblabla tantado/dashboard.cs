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
            panel81.Visible = false;
            panel68.Visible = false;
            panel75.Visible = false;
            panel69.Visible = false;
            panel70.Visible = false;
            panel65.Visible = false;
            panel66.Visible = false;
            panel64.Visible = false;
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

        private void panel69_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button55_Click(object sender, EventArgs e)
        {
            panel80.Visible = true;
            panel82.Visible = true;
            panel81.Visible = false;
            panel68.Visible = false;
            panel75.Visible = false;
            panel69.Visible = false;
            panel70.Visible = false;
            panel65.Visible = false;
            panel66.Visible = false;
        }

        private void button54_Click(object sender, EventArgs e)
        {
            panel80.Visible = false;
            panel82.Visible = false;
            panel81.Visible = false;
            panel68.Visible = true;
            panel75.Visible = false;
            panel69.Visible = false;
            panel70.Visible = false;
            panel65.Visible = false;
            panel66.Visible = false;
        }

        private void button53_Click(object sender, EventArgs e)
        {
            panel80.Visible = false;
            panel82.Visible = false;
            panel81.Visible = false;
            panel68.Visible = false;
            panel75.Visible = false;
            panel69.Visible = true;
            panel70.Visible = false;
            panel65.Visible = false;
            panel66.Visible = false;
        }

        private void button52_Click(object sender, EventArgs e)
        {
            panel80.Visible = false;
            panel82.Visible = false;
            panel81.Visible = false;
            panel68.Visible = false;
            panel75.Visible = false;
            panel69.Visible = false;
            panel70.Visible = false;
            panel65.Visible = true;
            panel66.Visible = false;
        }

        private void button62_Click(object sender, EventArgs e)
        {
            panel81.Visible = true;
        }

        private void button63_Click(object sender, EventArgs e)
        {
            panel81.Visible = false;
        }

        private void button64_Click(object sender, EventArgs e)
        {
            panel81.Visible = false;
        }

        private void button50_Click(object sender, EventArgs e)
        {
            panel66.Visible = true;
        }

        private void button48_Click(object sender, EventArgs e)
        {
            panel66.Visible = false;
        }

        private void button49_Click(object sender, EventArgs e)
        {
            panel66.Visible = false;
        }

        private void button59_Click(object sender, EventArgs e)
        {
            panel75.Visible = true;
        }

        private void button60_Click(object sender, EventArgs e)
        {
            panel75.Visible = false;
        }

        private void button61_Click(object sender, EventArgs e)
        {
            panel75.Visible = false;
        }

        private void button56_Click(object sender, EventArgs e)
        {
            panel70.Visible = true;
        }

        private void button57_Click(object sender, EventArgs e)
        {
            panel70.Visible = false;
        }

        private void button58_Click(object sender, EventArgs e)
        {
            panel70.Visible = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            panel64.Visible = true;
        }

        private void button51_Click(object sender, EventArgs e)
        {
            panel64.Visible=false;
        }

        private void button65_Click(object sender, EventArgs e)
        {
            Add_New_Cleanup1 nextForm = new Add_New_Cleanup1();
            nextForm.Show();     
                   

        }

        private void dashboard_Load(object sender, EventArgs e)
        {

        }
    }
}

