using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HE130577_NguyenDucQuan_Lab1
{
    class Book : InterfaceBase
    {
        private int bookNumber; //automatic increase in list
        private String title, authors, publisher;
        private List<Copy> listCopy; //key = sequence number , value = copy
        

        public Book()
        {
            listCopy = new List<Copy>();
        }

        public Book(int bookNumber, string title, string authors, string publisher)
        {
            this.BookNumber = bookNumber;
            this.Title = title;
            this.Authors = authors;
            this.Publisher = publisher;
        }

        public int BookNumber { get => bookNumber; set => bookNumber = value; }
        public string Title { get => title; set => title = value; }
        public string Authors { get => authors; set => authors = value; }
        public string Publisher { get => publisher; set => publisher = value; }
        public List<Copy> ListCopy { get => listCopy; set => listCopy = value; }

        Valid v = new Valid();
        public String inputTitle()
        {
            return title = v.checkNotBlank("Enter Title: ", "Must not be empty. Enter again!");
        }

        public String inputAuthors()
        {
            Console.Write("Enter Author(optional) : ");
            return authors = Console.ReadLine();
        }

        public String inputPublisher()
        {
            Console.Write("Enter Publisher(optional) : ");
            return publisher = Console.ReadLine();
        }
        
        public List<Copy> addNewCopy(Copy c)
        {
            c.inputType();
            c.inputPrice();
            listCopy.Add(c);
            return listCopy;
        }
        

        public void printResult()
        {
            Console.WriteLine(bookNumber + "\t" + Title + "\t" + Authors + "\t" + Publisher);
            Console.WriteLine("Copy#\tSequence# Type\tPrice");
          
            
            foreach (Copy c in listCopy)
            {
                c.printResult();
            }
            
        }
    }
}
