using Group4_Project.DAL;
using Group4_Project.DTL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group4_Project.DAL
{
    class OrderDAO : DAO
    {
        public static bool Insert(Order o)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO orders (OrderDate, FirstName, LastName, Address, City, " +
                "State, Country, Phone, Email, Total) VALUES( @od, @fn, @ln, @ad, @ci, @st, @co, @p, @e, @t)");
            cmd.Parameters.AddWithValue("@od", o.orderDate);
            cmd.Parameters.AddWithValue("@fn", o.firstname);
            cmd.Parameters.AddWithValue("@ln", o.lastname);
            cmd.Parameters.AddWithValue("@ad", o.address);
            cmd.Parameters.AddWithValue("@ci", o.city);
            cmd.Parameters.AddWithValue("@st", o.state);
            cmd.Parameters.AddWithValue("@co", o.country);
            cmd.Parameters.AddWithValue("@p", o.phone);
            cmd.Parameters.AddWithValue("@e", o.email);
            cmd.Parameters.AddWithValue("@t", o.total);
            return DAO.UpdateTable(cmd);
        }

        public static int getIDMax()
        {
            String sql = "SELECT max(orderid) from Orders";
            try
            {
                DataTable dt = DAO.GetDataTable(sql);
                foreach (DataRow rd in dt.Rows)
                {
                    return int.Parse(rd[0].ToString());
                }
            }catch(Exception ex)
            {
                return -1;
            }
            
            return -1;
        }
    }
}
