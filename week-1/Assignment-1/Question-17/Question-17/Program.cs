using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question_17
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This Program sorts an array of integers");
            Console.Write("Input Array of Integers: ");
            int[] numbers = { 4, 9, 0, -6, -99, 80 };
            PrintArrayToConsole(numbers);
            int[] sortedNumbers = SortAnArray(numbers);
            Console.Write("Sorted Array of Integers: ");
            PrintArrayToConsole(sortedNumbers);

            Console.ReadKey();
        }

        // prints array to console
        static void PrintArrayToConsole(int[] arrayOfNumbers)
        {
            Console.Write("[ ");
            foreach (int num in arrayOfNumbers)
            {
                Console.Write(num + " ");
            }
            Console.Write("]\n");

        }
        static int[] SortAnArray(int[] arrayOfNumbers)
        {
            int[] newArray = new int[arrayOfNumbers.Length];
            for (int i = 0; i < arrayOfNumbers.Length; i++)
                {
                    newArray[i] = arrayOfNumbers[i];
                }
                for(int j = 0; j < arrayOfNumbers.Length; j++)
                {

                for(int i = 0; i < arrayOfNumbers.Length - 1; i++)
                {
                    int a = newArray[i];
                    int b = newArray[i+1];
                    if (a < b) // changes the places if not placed oredered
                    {
                        newArray[i] = b;
                        newArray[i + 1] = a;
                    }
                }
            }
            return newArray;
        }
    }
}
