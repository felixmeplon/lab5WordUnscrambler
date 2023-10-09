using System;
using System.Collections.Generic;
using System.IO;

namespace WordUnscrambler
{
    class Program
    {
        private static readonly FileReader _fileReader = new FileReader();
        private static readonly WordMatcher _wordMatcher = new WordMatcher();

        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Enter scrambled word(s) manually or as a file: F - file / M - manual");
                    string option = Console.ReadLine()?.ToUpper();

                    switch (option)
                    {
                        case "F":
                            Console.WriteLine("Enter the full path including the file name: ");
                            ExecuteScrambledWordsInFileScenario();
                            break;
                        case "M":
                            Console.WriteLine("Enter scrambled words manually (separated by commas if multiple): ");
                            ExecuteScrambledWordsManualEntryScenario();
                            break;
                        default:
                            Console.WriteLine("The entered option was not recognized.");
                            continue;
                    }

                    Console.Write("Would you like to continue? Y/N: ");
                    string continueInput = Console.ReadLine()?.ToUpper();
                    if (continueInput != "Y")
                        break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }
        }

        private static void ExecuteScrambledWordsInFileScenario()
        {
            string filename = Console.ReadLine();
            string[] scrambledWords = _fileReader.Read(filename);
            DisplayMatchedUnscrambledWords(scrambledWords);
        }

        private static void ExecuteScrambledWordsManualEntryScenario()
        {
            string input = Console.ReadLine();
            string[] scrambleWords = input.Split(',');
            DisplayMatchedUnscrambledWords(scrambleWords);
        }

        private static void DisplayMatchedUnscrambledWords(string[] scrambledWords)
        {
            string[] wordList = _fileReader.Read("C:\\Users\\bluel\\source\\repos\\lab5WordUnscramblerupd\\WordUnscrambler_Startup_Code\\WordUnscrambler_Startup_Code\\unscrambledWords.txt");
            List<MatchedWord> matchedWords = _wordMatcher.Match(scrambledWords, wordList);
            foreach (MatchedWord matchedWord in matchedWords)
            {
                Console.WriteLine(matchedWord.Word + " " + matchedWord.ScrambledWord);
            }
        }
    }
}
