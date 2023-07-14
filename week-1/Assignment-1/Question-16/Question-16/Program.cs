using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question_16
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This program reverses the input string");
            Console.WriteLine("Enter a String: ");
            string inputWord = Console.ReadLine();
            Console.WriteLine("\nReversed String: {0}", ReverseTheString(inputWord));
            Console.ReadKey();
        }

        // takes a string and returns the reverse of that string
        static string ReverseTheString(string word)
        {
            string reversedStrig = "";
            foreach(char character in word)
            {
                reversedStrig = character + reversedStrig;
            }
            return reversedStrig;
        }
    }
}
