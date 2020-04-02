using Group4_Project.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group4_Project.DAL
{
    class ArtistDAO : DAO
    {
        public static DataTable getAllArtist()
        {
            String sql = "SELECT * FROM Artists";
            return DAO.GetDataTable(sql);
        }
    }
}
