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
    class ReserveDAO : DAO
    {
        public bool Update(Reservation r)
        {

            String sql = "INSERT dbo.Reservation(Id,borrowerNumber,bookNumber,date, status)" + Environment.NewLine +
                          "VALUES( @Id,  @borrowerNumber, @bookNumber,  @date, @status )";
            SqlCommand com = new SqlCommand(sql);
            com.Parameters.AddWithValue("@Id", r.Id);
            com.Parameters.AddWithValue("@borrowerNumber", r.BorrowerNumber);
            com.Parameters.AddWithValue("@bookNumber", r.BookNumber);
            com.Parameters.AddWithValue("@date", r.Date);
            com.Parameters.AddWithValue("@status", r.Status);
            return UpdateTable(com);
        }
        public Reservation GetFirstReservation(int bookNumber)
        {
            String sql = "SELECT TOP (1) * FROM [Reservation] WHERE bookNumber = " + bookNumber + " ORDER BY date asc";
            DataTable dt = GetDataTable(sql);
            foreach (DataRow row in dt.Rows)
            {
                Reservation r = new Reservation(int.Parse(row["borrowerNumber"].ToString()), int.Parse(row["bookNumber"].ToString()), DateTime.Parse(row["date"].ToString()));
                return r;
            }
            return null;
        }

        public DataTable SelectDS(int borrowerNumber, char c)
        {
            String sql = "SELECT * FROM [Reservation] WHERE status = '"+c+"' and borrowerNumber = " + borrowerNumber;
            return GetDataTable(sql);
        }
    }
}
