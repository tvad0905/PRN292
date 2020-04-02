using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group4_Project.DTL
{
    class Genres
    {
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string description;

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public Genres(int genreid, string name, string description)
        {
            this.id = genreid;
            this.name = name;
            this.description = description;
        }
    }
}
