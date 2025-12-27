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
            cdata.Hide();
            mc.Hide();
            trash.Hide();
            vol.Hide();
            admin.Hide();
            settings.Hide();
            help.Hide();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            cdata.Show();
            mc.Hide();
            trash.Hide();
            vol.Hide();
            admin.Hide();
            settings.Hide();
            help.Hide();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            mc.Show();
            cdata.Hide();
            trash.Hide();
            vol.Hide();
            admin.Hide();
            settings.Hide();
            help.Hide();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            trash.Show();
            cdata.Hide();
            mc.Hide();
            vol.Hide();
            admin.Hide();
            settings.Hide();
            help.Hide();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            vol.Show();
            cdata.Hide();
            mc.Hide();
            trash.Hide();
            admin.Hide();
            settings.Hide();
            help.Hide();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            admin.Show();
            cdata.Hide();
            mc.Hide();
            trash.Hide();
            vol.Hide();
            settings.Hide();
            help.Hide();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            settings.Show();
            cdata.Hide();
            mc.Hide();
            trash.Hide();
            vol.Hide();
            admin.Hide();
            help.Hide();
        }

        private void button30_Click(object sender, EventArgs e)
        {
            help.Show();
            cdata.Hide();
            mc.Hide();
            trash.Hide();
            vol.Hide();
            admin.Hide();
            settings.Hide();
        }
    }
}
