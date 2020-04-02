using Group4_Project.DTL;
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
    public partial class MyCartGUI : Form
    {
        DataTable dt;
        public MyCartGUI()
        {
            InitializeComponent();
        }

        public MyCartGUI(DataTable dt) : this()
        {
            this.dt = dt;
            lbNumberCart.Text = dt.Rows.Count.ToString();
            dataGridView1.DataSource = dt;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                dataGridView1.Rows.RemoveAt(e.RowIndex);
                lbNumberCart.Text = (int.Parse(lbNumberCart.Text) - 1).ToString();
            }
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btPay_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Pay Successfull");
        }
    }
}
