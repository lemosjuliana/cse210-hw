using System;

namespace Unit03

{   /// <summary>
    /// <para>The game that is been played</para>
    /// <para>
    /// The responsibility of the Game is to control the sequence of play.
    /// </para>
    /// </summary>
    public class Game
    {
        private bool _playing;
        private Jumper _jumper;
        private WordBank _wordBank;
        int _triesLeft;

        /// <summary>
        /// Constructs a new instance of Game.
        /// </summary>
        public Game()
        {
            _jumper = new Jumper();
            _wordBank = new WordBank();
            _playing = false;
            _triesLeft = 0;
        }

        /// <summary>
        /// Starts the game by running the main game loop.
        /// </summary>
        public void StartGame()
        {
            Splash.show();
            _playing = true;
            while (_playing)
            {
                DoUpdates();
            }
            TerminalService.Clear();
            TerminalService.WriteLine("Bye!!");
        }

        /// <summary>
        /// Handles random word.
        /// </summary>
        private void DoUpdates()
        {
            _wordBank.GenerateRandonWord();
            _jumper.jump();
            _triesLeft = 4;
            while (_playing)
            {
                TerminalService.Clear();
                _jumper.Update();
                _wordBank.Update();
                // Player failed to guess after 4 tries 
                if (! _jumper.IsAlive() || _triesLeft == 0)
                {
                    ShowLooserMessage();
                    if (! IsPlayerNeedsToTryAgain())
                    {
                        _playing = false;
                    }
                    return;
                }
                // Player successfully guessed
                if (_wordBank.IsWordGuessed())
                {
                    ShowWinnerMessage();
                    if (! IsPlayerNeedsToTryAgain())
                    {
                        _playing = false;
                    }
                    return;
                }
                // Asks player to make a guess
                MakeGuess();
            }
        }

        /// <summary>
        /// Asks the user their guess (letter).
        /// </summary>
        private void MakeGuess()
        {
            TerminalService.WriteLine("");
            TerminalService.WriteText("Choose a letter: ");
            char letter = Char.ToLower(TerminalService.ReadChar(false));
            if (! _wordBank.MakeGuess(letter))
            {
                _jumper.CutRope();
                _triesLeft--;
            }
        }

        /// <summary>
        /// Displays message if the player looses.
        /// </summary>
        private void ShowLooserMessage()
        {
            TerminalService.WriteLine("");
            TextAnimator.WriteLine("SORRY, YOU LOST !", 100);
            TextAnimator.WriteLine("The secret word was: " + _wordBank.GetRandomWord(), 100);
        }

        /// <summary>
        /// Displays message if the player wins.
        /// </summary>
        private void ShowWinnerMessage()
        {
            TerminalService.WriteLine("");
            TextAnimator.WriteLine("CONGRATULATIONS - YOU GUESSED RIGHT !", 100);
        }

        /// <summary>
        /// Asks if the player wants to play again.
        /// </summary>
        private bool IsPlayerNeedsToTryAgain()
        {
            TerminalService.WriteLine("");
            TerminalService.WriteLine("Do you want to play again? type 'Y' or 'N': ");
            return Char.ToLower(TerminalService.ReadChar(false)) == 'y';
        }

    }

}


