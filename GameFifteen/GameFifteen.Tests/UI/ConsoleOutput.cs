namespace GameFifteen.Tests.UI
{
    using System;
    using System.IO;
    using System.Linq;

    /// <summary>
    ///  Helper class to redirect the output to a StringWriter
    /// </summary>
    public class ConsoleOutput : IDisposable
    {
        private StringWriter stringWriter;
        private TextWriter originalOutput;

        public ConsoleOutput()
        {
            stringWriter = new StringWriter();
            originalOutput = Console.Out;
            Console.SetOut(stringWriter);
        }

        public string GetOuput()
        {
            return stringWriter.ToString();
        }

        /// <summary>
        /// Provides a mechanism for releasing unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Console.SetOut(originalOutput);
            stringWriter.Dispose();
        }
    }
}