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
    public partial class formEdit : Form
    {
        int memberid;
        public formEdit()
        {
            InitializeComponent();
        }

        public formEdit(int memberid)  : this()
        {
            this.memberid = memberid;
            String strconn = ConfigurationManager.ConnectionStrings["RN292_18Fall_B5ConnectionString"].ConnectionString;
            SqlConnection conn = new SqlConnection(strconn);
            SqlCommand cmd = new SqlCommand("Select lastname, firstname, issue_dt, expr_dt from member where member_no = " + memberid, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);

            foreach(DataRow rd in dt.Rows)
            {
                txtFirstName.Text = rd[1].ToString();
                txtLastName.Text = rd[0].ToString();
                dateTimePicker1.Value = DateTime.Parse(rd[2].ToString());
                dateTimePicker2.Value = DateTime.Parse(rd[3].ToString());
            }
        }

        private void btEditInfo_Click(object sender, EventArgs e)
        {
            String fName = txtFirstName.Text;
            String lName = txtLastName.Text;
            DateTime issueDate = dateTimePicker1.Value;
            DateTime expireDate = dateTimePicker2.Value;
            if(fName == "" || lName == "" || issueDate > expireDate)
            {
                MessageBox.Show("Input Error");
                return;
            }
            String strconn = ConfigurationManager.ConnectionStrings["RN292_18Fall_B5ConnectionString"].ConnectionString;
            SqlConnection conn = new SqlConnection(strconn);

            SqlCommand cmd = new SqlCommand("UPDATE member SET lastname = @ln, firstname = @fn , issue_dt = @id, expr_dt = @ed WHERE member_no = @n", conn);
            cmd.Parameters.AddWithValue("@ln", txtLastName.Text);
            cmd.Parameters.AddWithValue("@fn", txtFirstName.Text);
            cmd.Parameters.AddWithValue("@id", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@ed", dateTimePicker2.Value);
            cmd.Parameters.AddWithValue("@n", memberid);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            MessageBox.Show("Edit sucessfully");
           // m.loadData();
            this.Close();
        }
    }
}
