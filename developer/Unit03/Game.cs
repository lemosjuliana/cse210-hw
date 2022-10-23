using System;

namespace Unit03
{   /// <summary>
    /// <para>The game that is been played</para>
    /// <para>
    /// The responsibility of a the Game is to control the sequence of play.
    /// </para>
    /// </summary>

    public class Game
    {
        private bool playing;
        private Jumper jumper;
        private WordBank wordBank;
        int triesLeft;

        /// <summary>
        /// Constructs a new instance of Game.
        /// </summary>

        public Game()
        {
            jumper = new Jumper();
            wordBank = new WordBank();
            playing = false;
            triesLeft = 0;
        }

        /// <summary>
        /// Starts the game by running the main game loop.
        /// </summary>
        public void StartGame()
        {
            Splash.show();
            playing = true;
            while (playing)
            {
                DoUpdates();
            }
            TerminalService.Clear();
            TerminalService.WriteLine("Bye!!");
        }

        /// <summary>
        /// handles random word
        /// </summary>
        private void DoUpdates()
        {
            wordBank.GenerateRandonWord();
            jumper.jump();
            triesLeft = 4;
            while (playing)
            {
                TerminalService.Clear();
                jumper.Update();
                wordBank.Update();
                // Player failed to guess after 4 tries ?
                if (! jumper.IsAlive() || triesLeft == 0)
                {
                    ShowLooserMessage();
                    if (! IsPlayerNeedsToTryAgain())
                    {
                        playing = false;
                    }
                    return;
                }
                // Player successfully guessed?
                if (wordBank.IsWordGuessed())
                {
                    ShowWinnerMessage();
                    if (! IsPlayerNeedsToTryAgain())
                    {
                        playing = false;
                    }
                    return;
                }
                // Ask player to make a guess
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
            if (! wordBank.MakeGuess(letter))
            {
                jumper.CutRope();
                triesLeft--;
            }
        }

        /// <summary>
        /// Shows message if the player looses
        /// </summary>
        private void ShowLooserMessage()
        {
            TerminalService.WriteLine("");
            TextAnimator.WriteLine("SORRY, YOU LOST !", 100);
            TextAnimator.WriteLine("The secret word was: " + wordBank.GetRandomWord(), 100);
        }

        /// <summary>
        /// Shows message if the player wins
        /// </summary>
        private void ShowWinnerMessage()
        {
            TerminalService.WriteLine("");
            TextAnimator.WriteLine("CONGRATULATIONS - YOU GUESSED RIGHT !", 100);
        }

        /// <summary>
        /// Asks if the player wants to play again
        /// </summary>
        private bool IsPlayerNeedsToTryAgain()
        {
            TerminalService.WriteLine("");
            TerminalService.WriteLine("Do you want to play again? type 'Y' or 'N': ");
            return Char.ToLower(TerminalService.ReadChar(false)) == 'y';
        }

    }

}


