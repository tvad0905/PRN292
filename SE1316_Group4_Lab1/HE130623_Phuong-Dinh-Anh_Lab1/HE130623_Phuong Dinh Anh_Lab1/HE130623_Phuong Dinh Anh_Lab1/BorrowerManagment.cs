using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HE130623_AnhPhuong_Lab1
{
    class BorrowerManagment : InterfaceBase
    {
        private List<Borrower> listBor;

        public BorrowerManagment()
        {
            ListBor = new List<Borrower>();
        }

        public BorrowerManagment(List<Borrower> listBor)
        {
            this.ListBor = listBor;
        }

        internal List<Borrower> ListBor { get => listBor; set => listBor = value; }

        public List<Borrower> addNewBorrower()
        {
            Borrower bor = new Borrower();

            if (listBor.Count == 0)
            {
                bor.BorrowerNumber = 1;
            }
            else
            {
                bor.BorrowerNumber = listBor.Count + 1;
            }
            Console.WriteLine("Borrower Number: " + bor.BorrowerNumber);
            bor.inputName();
            bor.inputSex();
            bor.inputAddress();
            bor.inputTelephone();
            bor.inputEmail();
            listBor.Add(bor);
            return listBor;
        }

        public void printResult()
        {
            Console.WriteLine("Number \tName\tSex\tTelephone \tEmail");
            foreach (Borrower bo in listBor)
            {
                bo.printResult();
            }
        }
    }
}
