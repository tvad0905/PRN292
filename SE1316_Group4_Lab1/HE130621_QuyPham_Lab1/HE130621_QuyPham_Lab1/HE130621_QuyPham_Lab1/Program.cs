using System;
using System.Collections.Generic;
using System.Text;

namespace HE130621_QuyPham_Lab1
{
    class Program
    {

        static void Main(string[] args)
        {
      
            Valid v = new Valid();
            int choice = 0;
            BorrowerManagement borrowerM = new BorrowerManagement();
            BookManagement bookM = new BookManagement();
            do
            {
                Console.Clear();
                Console.Write("Lab 1: Pham Van Quy, SE1316"
                               + "\nMENU"
                               + "\n1.Add a new borrower"
                               + "\n2.Add a new book and its copies"
                               + "\n3.Exit");

                choice = v.checkInt("\nPlease enter: 1, 2, or 3: ", "Must input from 1 to 3", 3, 1);
                switch (choice)
                {
                    case 1:
                        borrowerM.addNewBorrower();
                        borrowerM.printResult();
                        Console.ReadKey();
                        break;
                    case 2:
                        bookM.addNewBook();
                        bookM.printResult();
                        Console.ReadKey();
                        break;
                }

            } while (choice != 3);

           
        }
    }
}
