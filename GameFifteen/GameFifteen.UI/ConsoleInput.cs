namespace GameFifteen.UI
{
    using System;
    using GameFifteen.Common;
    using GameFifteen.Common.Contracts;
    using GameFifteen.Common.Utils;

    class ConsoleReader : IReader
    {
        public string Read()
        {
            var command = Console.ReadLine();
            return command;
        }
    }
}