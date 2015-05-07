namespace HangmanTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using HangmanGame;

    [TestClass]
    public class RankingTests
    {
        private Ranking ranking = new Ranking();

        [TestMethod]
        public void TestCreatingRanking()
        {
            Ranking ranking = new Ranking();
            Assert.AreEqual(ranking.GetType(), typeof(Ranking));
        }

        [TestMethod]
        public void TestAddingPlayer()
        {
            Player player = new Player("Straho");
            this.ranking.AddScore(player);
            Assert.AreEqual(this.ranking.Players.Count, 1, "Incorrect players count. Expected 1.");
            Assert.AreEqual(this.ranking.Players[0].Name, "Straho", "Incorrect player name. Expected 'Straho'");
        }

        [TestMethod]
        public void TestAddingMultiplePlayers()
        {
            this.ranking.AddScore(new Player("Gogo"));
            this.ranking.AddScore(new Player("Mimi"));
            this.ranking.AddScore(new Player("Tosho"));
            this.ranking.AddScore(new Player("Pesho"));

            Assert.AreEqual(this.ranking.Players.Count, 4, "Incorrect players count. Expected 4.");
        }

        [TestMethod]
        public void TestGetRankingReturnsCorrectString()
        {
            Player straho = new Player("Straho");
            straho.AddScore(3);
            straho.AddScore(2);
            straho.AddScore(1);
            this.ranking.AddScore(straho);
            string expectedRanking = "1. Name: Straho, Top score: 0, All scores: 0,3,2,1\n";

            Assert.AreEqual(this.ranking.GetRanking(), expectedRanking, "Incorrect ranking.");
        }

    }
}
