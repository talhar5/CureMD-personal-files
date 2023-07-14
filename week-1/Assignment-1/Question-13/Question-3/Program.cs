using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This program finds the largest and the smallest number in an unsorted array of integers");
            int[] numbers = { 4, 56, 32, -7, 0, -100 };
            Console.Write("\nUnsorted array of Numbers: ");
            PrintArrayToConsole(numbers);
            Console.WriteLine( "\nLargest Number: {0}", FindLargestOfNumbers(numbers));
            Console.WriteLine("Smallest Number: {0}", FindSmallestOfNumbers(numbers));

        }

        //prints array to console
        static void PrintArrayToConsole(int[] arrayOfNumbers)
        {
            Console.Write("[ ");
            foreach (int num in arrayOfNumbers)
            {
                Console.Write(num + " ");
            }
            Console.Write("]\n");

        }

        // function takes an array of integers and returns the largest integer
        static int FindLargestOfNumbers(int[] numbers)
        {
            int prevLargest = int.MinValue;
            foreach(int num in numbers)
            {
                if(num > prevLargest)
                {
                    prevLargest = num;
                }
            }
            return prevLargest;
        }

        // function takes an array of integers and returns the smallest integer
        static int FindSmallestOfNumbers(int[] numbers)
        {
            int prevSmallest = int.MaxValue;
            foreach (int num in numbers)
            {
                if (num < prevSmallest)
                {
                    prevSmallest = num;
                }
            }
            return prevSmallest;
        }
    }
}
