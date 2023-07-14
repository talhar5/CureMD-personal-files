using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question_15
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This Program prints a triangle using \"*\"");
            Console.WriteLine("Enter the height of the triangle: ");
            int height = int.Parse(Console.ReadLine());
            PrintTriangle(height);
            Console.ReadKey();
        }

        // funtion to print triangle to the console
        static void PrintTriangle(int height)
        {
            for (int i = 0; i < height; i++)
            {
                for(int k = height - i; k >= 0; k--)
                {
                    Console.Write(" ");
                }
                for (int j = 0; j <= i; j++)
                {
                    Console.Write("*");
                }
                for (int j = 0; j < i; j++)
                {
                    Console.Write("*");
                }
                Console.Write("\n");
            }
        }
    }
}
