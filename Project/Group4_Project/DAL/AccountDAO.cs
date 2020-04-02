using Group4_Project.DAL;
using Lab3.DTL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.DAL
{
    class AccountDAO : DAO
    {
        public static bool UpdateAccount(Account a)
        {
            SqlCommand cmd = new SqlCommand("  UPDATE [User] SET FirstName = @fn, LastName = @ln , [Address] = @ad," +
                " City = @ci, [State] = @s , Country = @co , Phone = @p, Email = @e WHERE id = @id ");
            cmd.Parameters.AddWithValue("@fn", a.firstname);
            cmd.Parameters.AddWithValue("@ln", a.lastname);
            cmd.Parameters.AddWithValue("@ad", a.address);
            cmd.Parameters.AddWithValue("@ci", a.city);
            cmd.Parameters.AddWithValue("@s", a.state);
            cmd.Parameters.AddWithValue("@co", a.country);
            cmd.Parameters.AddWithValue("@p", a.phone);
            cmd.Parameters.AddWithValue("@e", a.email);
            cmd.Parameters.AddWithValue("@id", a.id);
            return DAO.UpdateTable(cmd);
        }
    }
}
