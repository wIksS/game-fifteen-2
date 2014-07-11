using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFifteen.Common.Utils
{
    public class RandomUtils
    {
        private static Random number = new Random();

        public static int GetRandomNumber()
        {
            return number.Next();
        }

        public static int GetRandomNumber(int max)
        {
            return number.Next(max);
        }

        public static int GetRandomNumber(int min, int max)
        {
            return number.Next(min,max);
        }
    }
}
