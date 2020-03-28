using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HE130577_NguyenDucQuan_Lab1
{
    class Program
    {
        
        static void Main(string[] args)
        {
            // The code provided will print ‘Hello World’ to the console.
            // Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.
            Valid v = new Valid();
            int choice = 0;
            BorrowerManagment borrowerM = new BorrowerManagment();
            BookManagement bookM = new BookManagement();
            do
            {
                Console.Clear();
                Console.Write("Lab 1: Nguyen Duc Quan, SE1317"
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

           // Console.ReadKey();

            



            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }
    }
}
