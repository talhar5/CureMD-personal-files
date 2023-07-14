using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question_11
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("This Program searches for a number in an array of numbers\n");
            int[] numbers= { 5, 67, 43, 9, -4 };
            Console.Write("Array of 5 Numbers: ");
            printArrayToConsole(numbers);
            Console.WriteLine("\nEnter a Number: ");
            int num = int.Parse(Console.ReadLine());
            bool isNumberExist = false;
            for(int i = 0; i < numbers.Length; i++)
            {
                if(num == numbers[i])
                {
                    isNumberExist = true;
                    break;
                }
            }
            if (isNumberExist)
            {
                Console.WriteLine("Number exists in the array");
            }
            else
            {
                Console.WriteLine("Number is not found in the array");
            }
            Console.ReadKey();
        }

        //prints array to console
        static void printArrayToConsole(int[] arrayOfNumbers)
        {
            Console.Write("[ ");
                foreach(int num in arrayOfNumbers)
            {
                Console.Write(num + " ");
            }
            Console.Write("]");
        }
    }
}
