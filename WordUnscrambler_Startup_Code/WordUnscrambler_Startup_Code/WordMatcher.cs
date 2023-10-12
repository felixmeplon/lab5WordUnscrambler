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
        public List<MatchedWord> Match(string[] scrambledwords, string[] wordList)
        {
            List<MatchedWord> matchedWords = new List<MatchedWord>();
            //take imput
            //find words
            // Implement code here.
            // Work with "scrambledWords" and "matchedWords".
            
           
            foreach(string scrambledWord in scrambledwords)
            {
                foreach (string word in wordList)
                {
                    

                    char[] scrambleChar = scrambledWord.ToCharArray();
                    char[] wordChar = word.ToCharArray();

                    Array.Sort(scrambleChar);
                    Array.Sort(wordChar);


                    string newScrambleChar = new string(scrambleChar);
                    string newWordChar = new string(wordChar);



                    if (newScrambleChar == newWordChar)
                    {
                        matchedWords.Add(new MatchedWord { ScrambledWord = scrambledWord, Word = word});
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
