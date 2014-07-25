namespace GameFifteen.Utils
{
    using System;

    public class RandomGenerator
    {
        private static Random numberInMatrix = new Random();

        // unused
        /// <summary>
        /// Returns a nonnegative random integer.
        /// </summary>
        public static int GetRandomNumber()
        {
            return numberInMatrix.Next();
        }

        /// <summary>
        /// Returns a random number in the range [0, max] (inqluding)
        /// </summary>
        public static int GetRandomNumber(int max)
        {
            return numberInMatrix.Next(max+1);
        }

        /// <summary>
        /// Returns a random number in the range [min, max] (inqluding)
        /// </summary>
        public static int GetRandomNumber(int min, int max)
        {
            return numberInMatrix.Next(min, max + 1);
        }
    }
}
