using System;
namespace Project_1
{
    class Program
    {
        static void Main(string[] args)
        {
            // program starts from here:
            Console.Title = "Text Analyzer by CureMD";
            ShowHeading("Text Analyzer");

            // taking input String from the user
            Console.WriteLine("Enter a sentence to analyze: ");
            string inputString = Console.ReadLine() ?? "";


            // on empty input
            if (inputString.Length == 0) ShowError("Input String Required!");

            inputString = Text.TrimSpaces(inputString); //trimming spaces and punctuation
                                                        // on Invalid inputs
            if (inputString.Length == 0) ShowError("Invalid Input String!");
            Console.WriteLine();


            // spliting string into an array using custom made method
            string[] wordsArray = Text.StringToArray(inputString);


            // Word Frequency Analysis
            ShowHeading("Word Frequency");
            Text.ShowWordFrequency(wordsArray);
            Console.WriteLine();

            // Sentence Maker
            ShowHeading("Sentence Maker");
            Console.WriteLine("How many sentences you want to make: (default = 2) ");
            string numberOfSentencesStr = Console.ReadLine() ?? "";
            if (Text.ContainsDigitsOnly(numberOfSentencesStr))
            {
                int numberOfSentences = numberOfSentencesStr.Length <= 0 ? 2 : Convert.ToInt32(numberOfSentencesStr);
                Text.SentenceMaker(wordsArray, numberOfSentences);
            }
            else
            {
                Console.WriteLine("Invalid Number");
                Console.WriteLine("Generating Default 2 Sentences...");
                Console.WriteLine();
                Text.SentenceMaker(wordsArray, 2);

            }
            Console.WriteLine();

            // Longest and Shortest Words
            ShowHeading("Longest and Shortest Word Finder");
            Text.ShowLongestAndShortestWord(wordsArray);
            Console.WriteLine();

            // Word Search
            ShowHeading("Word Search");
            Console.WriteLine("Type a word to search in the string: ");
            string searchWord = Console.ReadLine() ?? "";
            searchWord = Text.TrimSpaces(searchWord);
            if (searchWord.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("No Search Word was entered");
                Console.ResetColor();
            }
            else
            {
                Text.WordSearch(wordsArray, searchWord);
            }
            Console.WriteLine();

            // Palindrome Detector
            ShowHeading("Palindrome Detector");
            Text.ShowPalindrome(wordsArray);
            Console.WriteLine();

            // Vowels and Consonants
            ShowHeading("Vowels & Consonants Counter");
            Text.ShowVowelsAndConsonants(wordsArray);
            Console.WriteLine();

            Console.ReadKey();




            // methods
            // to show error
            void ShowError(string message)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(message);
                Console.ResetColor();
                Console.ReadKey();
                Environment.Exit(0);
            }

