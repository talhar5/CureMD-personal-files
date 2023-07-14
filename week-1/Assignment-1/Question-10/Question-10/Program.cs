using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question_10
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This program prints fibonacci series upto N");
            Console.WriteLine("Enter a Number: ");
            int num = int.Parse(Console.ReadLine());
            PrintFibonacci(num);
            Console.ReadKey();
        }

        static void PrintFibonacci(int num)
        {
            Console.Write(0 + " " );
            Console.Write(1);
            int num1 = 0;
            int num2 = 1;

            for (int i = 0; i <= num; i++)
            {

                int num3 = num1 + num2;
                Console.Write(" ");
                Console.Write(num1 + num2 );
                num1 = num2;
                num2 = num3;
            }

        }
        
    }
}
