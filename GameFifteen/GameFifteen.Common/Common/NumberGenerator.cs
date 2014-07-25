namespace GameFifteen.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using GameFifteen.Contracts;

    public class NumberGenerator :INumberGenerator
    {
        private IDictionary<int, int> numbers;
        private int numbersSize;

        public NumberGenerator(int numbersSize)
        {
            numbers = new Dictionary<int, int>();
            this.numbersSize = numbersSize;
        }

        // TODO: validate numbersize

        public int GetNumber(int number)
        {
            if (!this.numbers.ContainsKey(number))
            {
                for (int i = 0; i < this.numbersSize; i++)
                {
                    if (i + 1 == number)
                    {
                        this.numbers[number] = number;
                        break;
                    }
                }   
            }

            return this.numbers[number];
        }
    }
}
