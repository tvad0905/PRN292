using Group4_Project.DAL;
using Group4_Project.DTL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Group4_Project.DAL
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
        public static DataTable getLogUser(String usn, String ps)
        {
            String sql = "Select * from [User] where UserName = '" + usn + "' and Password = '" + ps + "'";
            return DAO.GetDataTable(sql);
        }

        public static bool insertRegister(TextBox[] t1, TextBox[] t2)
        {
            // only auto for guest user 

            String sql = "INSERT INTO [dbo].[User]" + Environment.NewLine +
    "           ([UserName]" + Environment.NewLine +
    "           ,[Password]" + Environment.NewLine +
    "           ,[FirstName]" + Environment.NewLine +
    "           ,[LastName]" + Environment.NewLine +
    "           ,[Address]" + Environment.NewLine +
    "           ,[City]" + Environment.NewLine +
    "           ,[State]" + Environment.NewLine +
    "           ,[Country]" + Environment.NewLine +
    "           ,[Phone]" + Environment.NewLine +
    "           ,[Email]" + Environment.NewLine +
    "           ,[type])" + Environment.NewLine +
    "     VALUES" + Environment.NewLine +
    "           (@UserN ,@Psw,@fN,@lN,@addr,@city,@state ,@country,@phone,@email, 1)";
            SqlCommand com = new SqlCommand(sql);
            com.Parameters.AddWithValue("@UserN", t1[0].Text);
            com.Parameters.AddWithValue("@Psw", t1[1].Text);
            com.Parameters.AddWithValue("@fN", t1[2].Text);
            com.Parameters.AddWithValue("@lN", t1[3].Text);
            com.Parameters.AddWithValue("@email", t1[4].Text);

            if (t2[0].Text == string.Empty)
            {
                com.Parameters.AddWithValue("@addr", DBNull.Value);
            }
            else
            {
                com.Parameters.AddWithValue("@addr", t2[0].Text);

            }


            if (t2[1].Text == string.Empty)
            {
                com.Parameters.AddWithValue("@city", DBNull.Value);
            }
            else
            {
                com.Parameters.AddWithValue("@city", t2[1].Text);

            }


            if (t2[2].Text == string.Empty)
            {
                com.Parameters.AddWithValue("@state", DBNull.Value);
            }
            else
            {
                com.Parameters.AddWithValue("@state", t2[2].Text);

            }


            if (t2[3].Text == string.Empty)
            {
                com.Parameters.AddWithValue("@country", DBNull.Value);
            }
            else
            {
                com.Parameters.AddWithValue("@country", t2[3].Text);

            }


            if (t2[4].Text == string.Empty)
            {
                com.Parameters.AddWithValue("@phone", DBNull.Value);
            }
            else
            {
                com.Parameters.AddWithValue("@phone", t2[4].Text);

            }

            return DAO.UpdateTable(com);
        }

        public static bool checkUsername(String username)
        {
            String sql = "Select * from [User] where UserName = '" + username +"'";
            DataTable dt = DAO.GetDataTable(sql);
            return dt.Rows.Count == 0 ? true : false;
        }

    }
}
