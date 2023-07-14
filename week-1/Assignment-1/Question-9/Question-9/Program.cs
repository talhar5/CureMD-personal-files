using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question_9
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("This program computes the factorial of the provided number");
            Console.WriteLine("Enter a number: ");
            int num = int.Parse(Console.ReadLine());
            Console.WriteLine("Factorial of " + num + " is: " + Factorial(num));
            Console.ReadKey();
        }

        static int Factorial(int n)
        {
            if (n == 0)
            {
                return 1;
            }
            int fact = 1;
            for (int i = 2; i <= n; i++)
            {
                fact *= i;
            }
            return fact;
        }
    }
}
