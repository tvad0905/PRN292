using System;
using System.Collections.Generic;
using System.Text;

namespace HE130621_QuyPham_Lab1
{
    class Book : InterfaceBase
    {
        private int bookNumber; //automatic increase in list
        private String title, authors, publisher;
        private List<Copy> listCopy;



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
            Console.Write("\nEnter Authors(optional): ");
            authors = Console.ReadLine();
            if (authors.Trim().Length == 0)
            {
                authors = "null";
            }
            return authors;
        }

        public String inputPublisher()
        {
            Console.Write("\nEnter Publish(optional): ");
            publisher = Console.ReadLine();
            if (publisher.Trim().Length == 0)
            {
                publisher = "null";
            }
            return publisher;
        }

        public List<Copy> addNewCopy(Copy c, int copyNum)
        {
            c.CopyNumber = copyNum;
            if (listCopy.Count == 0)
            {
                c.SequenceNumber = 1;

            }
            else
            {
                c.SequenceNumber = listCopy.Count + 1;
            }
            Console.WriteLine("Copy Number: " + c.CopyNumber);
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
