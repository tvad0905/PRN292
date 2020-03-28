using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HE130577_NguyenDucQuan_Lab1
{
    class Borrower : InterfaceBase
    {
        private int borrowerNumber; //auto increase in list 
        private String name;
        private char sex;
        private String address, telephone, email;

        public Borrower()
        {
        }

        public Borrower(int borrowerNumber, string name, char sex, string address, string telephone, string email)
        {
            this.BorrowerNumber = borrowerNumber;
            this.Name = name;
            this.Sex = sex;
            this.Address = address;
            this.Telephone = telephone;
            this.Email = email;
        }

        public int BorrowerNumber { get => borrowerNumber; set => borrowerNumber = value; }
        public string Name { get => name; set => name = value; }
        public char Sex { get => sex; set => sex = value; }
        public string Address { get => address; set => address = value; }
        public string Telephone { get => telephone; set => telephone = value; }
        public string Email { get => email; set => email = value; }


        Valid v = new Valid();
        public String inputName()
        {
            return name = v.checkNotBlank("Enter Name: ", "Must not be empty. Enter again!");
        }

        public char inputSex()
        {
            return sex = v.checkSex("Enter Sex(M/F): ", "Must be F or M.Enter again!");
           
        }

        //optional
        public String inputAddress()
        {
            Console.Write("\nEnter Address(optional): ");
            return telephone = Console.ReadLine();
        }

        public String inputTelephone()
        {
            return telephone = v.checkTelephone("Enter Telephone(8 numbers): ");
        }

        public String inputEmail()
        {
            return email = v.checkNotBlank("Enter Email: ", "Must not be empty. Enter again!");
        }

        public void printResult()
        {
            Console.WriteLine(BorrowerNumber + "\t" + Name + "\t" + Char.ToUpper(Sex) + "\t" + Telephone + "\t" + Email);
        }
    }
}
