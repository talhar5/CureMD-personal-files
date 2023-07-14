using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This Program prints the summation of two integers");
            Console.WriteLine("Enter first Number: ");
            int num1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter second Number: ");
            int num2 = int.Parse(Console.ReadLine());
            Console.Write("Sum of " + num1 + " and " + num2 + " is: " + Sum(num1, num2));
            Console.ReadKey();

        }
        // takes two integers and returns sum as integer
        static int Sum(int num1, int num2)
        {
            return num1 + num2;
        }
    }
}
