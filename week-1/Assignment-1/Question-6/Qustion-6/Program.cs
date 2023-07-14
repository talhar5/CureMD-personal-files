using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question_6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a number: ");
            int num = int.Parse(Console.ReadLine());
            Console.WriteLine("Sum of all the numbers from 1 to " + num + " is: " + SumOfNNumbers(num));
            Console.ReadKey();

        }

        //returns sum of all the numbers from 1 to n
        static int SumOfNNumbers(int num)
        {
            int Sum = 0;
            for (int i = 1; i <= num; i++)
            {
                Sum += i;
            }
            return Sum;
        }
    }
}
