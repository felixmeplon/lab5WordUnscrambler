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
                foreach(string word in wordList)
                {
                    if(ScrambleWord.Equals(word))
                    {
                        matchedWords.Add(new MatchedWord { ScrambledWord = ScrambleWord,  Word = word});   
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
