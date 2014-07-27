namespace GameFifteen.Common
{
    using System;

    /// <summary>Represents a player.</summary>
    public class Player
    {
        private string name;
        private int movesCount;

        /// <summary>Constructor.</summary>
        /// <param name="name" type="string">The name of a player.</param>
        /// <param name="movesCount" type="int">Number of moves.</param>
        public Player(string name, int movesCount)
        {
            this.Name = name;
            this.MovesCount = movesCount;
        }

        /// <summary>Gets or sets the name.</summary>
        /// <exception cref="ArgumentNullException">Thrown when one or more required arguments are null.</exception>
        /// <value>The name of the player.</value>
        public string Name
        {
            get { return this.name; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(CommonConstants.INVALID_PLAYER_NAME);
                }

                this.name = value;
            }
        }

        /// <summary>Gets or sets the number of moves.</summary>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one or more arguments are outside the
        ///                                               required range.</exception>
        /// <value>The number of moves.</value>
        public int MovesCount
        {
            get { return this.movesCount; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(CommonConstants.NEGATIVE_MOVE);
                }

                this.movesCount = value;
            }
        }
    }
}
