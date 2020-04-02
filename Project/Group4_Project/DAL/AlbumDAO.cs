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
    class AlbumDAO : DAO
    {
        public static DataTable GetAlbum(int genreid, int artistid)
        {
            String sql = "SELECT albumid, title, price, albumurl FROM Albums";
            if(genreid != -1 && artistid != -1)
            {
                sql += " WHERE genreid = " + genreid + " and artistid = " + artistid;
            }else if(genreid == -1 && artistid == -1 )
            {
            }else if(artistid == -1)
            {
                sql += " WHERE genreid = " + genreid;
            }
            else
            {
                sql += " WHERE artistid = " + artistid;
            }
            return DAO.GetDataTable(sql);
        }
    }
}

