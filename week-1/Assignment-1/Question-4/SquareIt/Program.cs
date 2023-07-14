using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareIt
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This program takes an integer and returns square of it");
            Console.WriteLine("Enter a Number(int): ");
            int num = int.Parse(Console.ReadLine());
            Console.WriteLine("Square of " + num + " is: " + Square(num));
            Console.ReadKey();
        }
        static int Square(int num)
        {
            return num * num;
        }
    }
}
