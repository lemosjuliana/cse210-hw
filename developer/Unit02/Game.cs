
using System;


namespace Unit02
{
     /// <summary>
    /// The game that is been played. 
    ///
    /// The responsibility of a the Game is to control the sequence of play.
    /// </summary>
    public class Game
    {
        private bool playing;
        private int score;
        private string userGuess;
        private Card firstCard;
        private Card nextCard;
  
        /// <summary>
        /// Constructs a new instance of Director.
        /// </summary>
        public Game()
        {
            firstCard = new Card();
            nextCard = new Card();
            playing = false;
            score = 300;
        }

        /// <summary>
        /// Starts the game by running the main game loop.
        /// </summary>
        public void run() 
        {
            playing = true;
            while (playing)
            {
                DoFirstCard();
                GetInputs();
                DoUpdates();
                DoOutputs();
            }
        }

        /// <summary>
        /// Displays first's card value. 
        /// </summary>
        public void DoFirstCard()
        {
            firstCard.sort();
            Console.WriteLine($"The card is: {firstCard.getValue()}");
        }

        
        /// <summary>
        /// Asks the user their guess (higher/lower).
        /// </summary>
        public void GetInputs()
        {
            Console.Write("Higher or lower? [h/l] ");
            userGuess = Console.ReadLine();
            playing = (userGuess == "h" || userGuess == "l");
        }

        /// <summary>
        /// Updates the player's score.
        /// </summary>
        public void DoUpdates()
        {
            if (! playing )
            {
                return;
            }
            nextCard.sort();
            // Player correctly guessed lower
            if (userGuess == "l" && nextCard.isLower(firstCard))
            {
                score += 100;
                return;
            }
            // Player correctly guessed higher
            if (userGuess == "h" && nextCard.isHigher(firstCard))
            {
                score += 100;
                return;
            }
            // Player guess was wrong
            score -= 75;
            playing = score > 0;
        }

        
        /// <summary>
        /// Displays the score based on the guess. Also asks the player if they want to play again. 
        /// </summary>
        public void DoOutputs()
        {
            if (score <= 0) 
            {
                Console.WriteLine("Too bad, YOU LOST!!!");
                return;
            }
            Console.WriteLine($"Next card was: {nextCard.getValue()}");
            Console.WriteLine($"Your score is: {score}");
            Console.Write("Play again? [y/n]");
            Console.WriteLine("");
            string yesNo = Console.ReadLine();
            playing = (yesNo == "y");
        }

    }
   
}   

