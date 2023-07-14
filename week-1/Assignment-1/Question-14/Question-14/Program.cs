using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question_14
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This Program prints a right triangle using \"*\"");
            Console.WriteLine("Enter the hight of the triangle: ");
            int height = int.Parse(Console.ReadLine());
            PrintTriangle(height);
            Console.ReadKey();
        }

        // funtion to print right triangle to the console
        static void PrintTriangle(int height)
        {
            for(int i = 0; i < height; i++)
            {
                for(int j = 0; j <= i; j++)
                {
                    Console.Write("*");
                }
                Console.Write("\n");
            }
        }
    }
}
