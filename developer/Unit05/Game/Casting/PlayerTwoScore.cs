using System;


namespace Unit05.Game.Casting
{
    /// <summary>
    /// <para>Player Two Score.</para>
    /// <para>
    /// The responsibility of PlayerTwoScore is to track Player Two's score
    /// </summary>
    public class PlayerTwoScore : Actor
    {
        private int _points = 0;

        /// <summary>
        /// Constructs a new instance of an PlayerTwoScore
        /// </summary>
        public PlayerTwoScore()
        {
            AddPointsPlayerTwo(0);
        }

        /// <summary>
        /// Adds the given points to the score.
        /// </summary>
        /// <param name="points">The points to add.</param>
        public void AddPointsPlayerTwo(int points)
        {
            this._points += points;
            SetText($" BLUE Player Two: {this._points}");
        }
    }
}