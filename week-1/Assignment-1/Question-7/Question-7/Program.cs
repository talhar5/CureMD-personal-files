using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question_7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This Program prints a table of the provided number");
            Console.WriteLine("Please enter a number: ");
            int num = int.Parse(Console.ReadLine());
            PrintTable(num);
            Console.ReadKey();
        }

        // funtion to print table of the provided number
        static void PrintTable(int num)
        {
            for (int i = 1; i <= 12; i++)
            {
                // num x i = value
                Console.WriteLine(i + " x " + num + " = " + num*i);
            }
        }
    }
}
