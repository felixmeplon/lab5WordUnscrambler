﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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
                    Console.WriteLine(sdfb.Properties.Constants.startingprompt);
                    string option = Console.ReadLine()?.ToUpper();

                    switch (option)
                    {
                        case "F":
                            Console.WriteLine(sdfb.Properties.Constants.fileprompt);
                            ExecuteScrambledWordsInFileScenario();
                            break;
                        case "M":
                         
                               ExecuteScrambledWordsManualEntryScenario();

                            break;
                        default:
                            Console.WriteLine(sdfb.Properties.Constants.notreccognizedexeption);
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
            string[] scrambledwords = _fileReader.Read(filename);
            string[] scrambledsolutions = _fileReader.Read(filename);
            DisplayMatchedUnscrambledWords(scrambledwords,scrambledsolutions);
        }

        private static void ExecuteScrambledWordsManualEntryScenario()
        {
            Console.WriteLine("Enter scrambled words manually (separated by commas if multiple): ");
            string scrambledimput = Console.ReadLine();
            Console.WriteLine("Enter Unscrambled words manually (separated by commas)");
            string scrambledoutput = Console.ReadLine();
            string[] scrambledwords = scrambledimput.Split(',');
            string[] scrambledsolutions = scrambledoutput.Split(',');
           
            DisplayMatchedUnscrambledWords(scrambledwords, scrambledsolutions);
        }

        private static void DisplayMatchedUnscrambledWords  (string[] scrambledwords, string[] scrambledsolutions)
        {
            
                List<MatchedWord> matchedWords = _wordMatcher.Match(scrambledwords, scrambledsolutions);

                foreach (MatchedWord matchedWord in matchedWords)
                {
                    Console.WriteLine(matchedWord.Word + " "+"is the unscrambled version of : "  + matchedWord.ScrambledWord);
                }
                             

        }
    }
}
