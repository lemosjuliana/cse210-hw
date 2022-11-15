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
        private List<string> _wordList;
        private List<char> _guessesList = new List<char>();
        private string _randomWord;
        
        /// <summary>
        /// This class contains methods to handle the list of words and
        /// the player guessing mechanism.
        /// </summary>
        public WordBank()
        {
             _wordList = new List<string>(File.ReadLines("dictionary.txt"));
             _randomWord = String.Empty;
        }
        
        /// <summary>
        /// Generates random words for the game.
        /// </summary>
        public void GenerateRandonWord()
        {
            Random random = new Random();
            int randomIndex = random.Next(0, _wordList.Count-1);
            _randomWord = _wordList[randomIndex].ToLower();
            _guessesList.Clear();
        }

        /// <summary>
        /// Updates the guess status. 
        /// </summary>
        public void Update()
        {
            StringBuilder letters = new StringBuilder();
            foreach (char guess in _randomWord)
            {
                if (_guessesList.Contains(guess)) 
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
        /// Captures the guesses.
        /// </summary>
        /// <returns>True if the letter is correct; false if otherwise.</returns>
        public bool MakeGuess(char guess)
        {
            if (_randomWord.Contains(guess)) 
            {
                if ( ! _guessesList.Contains(guess)) 
                {
                    _guessesList.Add(guess);
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// Returns if the word was guessed.
        /// </summary>
        /// <returns>True if is guessed; false if otherwise.</returns>
        public bool IsWordGuessed() 
        {
            if (_guessesList.Count == 0)
            {
                return false;
            }
            foreach(char letter in _randomWord)
            {
                if (! _guessesList.Contains(letter))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Gets random word.
        /// </summary>
        /// <returns>Random Word</returns>
        public string GetRandomWord()
        {
            return _randomWord.ToUpper();    
        }
    }

 
}