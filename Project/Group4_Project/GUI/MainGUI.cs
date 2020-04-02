using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Group4_Project.GUI
{
    public partial class MainGUI : Form
    {
        public MainGUI()
        {
            InitializeComponent();
            embed(toolStripContainer1.ContentPanel, new AboutGUI());
        }

        private void bookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AlbumGUI f = new AlbumGUI();
            embed(toolStripContainer1.ContentPanel, f);

        }
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutGUI f = new AboutGUI();
            embed(toolStripContainer1.ContentPanel, f);
        }


        private void embed(Panel panel, Form f)
        {
            panel.Controls.Clear();
            f.FormBorderStyle = FormBorderStyle.None;
            f.TopLevel = false;
            f.Show();

            panel.Controls.Add(f);

        }

        private void memberToolStripMenuItem_Click(object sender, EventArgs e)
        {
          //  BorrowerGUI m = new BorrowerGUI();
           // embed(toolStripContainer1.ContentPanel, m);
        }

        private void borrowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //BorrowGUI m = new BorrowGUI();
            //embed(toolStripContainer1.ContentPanel, m);
        }

        private void returnToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // ReturnGUI m = new ReturnGUI();
           // embed(toolStripContainer1.ContentPanel, m);
        }

        private void reserveToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // ReserveGUI m = new ReserveGUI();
           // embed(toolStripContainer1.ContentPanel, m);
        }
    }
}
