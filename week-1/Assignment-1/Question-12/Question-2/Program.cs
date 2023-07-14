using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This program checks if a string is a palindrome or not");
            Console.WriteLine("Enter a String: ");
            string word = Console.ReadLine();
            if (IsPalindrome(word))
            {
                Console.WriteLine("{0} is a palindrome word", word);
            }
            else
            {
                Console.WriteLine("{0} is not a palindrome word", word);
            }
            Console.ReadKey();
        }

        //checks for palindrome 
        static bool IsPalindrome(string word)
        {
            int wordLength = word.Length;
            bool isWordPalindrome = true;
                for (int i = 0; i < wordLength / 2; i++)
                {
                    if (word[i] != word[wordLength - i - 1])
                    {
                        isWordPalindrome = false;
                        break;
                    }
                }

            return isWordPalindrome;
        }
    }
}
