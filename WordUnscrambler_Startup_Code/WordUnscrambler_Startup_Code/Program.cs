using System;
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
                    Console.WriteLine(sdfb.Properties.Constants.start);
                string language = Console.ReadLine()?.ToUpper();
                switch (language)
                {
                       

                    case "E":
                            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-CA");
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

                            Console.Write(sdfb.Properties.Constants._continue);
                            string continueInput = Console.ReadLine()?.ToUpper();
                            if (continueInput != "Y")
                            {
                                break;
                            }

                            break;

                    case "F":
                   
                        Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("fr-CA");
                        Console.WriteLine(sdfb.Properties.Constants.startingprompt);
                         option = Console.ReadLine()?.ToUpper();

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
                       
                        Console.Write(sdfb.Properties.Constants._continue);
                        continueInput = Console.ReadLine()?.ToUpper();
                        if (continueInput != "O")
                        {
                            break;
                        }

                            break;

                        default:
                            break;
                    }
             
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine(sdfb.Properties.Constants.error+ ex.Message);
                }
            }
        }

        private static void ExecuteScrambledWordsInFileScenario()
        {
            string filename = Console.ReadLine();
            string[] scrambledwords = _fileReader.Read(filename);
           
            DisplayMatchedUnscrambledWords(scrambledwords);
        }

        private static void ExecuteScrambledWordsManualEntryScenario()
        {

            Console.WriteLine(sdfb.Properties.Constants.manualentry);

            string scrambledimput = Console.ReadLine();
            string[] scrambledwords=scrambledimput.Split(',');

            


            DisplayMatchedUnscrambledWords(scrambledwords);
        }

        private static void DisplayMatchedUnscrambledWords  (string[] scrambledwords)
        {
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string[] wordlist = _fileReader.Read(Path.Combine(currentDirectory, "wordlist.txt"));

            
                List<MatchedWord> matchedWords = _wordMatcher.Match(scrambledwords,wordlist);

                foreach (MatchedWord matchedWord in matchedWords)
                {
                    Console.WriteLine(matchedWord.Word + " "+ sdfb.Properties.Constants.unscrambledversionof + matchedWord.ScrambledWord);
                }
                             

        }
    }
}
