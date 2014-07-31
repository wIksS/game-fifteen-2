using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameFifteen.Common.Tests
{
    [TestClass()]
    public class PlayerTests
    {
        [TestMethod()]
        public void PlayerTest()
        {
            Player player = new Player("Go6o", 12);
            Assert.IsTrue(player.Name == "Go6o" && player.MovesCount == 12);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PlayerNullNameTest()
        {
            new Player(null, 12);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PlayerEmptyNameTest()
        {
            new Player("", 12);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void PlayerInvalidMoovesTest()
        {
            new Player("Go6o", -1);
        }

        [TestMethod()]
        public void PlayerEditTest()
        {
            Player player = new Player("Go6o", 12);
            player.Name = "Joro";
            Assert.IsTrue(player.Name == "Joro" && player.MovesCount == 12);
        }
    }
}
