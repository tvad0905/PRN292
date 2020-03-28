using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Q2
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                String strConn = ConfigurationManager.ConnectionStrings["PRN292_18Fall_B5ConnectionString"].ConnectionString;
                SqlConnection conn = new SqlConnection(strConn);
                SqlCommand cmd = new SqlCommand("SELECT region_no, region_name from region", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                da.Fill(dt);
                DropDownList1.DataSource = dt;
                DropDownList1.DataTextField = "region_name";
                DropDownList1.DataValueField = "region_no";
                DropDownList1.DataBind();
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        { 
            String strConn = ConfigurationManager.ConnectionStrings["PRN292_18Fall_B5ConnectionString"].ConnectionString;
            SqlConnection conn = new SqlConnection(strConn);
            SqlCommand cmd = new SqlCommand("SELECT corp_name, corp_no from corporation where region_no = @r", conn);
            cmd.Parameters.AddWithValue("@r", DropDownList1.SelectedValue);
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);
            DropDownList2.DataSource = dt;
            DropDownList2.DataTextField = "corp_name";
            DropDownList2.DataValueField = "corp_no";
            DropDownList2.DataBind();
        }

        protected void DropDownList1_DataBound(object sender, EventArgs e)
        {
         //   DropDownList1_SelectedIndexChanged(sender, e);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           // try
          //  {
                String strConn = ConfigurationManager.ConnectionStrings["PRN292_18Fall_B5ConnectionString"].ConnectionString;
                SqlConnection conn = new SqlConnection(strConn);
                SqlCommand cmd = new SqlCommand("INSERT INTO member(lastname, firstname, issue_dt, expr_dt, region_no, corp_no) VALUES (@ln, @fn, @id, @ex, @rn, @cn)", conn);
                cmd.Parameters.AddWithValue("@ln", txtLastName.Text);
                cmd.Parameters.AddWithValue("@fn", txtFirstName.Text);
                cmd.Parameters.AddWithValue("@id", DateTime.Now.AddDays(1));
                cmd.Parameters.AddWithValue("@ex", DateTime.Now.AddMonths(6).AddDays(1));
                cmd.Parameters.AddWithValue("@rn", DropDownList1.SelectedValue);
                cmd.Parameters.AddWithValue("@cn", DropDownList2.SelectedValue);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
           // }
           // catch
          //  {
             //   return;
           // }
            lbResult.Visible = true;
        }
    }
}