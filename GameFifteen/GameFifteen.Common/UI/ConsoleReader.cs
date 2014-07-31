namespace GameFifteen.UI
{
    using System;
    using GameFifteen.Contracts;

    /// <summary>Represents a console reader.</summary>
    class ConsoleReader : IReader
    {
        /// <summary>Gets the read.</summary>
        /// <returns>A string.</returns>
        public string Read()
        {
            var command = Console.ReadLine();
            return command;
        }
    }
}