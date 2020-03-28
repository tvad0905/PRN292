using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HE130623_AnhPhuong_Lab1
{
    class Copy : InterfaceBase
    {
        private int copyNumber; //auto increase
        private int sequenceNumber;
        private char type;
        private float price;

        public Copy()
        {

        }

        public Copy(int copyNumber, int sequenceNumber, char type, float price)
        {
            this.CopyNumber = copyNumber;
            this.SequenceNumber = sequenceNumber;
            this.Type = type;
            this.Price = price;
        }

        public int CopyNumber { get => copyNumber; set => copyNumber = value; }
        public int SequenceNumber { get => sequenceNumber; set => sequenceNumber = value; }
        public char Type { get => type; set => type = value; }
        public float Price { get => price; set => price = value; }

        Valid v = new Valid();
        public char inputType()
        {
            return Type = v.checkType("Enter Type(A/R): ", "Must be A or R. Enter again!");
        }

        public int inputSequenceNumber()
        {
            return sequenceNumber = v.checkInt("Enter Sequence Number: ", "Out of limitation", int.MaxValue, 1);
        }

        public float inputPrice()
        {
            return price = v.checkFloat("\nEnter Price: ", "Out of limitation", float.MaxValue, float.MinValue);
        }

        public void printResult()
        { 
            Console.WriteLine(CopyNumber + "\t" + SequenceNumber + "\t" + Char.ToUpper(Type) + "\t" + Price);
        }

      
    }
}
