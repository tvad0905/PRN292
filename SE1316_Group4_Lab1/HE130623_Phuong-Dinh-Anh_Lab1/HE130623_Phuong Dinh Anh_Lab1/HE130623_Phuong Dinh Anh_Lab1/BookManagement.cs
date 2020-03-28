using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HE130623_AnhPhuong_Lab1
{
    class BookManagement : InterfaceBase
    {
        private List<Book> listBook;
        private int copyNumList;

        public BookManagement()
        {
            ListBook = new List<Book>();
            CopyNumList = 0;
        }

        public BookManagement(List<Book> listBook)
        {
            this.ListBook = listBook;
        }

        internal List<Book> ListBook { get => listBook; set => listBook = value; }
        public int CopyNumList { get => copyNumList; set => copyNumList = value; }

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
                if(CopyNumList == 0)
                {
                    CopyNumList = 1;
                }
                else
                {
                    CopyNumList = CopyNumList + 1;
                }
                bo.addNewCopy(c, CopyNumList);
                res = v.checkYesNo("\nAdd another copy(Y/N)?: ", "Must be Y or N.Enter again!");
                Console.WriteLine();
            }while(res == 'Y');            
            listBook.Add(bo);
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
