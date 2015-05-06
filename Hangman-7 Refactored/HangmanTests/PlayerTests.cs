namespace HangmanTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using HangmanGame;

    [TestClass]
    public class PlayerTests
    {
        [TestMethod]
        public void TestCreatingPlayer()
        {
            Player player = new Player("Straho");
            Assert.AreEqual(player.GetType(), typeof(Player));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestEmptyNameInConstructor()
        {
            Player player = new Player("");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestAddNegativeScore()
        {
            Player player = new Player("Straho");
            player.AddScore(-21);
        }

        [TestMethod]
        public void TestAddScore()
        {
            Player player = new Player("Straho");
            player.AddScore(5);
            Assert.AreEqual(player.TopScore, 5, "Incorrect top score. Expected 5.");

        }

        [TestMethod]
        public void TestTopScore()
        {
            Player player = new Player("Straho");
            player.AddScore(5);
            player.AddScore(7);
            player.AddScore(2);
            player.AddScore(1);
            Assert.AreEqual(player.TopScore, 1, "Incorrect top score. Expected 1.");

        }

        [TestMethod]
        public void TestAllScoresReturnsCorrectString()
        {
            Player player = new Player("Straho");
            player.AddScore(5);
            player.AddScore(7);
            player.AddScore(2);
            player.AddScore(1);
            Assert.AreEqual(player.AllScores(), "5,7,2,1", "Incorrect top score. Expected '5,7,2,1'.");

        }

    }
}
