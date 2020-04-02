
using Group4_Project.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group4_Project.DAL
{
    class GenreDAO : DAO
    {
        public static DataTable getAllGenres()
        {
            String sql = "SELECT * FROM Genres";
            return DAO.GetDataTable(sql);
        }
    }
}
