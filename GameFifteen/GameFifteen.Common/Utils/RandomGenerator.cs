namespace GameFifteen.Utils
{
    using System;

    /// <summary>Represents a random generator.</summary>
    public class RandomGenerator
    {
        private static Random numberInMatrix = new Random();

        // unused
        /// <summary>Gets random number.</summary>
        /// <returns>The random nonnegative number.</returns>
        public static int GetRandomNumber()
        {
            return numberInMatrix.Next();
        }

        /// <summary>Gets random number.</summary>
        /// <param name="max" type="int">The maximum of the range.</param>
        /// <returns>The random number in the range [0, max] (including).</returns>
        public static int GetRandomNumber(int max)
        {
            return numberInMatrix.Next(max+1);
        }

        /// <summary>Gets random number.</summary>
        /// <param name="min" type="int">The minimum of the range.</param>
        /// <param name="max" type="int">The maximum of the range.</param>
        /// <returns>The random number in the range [min, max] (including).</returns>
        public static int GetRandomNumber(int min, int max)
        {
            return numberInMatrix.Next(min, max + 1);
        }
    }
}
