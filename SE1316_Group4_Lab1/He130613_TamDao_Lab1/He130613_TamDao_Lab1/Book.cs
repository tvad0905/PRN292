using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HE130623_TamDao_Lab1
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
            Console.WriteLine("Enter Authorss(optional): ");

            //return authors = v.checkNotBlank("Enter Authors: ", "Must not be empty. Enter again!");
            return authors = Console.ReadLine();
        }

        public String inputPublisher()
        {
            //return publisher = v.checkNotBlank("Enter Publisher: ", "Must not be empty. Enter again!");
            Console.WriteLine("Enter Publisher(optional): ");
       
            return publisher = Console.ReadLine();
        }

        public List<Copy> addNewCopy(Copy c,int count)
        {
            c.CopyNumber = count;
            if (listCopy.Count == 0)
            {
               
                c.SequenceNumber = 1;
            }
            else
            {
              
                c.SequenceNumber = listCopy.Count + 1;
            }
            Console.WriteLine("Copy Number: " + c.CopyNumber);
            Console.WriteLine("Sequence Number: " + c.SequenceNumber);
            /*  bool b;
              do
              {
                  b = true;
                  c.inputSequenceNumber();
                  foreach(Copy cp in listCopy)
                  {
                      if(cp.SequenceNumber == c.SequenceNumber)
                      {
                          Console.WriteLine("This sequence number has existed. Enter again!");                  
                          b = false;
                          break;
                      }
                  }


              } while (b == false);
              */
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
