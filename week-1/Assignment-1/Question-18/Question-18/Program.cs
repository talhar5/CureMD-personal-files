using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question_18
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This Program checks if the input number is a perfect number or not");
            Console.WriteLine("Enter a Number: ");
            int num = int.Parse(Console.ReadLine());
            if (IsPerfect(num))
            {
                Console.WriteLine("{0} is a Perfect Number.", num);
            }
            else
            {
                Console.WriteLine("{0} is not a Perfect Number.", num);
            }

            Console.ReadKey();
        }

        //checks if the number is a perfect number or not
        static bool IsPerfect(int num)
        {
            int sum = 1;
            for(int i = 2; i <= num/2 + 1; i++)
            {
                if(num % i == 0)
                {
                    sum += i;
                }
            }
            if(sum == num)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
