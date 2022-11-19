using System;
using System.Collections.Generic;
using System.Data;
using Unit05.Game.Casting;
using Unit05.Game.Services;


namespace Unit05.Game.Scripting
{
    /// <summary>
    /// <para>An update action that handles interactions between the actors.</para>
    /// <para>
    /// The responsibility of HandleCollisionsAction is to handle the situation when Player One 
    /// collides Player Two, or the game is over.
    /// </para>
    /// </summary>
    public class HandleCollisionsAction : Action
    {
        private bool _isGameOver = false;
        private bool _playerOneLost = false;
        private bool _playerTwoLost = false;
        private int _count = 0;

        /// <summary>
        /// Constructs a new instance of HandleCollisionsAction.
        /// </summary>
        public HandleCollisionsAction()
        {
        }

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {
            if (_isGameOver == false)
            {
                HandleGrowth(cast);
                HandleSegmentCollisions(cast);
                HandleGameOver(cast);
            }
        }

        /// <summary>
        /// Updates the score and the size of players.
        /// </summary>
        /// <param name="cast">The cast of actors.</param>
        private void HandleGrowth(Cast cast)
        {
            PlayerOne playerOne = (PlayerOne)cast.GetFirstActor("playerOne");
            PlayerTwo playerTwo = (PlayerTwo)cast.GetFirstActor("playerTwo");
              
            PlayerOneScore playerOneScore = (PlayerOneScore)cast.GetFirstActor("playerOneScore");
            PlayerTwoScore playerTwoScore = (PlayerTwoScore)cast.GetFirstActor("playerTwoScore");
            
            // PlayerTwoScore playerTwoScore = (PlayerTwoScore)cast.GetFirstActor("playerTwoScore");
            
            _count = _count + 1;
            if (_count % 15 == 0)
                {
                    playerOne.GrowTail(1);
                    playerTwo.GrowTail(1);
                    playerOneScore.AddPointsPlayerOne(1);
                    playerTwoScore.AddPointsPlayerTwo(1);
                }
        }

        /// <summary>
        /// Sets the game over flag if the players collides with one of their segments.
        /// </summary>
        /// <param name="cast">The cast of actors.</param>
        private void HandleSegmentCollisions(Cast cast)
        {
            PlayerOne playerOne = (PlayerOne)cast.GetFirstActor("playerOne");
            PlayerTwo playerTwo = (PlayerTwo)cast.GetFirstActor("playerTwo");
              
            Actor headOne = playerOne.GetHead();
            Actor headTwo = playerTwo.GetHead();
            
            List<Actor> bodyOne = playerOne.GetBody();
            List<Actor> bodyTwo = playerTwo.GetBody();

            foreach (Actor segmentsOne in bodyOne)
            {
                foreach (Actor segmentsTwo in bodyTwo)
                {
                    if (segmentsOne.GetPosition().Equals(headTwo.GetPosition()))
                    {
                        _isGameOver = true;
                        _playerTwoLost = true;
                    }
                    else if(segmentsTwo.GetPosition().Equals(headOne.GetPosition()))
                    {
                        _isGameOver = true;
                        _playerOneLost = true;
                    }
                    else if(segmentsTwo.GetPosition().Equals(headTwo.GetPosition()))
                    {
                        _isGameOver = true;
                        _playerTwoLost = true;
                    }
                    if (segmentsOne.GetPosition().Equals(headOne.GetPosition()))
                    {
                        _isGameOver = true;
                        _playerOneLost = true;
                    }
                }
                    
            }
        }

        private void HandleGameOver(Cast cast)
        {
            if (_isGameOver == true)
            {
                PlayerOne playerOne = (PlayerOne)cast.GetFirstActor("playerOne");
                PlayerTwo playerTwo = (PlayerTwo)cast.GetFirstActor("playerTwo");

                List<Actor> bodyOne = playerOne.GetBody();
                List<Actor> bodyTwo = playerTwo.GetBody();

                if (_playerOneLost == true)
                {
                    foreach (Actor segment in bodyOne)
                    {
                        int x = Constants.MAX_X / 2 - 100;
                        int y = Constants.MAX_Y / 2;
                        Point position = new Point(x, y);

                        Actor message = new Actor();
                        message.SetText("Game Over! Player Two wins!");
                        message.SetPosition(position);
                        cast.AddActor("messages", message);
                        // make everything white
                        segment.SetColor(Constants.WHITE);
                        message.SetColor(Constants.WHITE);
                    }
               
                }

                 if (_playerTwoLost == true)
                {
                    foreach (Actor segment in bodyTwo)
                    {
                        int x = Constants.MAX_X / 2 - 100;
                        int y = Constants.MAX_Y / 2;
                        Point position = new Point(x, y);

                        Actor message = new Actor();
                        message.SetText("Game Over! Player One wins!");
                        message.SetPosition(position);
                        cast.AddActor("messages", message);
                        // make everything white
                        segment.SetColor(Constants.WHITE);
                        message.SetColor(Constants.WHITE);
                    }
               
                }
               
            }
        }

    }
}