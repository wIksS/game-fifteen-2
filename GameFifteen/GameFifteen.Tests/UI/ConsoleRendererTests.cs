namespace GameFifteen.Tests.UI
{
    using System;
    using System.Linq;
    using System.Text;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using GameFifteen.Common;
    using GameFifteen.UI;

    [TestClass()]
    public class ConsoleRendererTests
    {
        readonly ConsoleRenderer render = new ConsoleRenderer();

        [TestMethod()]
        public void PrintWelcomeМessageTest()
        {
            var currentConsoleOut = Console.Out;
            string expected = "Welcome to the game “15”. Please try to arrange the numbers sequentially.\n" +
                                    "Use 'top' to view the top scoreboard, 'restart' to start a new game and \n'exit' to quit the game.\n";
            using (var consoleOutput = new ConsoleOutput())
            {
                render.PrintWelcome();
                Assert.AreEqual(expected, consoleOutput.GetOuput());
            }

            Assert.AreEqual(currentConsoleOut, Console.Out);
        }

        [TestMethod()]
        public void PrintScoreboardTest()
        {
            //var currentConsoleOut = Console.Out;
            var playerName = "Aashko";
            Player player = new Player(playerName, 0);

            Scoreboard scoreboard = Scoreboard.Instance;
            scoreboard.AddPlayer(player);
            scoreboard.AddPlayer(player);

            var expected = new StringBuilder();
            expected.AppendLine("Scoreboard:\n1. Aashko --> 0 moves");

            using (var consoleOutput = new ConsoleOutput())
            {
                render.RenderScoreboard(scoreboard);
                bool containsString = consoleOutput.GetOuput().ToString().Contains(expected.ToString());
                Assert.AreEqual(true, containsString);
            }
        }
    }
}
