using System;


namespace Unit05.Game.Casting
{
    /// <summary>
    /// <para>Player One Score.</para>
    /// <para>
    /// The responsibility of PlayerOneScore is to track Player One's score
    /// </summary>
    public class PlayerOneScore : Actor
    {
        private int _points = 0;

        /// <summary>
        /// Constructs a new instance of an PlayerOneScore
        /// </summary>
        public PlayerOneScore()
        {
            AddPointsPlayerOne(0);
        }

        /// <summary>
        /// Adds the given points to the score.
        /// </summary>
        /// <param name="points">The points to add.</param>
        public void AddPointsPlayerOne(int points)
        {
            this._points += points;
            SetText($"Player One: {this._points}");
        }
    }
}