using System;
using System.Collections.Generic;
using System.Linq;

namespace Unit05.Game.Casting
{
    /// <summary>
    /// <para>Player one uses a cycle that leaves a trail behind.</para>
    /// <para>The responsibility of PlayerOne is to move itself.</para>
    /// </summary>
    public class PlayerOne: Actor
    {
        private List<Actor> _segments = new List<Actor>();

        /// <summary>
        /// Constructs a new instance of Player One.
        /// </summary>
        public PlayerOne()
        {
            PrepareBody();
        }

        /// <summary>
        /// Gets the #1 cycle's segments.
        /// </summary>
        /// <returns>The cycle segments in a List.</returns>
        public List<Actor> GetBody()
        {
            return new List<Actor>(_segments.Skip(1).ToArray());
        }

        /// <summary>
        /// Gets the first segment (the head).
        /// </summary>
        /// <returns>The first segment as an instance of Actor.</returns>
        public Actor GetHead()
        {
            return _segments[0];
        }

        /// <summary>
        /// Gets the Player One segments (including the first).
        /// </summary>
        /// <returns>A list of Player One segments as instances of Actors.</returns>
        public List<Actor> GetSegments()
        {
            return _segments;
        }

        /// <summary>
        /// Grows the trail by the given number of segments (tail).
        /// </summary>
        /// <param name="numberOfSegments">The number of segments to grow.</param>
        public void GrowTail(int numberOfSegments)
        {
            for (int i = 0; i < numberOfSegments; i++)
            {
                Actor tail = _segments.Last<Actor>();
                Point velocity = tail.GetVelocity();
                Point offset = velocity.Reverse();
                Point position = tail.GetPosition().Add(offset);

                Actor segment = new Actor();
                segment.SetPosition(position);
                segment.SetVelocity(velocity);
                segment.SetText("#");
                segment.SetColor(Constants.RED);
                _segments.Add(segment);
            }
        }

        /// <inheritdoc/>
        public override void MoveNext()
        {
            foreach (Actor segment in _segments)
            {
                segment.MoveNext();
            }

            for (int i = _segments.Count - 1; i > 0; i--)
            {
                Actor trailing = _segments[i];
                Actor previous = _segments[i - 1];
                Point velocity = previous.GetVelocity();
                trailing.SetVelocity(velocity);
            }
        }

        /// <summary>
        /// Turns the Player One's first segment in the given direction.
        /// </summary>
        /// <param name="velocity">The given direction.</param>
        public void TurnHead(Point direction)
        {
            _segments[0].SetVelocity(direction);
        }

        /// <summary>
        /// Prepares the Player's body for moving.
        /// </summary>
        private void PrepareBody()
        {
            int x = Constants.MAX_X / 2;
            int y = Constants.MAX_Y / 2;

            for (int i = 0; i < Constants.SNAKE_LENGTH; i++)
            {
                Point position = new Point(x - i * Constants.CELL_SIZE, y);
                Point velocity = new Point(1 * Constants.CELL_SIZE, 0);
                string text = i == 0 ? "8" : "#";
                Color color = i == 0 ? Constants.YELLOW : Constants.RED;

                Actor segment = new Actor();
                segment.SetPosition(position);
                segment.SetVelocity(velocity);
                segment.SetText(text);
                segment.SetColor(color);
                _segments.Add(segment);
            }
        }
    }
}