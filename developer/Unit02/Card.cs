using System;


namespace Unit02
{
    /// <summary>
    /// A rectangular and thin piece of layered paper pasted together to form a flat, semirigid material.
    /// 
    /// The responsibility of Card is to keep track of its currently sorted value and the points 
    /// the user gets after guesses a card correctly.
    /// </summary> 
    public class Card
    {
        private int value;

        /// <summary>
        /// Constructs a new instance of Card.
        /// </summary>
        public Card() 
        {
            value = 0;    
        }

        /// <summary>
        /// Generates a new random value.
        /// </summary>
        public void sort()
        {
            value = new Random().Next(1, 14);
        }

        /// <summary>
        /// Returns a card value between 1 and 13.
        /// </summary>
        public int getValue()
        {
            return value;
        }

        /// <summary>
        /// states that the following card's value is lower when its value < previous value 
        /// </summary>
        public bool isLower(Card other)
        {
            return value < other.getValue();
        }

        /// <summary>
        /// states that the following card's value is higher when its value > previous value 
        /// </summary>
        public bool isHigher(Card other)
        {
            return value > other.getValue();
        }

    }
}