namespace GameFifteen.UI
{
    using System;
    using GameFifteen.Common;
    using GameFifteen.Contracts;
    using GameFifteen.Utils;

    class ConsoleReader : IReader
    {
        public string Read()
        {
            var command = Console.ReadLine();
            return command;
        }
    }
}