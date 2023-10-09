using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WordUnscrambler
{   
    class WordMatcher
    {
        public List<MatchedWord> Match(string[] scrambledWords, string[] wordList)
        {
            List<MatchedWord> matchedWords = new List<MatchedWord>();
            //take imput
            //find words
            // Implement code here.
            // Work with "scrambledWords" and "matchedWords".
            
           
            foreach(string ScrambleWord in scrambledWords)
            {
                foreach (string word in wordList)
                {
                    

                    char[] scrambleChar = ScrambleWord.ToCharArray();
                    char[] wordChar = word.ToCharArray();

                    Array.Sort(scrambleChar);
                    Array.Sort(wordChar);


                    string newScrambleChar = new string(scrambleChar);
                    string newWordChar = new string(wordChar);



                    if (newScrambleChar == newWordChar)
                    {
                        matchedWords.Add(new MatchedWord { ScrambledWord = ScrambleWord, Word = word });
                        break;
                    }
                    else
                    {
                        Console.WriteLine("No scramble word matching.");
                        break;
                    }
                }
            }
            
            MatchedWord BuildMatchedWord(string scrambledWord, string word)
            {
            //send matched words
                // Build a matched-word object here, so that you can return it.
                MatchedWord matchedWord = new MatchedWord{ ScrambledWord = scrambledWord, Word = word };
            //return matchedWord;
                return matchedWord;    
            }

            return matchedWords;
        } 
    }

}
