using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Q1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            loadData();
        }

        public void loadData()
        {
            String strconn = ConfigurationManager.ConnectionStrings["RN292_18Fall_B5ConnectionString"].ConnectionString;
            SqlConnection conn = new SqlConnection(strconn);

            SqlCommand cmd = new SqlCommand("select member_no, lastname, firstname, region_name from member, region where region.region_no = member.region_no", conn);

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);
            DataView dv = new DataView(dt);

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = dt;


        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            int count = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    count++;
                    string idToDelete = row.Cells["member_no"].Value.ToString();
                    String strconn = ConfigurationManager.ConnectionStrings["RN292_18Fall_B5ConnectionString"].ConnectionString;
                    SqlConnection conn = new SqlConnection(strconn);

                    SqlCommand cmd = new SqlCommand("DELETE from member where member_no = @n", conn);
                    cmd.Parameters.AddWithValue("@n", idToDelete);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            MessageBox.Show("Deleted "+count+" members");
            loadData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {        
            if (dataGridView1.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                formEdit formEdit = new formEdit(int.Parse(dataGridView1.Rows[e.RowIndex].Cells["member_no"].Value.ToString()));
                if (formEdit.ShowDialog() == DialogResult.OK)
                {
                    loadData();
                }
            }
           
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            loadData();
        }
    }
}
