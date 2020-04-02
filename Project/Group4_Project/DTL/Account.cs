using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group4_Project.DTL
{
    public class Account
    {
        public int id;
        public int Id
        {
            get { return id; }
            set { this.id = value; }
        }

        public string username, password;
        public string Username
        {
            get { return username; }
            set { this.username = value; }
        }
        public string Password { get => password; set => password = value; }

        public string firstname;
        public string Firstname
        {
            get { return firstname; }
            set { this.firstname = value; }
        }

        public string lastname;
        public string Lastname
        {
            get { return lastname; }
            set { this.lastname = value; }
        }

        public string address;
        public string Address
        {
            get { return address; }
            set { this.address = value; }
        }

        public string city;
        public string City
        {
            get { return city; }
            set { this.city = value; }
        }

        public string state;
        public string State
        {
            get { return state; }
            set { this.state = value; }
        }

        public string country;
        public string Country
        {
            get { return country; }
            set { this.country = value; }
        }

        public string phone;
        public string Phone
        {
            get { return phone; }
            set { this.phone = value; }
        }

        public string email;
        public string Email
        {
            get { return email; }
            set { this.email = value; }
        }

        public string type;
        public string Type
        {
            get { return type; }
            set { this.type = value; }
        }

        public  Account(int id, string firstname, string lastname, string address, 
            string city, string state, string country, string phone, string email, string type)
        {
            this.id = id;
            this.firstname = firstname;
            this.lastname = lastname;
            this.address = address;
            this.city = city;
            this.state = state;
            this.country = country;
            this.phone = phone;
            this.email = email;
            this.type = type;
        }
        public Account( string firstname, string lastname, string address,
            string city, string state, string country, string phone, string email, string type)
        {
            this.id = id;
            this.firstname = firstname;
            this.lastname = lastname;
            this.address = address;
            this.city = city;
            this.state = state;
            this.country = country;
            this.phone = phone;
            this.email = email;
            this.type = type;
        }

        public void setInfor(DataTable dt)
        {
            this.id = int.Parse(dt.Rows[0][0].ToString());
            this.username = dt.Rows[0][1].ToString();
            this.password = dt.Rows[0][2].ToString();
            this.firstname = dt.Rows[0][3].ToString();
            this.lastname = dt.Rows[0][4].ToString();
            this.address = dt.Rows[0][5].ToString();
            this.city = dt.Rows[0][6].ToString();
            this.state = dt.Rows[0][7].ToString();
            this.country = dt.Rows[0][8].ToString();
            this.phone = dt.Rows[0][9].ToString();
            this.email = dt.Rows[0][10].ToString();
            this.type = dt.Rows[0][11].ToString();
        }

        public Account() {}
    }
}
