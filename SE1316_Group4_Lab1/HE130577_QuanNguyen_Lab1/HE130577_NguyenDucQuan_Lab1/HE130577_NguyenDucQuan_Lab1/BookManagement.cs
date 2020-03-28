using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HE130577_NguyenDucQuan_Lab1
{
    class BookManagement : InterfaceBase
    {
        private int count_co = 1;
        private int count_se = 1;
        private List<Book> listBook;

        public BookManagement()
        {
            ListBook = new List<Book>();
        }

        public BookManagement(List<Book> listBook)
        {
            this.ListBook = listBook;
        }

        internal List<Book> ListBook { get => listBook; set => listBook = value; }

        Valid v = new Valid();
        public List<Book> addNewBook()
        {
            Book bo = new Book();
            if(listBook.Count == 0)
            {
                bo.BookNumber = 1;
            }
            else
            {
                bo.BookNumber = listBook.Count + 1;
            }
            Console.WriteLine("Book Number: " + bo.BookNumber);
            bo.inputTitle();
            bo.inputAuthors();
            bo.inputPublisher();
            char res;
            do
            {
                Copy c = new Copy();
                c.CopyNumber = count_co++;
                c.SequenceNumber = count_se++;
                Console.WriteLine("Copy Number: " + c.CopyNumber);
                Console.WriteLine("Consequen Number: " + c.SequenceNumber);
                bo.addNewCopy(c);
                res = v.checkYesNo("\nAdd another copy(Y/N)?: ", "Must be Y or N.Enter again!");
                Console.WriteLine();
            }while(res == 'Y');            
            listBook.Add(bo);
            count_se = 1;
            return listBook;
        }

        public void printResult()
        {
           
            foreach (Book bo in listBook)
            {
                Console.WriteLine("\nBook#\tTitle\tAuthors\tPublisher");
                bo.printResult();
            }
        }
    }
}
