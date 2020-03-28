using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HE130623_TamDao_Lab1
{
    class Valid
    {
        //check sex : only F , M
        public char checkSex(string mess, string error)
        {
            bool r;
            char c = ' ';
            do
            {
                r = true;
                Console.Write(mess);
                c = Console.ReadKey().KeyChar;
                if(Char.ToUpper(c) != 'F' && Char.ToUpper(c) != 'M')
                {
                    Console.WriteLine("\n" + error); //  To get new line using double new line with ReadKey
                    r = false;
                }
            } while (r == false);

            return c;
        }

        public char checkYesNo(string mess, string error)
        {
            bool r;
            char c = ' ';
            do
            {
                r = true;
                Console.Write(mess);
                c = Console.ReadKey().KeyChar;
                if (Char.ToUpper(c) != 'Y' && Char.ToUpper(c) != 'N')
                {
                    Console.WriteLine("\n" + error); //  To get new line using double new line with ReadKey
                    r = false;
                }
            } while (r == false);

            return Char.ToUpper(c);
        }

        //check string : not blank
        public String checkNotBlank(string mess, string error)
        {
            bool r;
            string s = "";
            do
            {
                r = true;
                Console.Write(mess);
                s = Console.ReadLine();
                if (s.Trim().Length == 0)
                {
                    Console.WriteLine(error);
                    r = false;
                }
            } while (r == false);

            return s;
        }


        public String checkTelephone(string mess)
        {
            bool r;
            string s = "";
            do
            {
                r = true;
                Console.Write(mess);
                s = Console.ReadLine();
                if (s.Trim().Length == 0)
                {
                    Console.WriteLine("Must not be empty.Enter again!");
                    r = false;
                }
                Match m = Regex.Match(s, "[0-9]{8}");
                if (!m.Success)
                {
                    Console.WriteLine("Wrong form of telephone number");
                    r = false;
                }
            } while (r == false);

            return s;
        }


        public char checkType(string mess, string error)
        {
            bool r;
            char c = ' ';
            do
            {
                r = true;
                Console.Write(mess);
                c = Console.ReadKey().KeyChar;
                if (Char.ToUpper(c) != 'A' && Char.ToUpper(c) != 'R')
                {
                    Console.WriteLine("\n" + error);
                    r = false;
                }
            } while (r == false);

            return c;
        }


        public int checkInt(String mess, String error, int Max, int Min)
        {
            bool r;
            int x = 0;
            do
            {
                r = true;
                Console.Write(mess);
               
                try
                {
                    x = Convert.ToInt32(Console.ReadLine());
                    if (x > Max || x < Min)
                    {
                        Console.WriteLine(error);
                        r = false;
                       
                    }
                }
                catch(Exception)
                {
                    Console.WriteLine("Must input integer type");
                    r = false;
                   
                }

            } while (r == false);

            return x;
        }

        public float checkFloat(String mess, String error, float Max, float Min)
        {
            bool r;
            float x = 0;
            do
            {
                r = true;
                Console.Write(mess);
                try
                {
                    x = float.Parse(Console.ReadLine(), CultureInfo.InvariantCulture.NumberFormat); //set local decimal mark "."
                    if (x > Max || x < Min)
                    {
                        Console.WriteLine(error);
                        r = false;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Must input number type");
                    r = false;

                }

            } while (r == false);

            return x;
        }


    }
}
