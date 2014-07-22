﻿namespace GameFifteen.UI.Tests
{
    using System;
    using System.Linq;
    using System.Text;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
  

    [TestClass()]
    public class ConsoleRendererTests
    {
        ConsoleRenderer render = new ConsoleRenderer();
        [TestMethod()]
        public void PrintWelcomeМessageTest()
        {
            var currentConsoleOut = Console.Out;
            string expected = "Welcome to the game “15”. Please try to arrange the numbers sequentially.\n" +
                                    "Use 'top' to view the top scoreboard, 'restart' to start a new game and \n'exit' to quit the game.";
            using (var consoleOutput = new ConsoleOutput())
            {
                render.Print(expected);
                Assert.AreEqual(expected, consoleOutput.GetOuput());
            }

            Assert.AreEqual(currentConsoleOut, Console.Out);
        }


        /*[TestMethod()]
        public void PrintScoreboardTest()
        {
            var currentConsoleOut = Console.Out;
            var playerName = "Goshko";
            Player player = new Player(playerName, 2);

            Scoreboard scoreboard = new Scoreboard();
            scoreboard.AddPlayer(player);

            var expected = new StringBuilder();
            expected.AppendLine("Scoreboard:");
            expected.AppendLine("1. Goshko --> 2 moves");
            expected.AppendLine();

            using (var consoleOutput = new ConsoleOutput())
            {
                render.RenderScoreboard(scoreboard);
                Assert.AreEqual(expected.ToString(), consoleOutput.GetOuput());
            }

            Assert.AreEqual(currentConsoleOut, Console.Out);
        }*/
    }
}