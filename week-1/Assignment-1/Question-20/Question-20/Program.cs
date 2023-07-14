using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question_20
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This Program finds the longest common subsequence of two given strings");
            Console.WriteLine("Enter First String: ");
            string firstString = Console.ReadLine();
            Console.WriteLine("Enter Second String: ");
            string secondString = Console.ReadLine();
            Console.WriteLine("Longest Common Subsequence: {0}", FindSubsequence(firstString, secondString));
            Console.ReadKey();
        }

        //finds the longest common subsequence
        static string FindSubsequence(string firstString, string secondString)
        {
            string[] substringArrays = new string[firstString.Length];

            string subsequence = "";
            for(int k = 0; k < firstString.Length; k++)
                {
                int prevMatchIndex = 0;
                for (int i = k; i < firstString.Length; i++)
                {
                    for(int j = prevMatchIndex; j < secondString.Length; j++)
                    {
                        if(firstString[i] == secondString[j])
                        {
                            subsequence += secondString[j];
                            prevMatchIndex = j + 1;
                            break;
                        }
                    }
                }
                substringArrays[k] = subsequence;
                subsequence = "";
            }

            string prevLongestSubstring = "";
            foreach(string sub in substringArrays)
            {
                if(prevLongestSubstring.Length < sub.Length)
                {
                    prevLongestSubstring = sub;
                }
            }
            return prevLongestSubstring;
        }
    }
}
