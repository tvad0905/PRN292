using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group4_Project.DTL
{
    class Artists
    {
        private int artistid;

        public int Artistid
        {
            get { return artistid; }
            set { this.artistid = value; }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { this.name = value; }
        }

        public void Artist(int id, string name)
        {
            this.artistid = id;
            this.name = name;
        }
    }
}
