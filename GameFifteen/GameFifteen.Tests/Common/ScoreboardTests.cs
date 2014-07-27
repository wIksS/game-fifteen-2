namespace GameFifteen.Tests.Common
{
    using System;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using GameFifteen.Common;

    [TestClass]
    public class ScoreboardTests
    {
        private Scoreboard scoreboardInstance;
        private Player player;
        [TestMethod]
        public void ScoreboardInstanceShouldNotBeNull()
        {
            this.scoreboardInstance = Scoreboard.Instance;
            Assert.IsNotNull(scoreboardInstance);
        }

        [TestMethod]
        public void ScoreboardGetPlayersShouldNotReturnNull()
        {
            this.scoreboardInstance = Scoreboard.Instance;
            Assert.IsNotNull(scoreboardInstance.GetPlayers());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddPlayerShouldThrowExceptionOnNullPassed()
        {
            this.scoreboardInstance = Scoreboard.Instance;
            scoreboardInstance.AddPlayer(null);
        }

        [TestMethod]
        public void AddPlayerShouldAddThePlayerToThePlayersList()
        {
            this.scoreboardInstance = Scoreboard.Instance;
            player = new Player("pesho", 150);
            int scoreboardPlayersBeforeAddingNewOne = scoreboardInstance.GetPlayers().Count;
            scoreboardInstance.AddPlayer(player);
            Assert.AreEqual(scoreboardPlayersBeforeAddingNewOne + 1, scoreboardInstance.GetPlayers().Count);
        }

        [TestMethod]
        public void MaximumPlayersSizeMustBeFive()
        {
            this.scoreboardInstance = Scoreboard.Instance;
            player = new Player("pesho", 150);
            for (int i = 0; i < 20; i++)
            {
                scoreboardInstance.AddPlayer(player);               
            }
            Assert.AreEqual(5, scoreboardInstance.GetPlayers().Count);
        }
    }
}