            // to show heading
            void ShowHeading(string heading)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("______ {0} ______", heading);
                Console.ResetColor();
                Console.WriteLine();
            }
        }
    }

    public static class Text
    {

        // to trim spaces and punctuation
        public static string TrimSpaces(string str)
        {
            while (true)
            {
                if (str.Length == 0) break;
                if (str[0] == ' ' || str[0] == '.' || str[0] == ',' || str[0] == '?')
                {
                    str = str.RemoveChar(0);
                }
                else if (str[str.Length - 1] == ' ' || str[str.Length - 1] == '.' || str[str.Length - 1] == ',' || str[str.Length - 1] == '?')
                {
                    str = str.RemoveChar(str.Length - 1);
                }
                else break;
            }
            return str;
        }

        // to split a string to array
        public static string[] StringToArray(string str)
        {
            string[] arrayOfWords = new string[CountWords(str)];

            string word = "";
            int index = 0;

            foreach (char alphabet in str)
            {
                if (alphabet == ' ')
                {
                    arrayOfWords[index++] = word;
                    word = "";
                }
                else if (alphabet == '.' || alphabet == '?' || alphabet == ',')
                {
                    continue;
                }
                else
                {
                    word += alphabet;
                }
            }
            arrayOfWords[index] = word;

            // to count the empty elements in the arrayOfWords
            int emptyElements = 0;
            foreach (string elem in arrayOfWords)
            {
                if (elem.Length == 0) emptyElements++;
            }

            // filtering and removing empty elements
            string[] filteredArray = new string[arrayOfWords.Length - emptyElements];
            int j = 0;
            for (int i = 0; i < arrayOfWords.Length; i++)
            {
                if (arrayOfWords[i].Length == 0) continue;
                filteredArray[j++] = arrayOfWords[i];
            }
            return filteredArray;
        }

        // utils 
        //to remove characters from a string 
        private static string RemoveChar(this string str, int index)
        {
            string newString = "";
            for (int i = 0; i < str.Length; i++)
            {
                if (i == index) continue;
                newString += str[i];
            }
            return newString;
        }

        // to count the number of words in a string
        private static int CountWords(string str)
        {
            int counter = 1;
            foreach (char alphabet in str)
            {
                if (alphabet == ' ')
                {
                    counter++;
                }
            }
            return counter;
        }

        //=====================================================//
        // Methods for Word Frequency Analyzer

        public static void ShowWordFrequency(string[] wordsArray)
        {
            string[] removedDuplicates = wordsArray.RemoveDuplicates();

            foreach (string word in removedDuplicates)
            {
                Console.WriteLine("Word: \"{0}\" --> Count: {1}", word, wordsArray.CalcFrequency(word));
            }
        }

        // to calculate frequency of a word
        private static int CalcFrequency(this string[] wordsArray, string word)
        {
            int counter = 0;
            foreach (string elem in wordsArray)
            {
                if (elem == word) counter++;
            }
            return counter;
        }

        // remove duplicates from an array
        private static string[] RemoveDuplicates(this string[] wordsArray)
        {
            string[] filteredArray = new string[wordsArray.Length];
            int index = 0;
            foreach (string word in wordsArray)
            {
                bool isDuplicate = false;
                foreach (string item in filteredArray)
                {
                    if (item == word) isDuplicate = true;
                }
                if (!isDuplicate) filteredArray[index++] = word;
            }
            // counting occupied places
            int counter = 0;
            foreach (string word in filteredArray)
            {
                if (word != null) counter++;
            }
            // removing holes
            string[] uniqueWords = new string[counter];
            for (int i = 0; i < counter; i++) uniqueWords[i] = filteredArray[i];
            return uniqueWords;
        }

        //=====================================================//
        // Methods for Sentence Maker
        public static void SentenceMaker(string[] wordsArray, int num)
        {
            if (num == 0) return;
            Console.WriteLine("Generated Sentences: ");
            string[] uniqueWords = RemoveDuplicates(wordsArray);
            Random rnd = new Random();
            for (int i = 0; i < num; i++)
            {
                string sentence = "";
                for (int j = 0; j < 5; j++)
                {
                    sentence += uniqueWords[rnd.Next(uniqueWords.Length)] + " ";
                }
                sentence += "\b";
                Console.WriteLine("Sentence - {0}: {1}", i + 1, sentence);
            }
        }

        // to check if the input N contains digits only
        public static bool ContainsDigitsOnly(string str)
        {
            bool digitsOnly = true;
            foreach (char c in str)
            {
                if (c != '1' && c != '2' &&
                   c != '3' && c != '4' &&
                   c != '5' && c != '6' &&
                   c != '7' && c != '8' &&
                   c != '9' && c != '0')
                {
                    digitsOnly = false;
                    break;
                }
            }
            return digitsOnly;
        }

        //=====================================================//
        // Longest and Shortest Word Finder
        public static void ShowLongestAndShortestWord(string[] wordsArray)
        {
            string[] uniqueWords = RemoveDuplicates(wordsArray);
            string[] longestWordsArray = GetLongestWord(uniqueWords);
            string[] shortestWordsArray = GetShortestWord(uniqueWords);

            Console.WriteLine("Longest word(s): ");
            foreach (string word in longestWordsArray)
            {
                Console.WriteLine("\"{0}\"", word);
            }
            Console.WriteLine();
            Console.WriteLine("Shortest word(s): ");
            foreach (string word in shortestWordsArray)
            {
                Console.WriteLine("\"{0}\"", word);
            }
        }
        //
        private static string[] GetLongestWord(string[] wordsArray)
        {
            int longestLength = 0;
            foreach (string word in wordsArray)
            {
                if (word.Length > longestLength) longestLength = word.Length;
            }
            int counter = 0;
            foreach (string word in wordsArray)
            {
                if (word.Length == longestLength) counter++;
            }
            string[] longestWords = new string[counter];
            int index = 0;
            for (int i = 0; i < wordsArray.Length; i++)
            {
                if (wordsArray[i].Length == longestLength) longestWords[index++] = wordsArray[i];
            }
            return longestWords;
        }
        private static string[] GetShortestWord(string[] wordsArray)
        {
            int shortestLength = 50;
            foreach (string word in wordsArray)
            {
                if (word.Length < shortestLength) shortestLength = word.Length;
            }
            int counter = 0;
            foreach (string word in wordsArray)
            {
                if (word.Length == shortestLength) counter++;
            }
            string[] shortestWords = new string[counter];
            int index = 0;
            for (int i = 0; i < wordsArray.Length; i++)
            {
                if (wordsArray[i].Length == shortestLength) shortestWords[index++] = wordsArray[i];
            }
            return shortestWords;
        }

        //=====================================================//
        // Word Search
        public static void WordSearch(string[] wordsArray, string searchWord)
        {
            int counter = 0;
            foreach (string word in wordsArray)
            {
                if (searchWord == word) counter++;
            }
            if (counter == 0)
            {
                Console.WriteLine("\"{0}\" is not found in the input string", searchWord);
            }
            else
            {
                Console.WriteLine("\"{0}\" occured {1} time(s) in the input string", searchWord, counter);
            }
        }

        //=====================================================//
        // Palindrome Detector
        public static void ShowPalindrome(string[] wordsArray)
        {
            string[] uniqueWords = RemoveDuplicates(wordsArray);

            int counter = 0;
            foreach (string word in uniqueWords)
            {
                if (word.IsPalindrom())
                {
                    Console.WriteLine("\"{0}\" is a palindrome.", word);
                    counter++;
                }
            }
            if (counter == 0)
            {
                Console.WriteLine("There is no palindrome word in the sentence");
            }
        }
        // checks if a word is palindrom or not
        private static bool IsPalindrom(this string word)
        {
            bool isWordPalindrome = true;
            for (int i = 0; i < word.Length / 2; i++)
            {
                if (word[i] != word[word.Length - i - 1])
                {
                    isWordPalindrome = false;
                    break;
                }
            }
            return isWordPalindrome;
        }

        //=====================================================//
        // Vowels and Consonants
        public static void ShowVowelsAndConsonants(string[] wordsArray)
        {
            string[] uniqueWords = RemoveDuplicates(wordsArray);
            foreach (string word in uniqueWords)
            {
                int vowelsCount = CalcVowels(word);
                Console.WriteLine("\"{0}\": {1} vowel(s) and {2} consonant(s)", word, vowelsCount, word.Length - vowelsCount);
            }
        }

        // to calculate vowels
        private static int CalcVowels(string word)
        {
            int count = 0;
            foreach (char c in word)
            {
                if (c == 'a' || c == 'e' || c == 'i' || c == 'u' || c == 'o')
                {
                    count++;
                }
            }
            return count;
        }
    }

}