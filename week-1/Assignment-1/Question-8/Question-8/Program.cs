using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question_8
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This program prints all the prime numbers upto N");
            Console.WriteLine("Enter a Number: ");
            int num = int.Parse(Console.ReadLine());
            Console.WriteLine("Prime numbers from 1 to " + num + " are: ");
            bool isPrime = true;
            for (int i = 2; i <= num; i++)
            {
                
                for(int j = 2; j <= i/2 + 1; j++ ){
                    if (i != j && i % j == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime)
                {
                    Console.WriteLine(i);
                }
                isPrime = true;
            }
                Console.ReadKey();
        }
    }
}
