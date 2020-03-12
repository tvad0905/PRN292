using Lab3.DTL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.DAL
{
    class CopyDAO : DAO
    {
        public Copy GetCopy(int CopyNumber)
        {
            String sql = "SELECT * FROM Copy WHERE copyNumber =  " + CopyNumber;
            DataTable dt = GetDataTable(sql);
            foreach(DataRow row in dt.Rows)
            {
                Copy c = new Copy(CopyNumber, int.Parse(row["bookNumber"].ToString()), int.Parse(row["sequenceNumber"].ToString()), Char.Parse(row["type"].ToString()), int.Parse(row["price"].ToString()));
                return c;
            }
            return null;
        }

        public void Update(Copy c)
        {
            SqlCommand cmd = new SqlCommand("UPDATE Copy SET bookNumber = @bn, sequenceNumber = @sn, type = @t, price = @p WHERE copyNumber = @cn ");
            cmd.Parameters.AddWithValue("@bn", c.BookNumber);
            cmd.Parameters.AddWithValue("@sn", c.SequenceNumber);
            cmd.Parameters.AddWithValue("@t", c.Type);
            cmd.Parameters.AddWithValue("@p", c.Price);
            cmd.Parameters.AddWithValue("@cn", c.CopyNumber);
            UpdateTable(cmd);
        }

        public DataTable GetAllCopyByBookNumber(int bookNumber)
        {
            String sql = "SELECT * FROM Copy WHERE bookNumber = " + bookNumber;
            return GetDataTable(sql);
        } 
    }
}
