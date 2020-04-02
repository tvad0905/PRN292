using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group4_Project.DTL
{
    public class Album
    {
        private int albumid;

        public int Albumid
        {
            get { return albumid; }
        }
        
        private string title;

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        private int genreid;

        public int Genreid
        {
            get { return genreid; }
            set { genreid = value; }
        }

        private int artistid;

        public int Artistid
        {
            get { return artistid; }
            set { artistid = value; }
        }

        private float price;

        public float Price
        {
            get { return price; }
            set { price = value; }
        }

        private string albumUrl;

        public string AlbumUrl
        {
            get { return albumUrl; }
            set { albumUrl = value; }
        }

        public Album(int albumid, int genreid, int artistid, String title, float price, String albumUrl)
        {
            this.albumid = albumid;
            this.genreid = genreid;
            this.artistid = artistid;
            this.title = title;
            this.price = price;
            this.albumid = albumid;          
        }

        public Album(int albumid,String title, float price, String albumUrl)
        {
            this.albumid = albumid;
            this.title = title;
            this.price = price;
            this.albumid = albumid;
        }

    }
        
}
