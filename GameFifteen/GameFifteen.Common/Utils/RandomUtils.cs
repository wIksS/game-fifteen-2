namespace GameFifteen.Common.Utils
{
    using System;

    public class RandomUtils
    {
        private static Random numberInMatrix = new Random();

        public static int GetRandomNumber()
        {
            return numberInMatrix.Next();
        }

        public static int GetRandomNumber(int max)
        {
            return numberInMatrix.Next(max);
        }

        public static int GetRandomNumber(int min, int max)
        {
            return numberInMatrix.Next(min, max);
        }
    }
}
