using System;
using System.Text;
using System.Collections.Generic;
using System.IO;

namespace Unit03
{   /// <summary>
    /// <para>The word bank holding the random words.</para>
    /// <para>
    /// The responsibility of WordBank is to keep track of the Random Words.
    /// </para>
    /// </summary>
    public class WordBank
    {
        private List<string> wordList;
        private List<char> guessesList = new List<char>();
        private string randomWord;
        
        /// <summary>
        /// This class contains methods to handle the list of words and
        /// the player guessing mechanism.
        /// </summary>
        public WordBank()
        {
             wordList = new List<string>(File.ReadLines("dictionary.txt"));
             randomWord = String.Empty;
        }
        
        /// <summary>
        /// Generates random words for the game.
        /// </summary>
        public void GenerateRandonWord()
        {
            Random random = new Random();
            int randomIndex = random.Next(0, wordList.Count-1);
            randomWord = wordList[randomIndex].ToLower();
            guessesList.Clear();
        }

        /// <summary>
        /// Updates the guess status. 
        /// </summary>
        public void Update()
        {
            StringBuilder letters = new StringBuilder();
            foreach (char guess in randomWord)
            {
                if (guessesList.Contains(guess)) 
                {
                    letters.AppendFormat("{0} ", Char.ToUpper(guess));
                }
                else
                {
                    letters.AppendFormat("{0} ", "_");
                }
            }
            TerminalService.WriteLine(letters.ToString());
        }

        /// <summary>
        /// Add the guesses to a list if they are not there yet.
        /// </summary>
        /// <returns>True if is not on the list; false if otherwise.</returns>
        public bool MakeGuess(char guess)
        {
            if (randomWord.Contains(guess)) 
            {
                if ( ! guessesList.Contains(guess)) 
                {
                    guessesList.Add(guess);
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// Returns if the word was guessed
        /// </summary>
        /// <returns>True if is guessed; false if otherwise.</returns>
        public bool IsWordGuessed() 
        {
            if (guessesList.Count == 0)
            {
                return false;
            }
            foreach(char letter in randomWord)
            {
                if (! guessesList.Contains(letter))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Get random word
        /// </summary>
        /// <returns>Random Word</returns>
        public string GetRandomWord()
        {
            return randomWord.ToUpper();    
        }
    }

 
}