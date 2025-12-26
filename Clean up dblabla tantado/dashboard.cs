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
        cleanupdata cdata = new cleanupdata();
        mycleanups mc = new mycleanups();
        trash trash = new trash();
        volunteers vol = new volunteers();
        admin admin = new admin();
        settings settings = new settings();
        help help = new help();
        public dashboard()
        {
            InitializeComponent();
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel19.Visible = true;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            cdata.Show();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            mc.Show();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            trash.Show();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            vol.Show(); 
        }

        private void button21_Click(object sender, EventArgs e)
        {
            admin.Show();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            settings.Show();
        }

        private void button30_Click(object sender, EventArgs e)
        {
            help.Show();
        }
    }
}
