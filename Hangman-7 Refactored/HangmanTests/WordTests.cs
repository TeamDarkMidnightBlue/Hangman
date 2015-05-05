namespace HangmanTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using HangmanGame;

    [TestClass]
    public class WordTests
    {
        [TestMethod]
        public void TestCreatingWord()
        {
            Word testedWord = new Word("mountain");
            Assert.AreEqual(testedWord.GetType(), typeof(Word));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestInvalidWordPassedToConstructor()
        {
            Word testedWord = new Word("12__3");
        }

        [TestMethod]
        public void TestHiddenWordIsOnlyUnderscores()
        {
            Word testedWord = new Word("tested");

            Assert.IsTrue(testedWord.HiddenWord.Equals("______"), "Incorrect hidden word. Should be 6 underscores.");
        }

        [TestMethod]
        public void TestCorrectGuess()
        {
            Word testedWord = new Word("tested");

            Assert.IsTrue(testedWord.Guess('d'), "Incorrect return value. Expected to return true.");
            Assert.IsTrue(testedWord.Guess('t'), "Incorrect return value. Expected to return true.");

        }

        [TestMethod]
        public void TestIncorrectGuess()
        {
            Word testedWord = new Word("tested");

            Assert.IsFalse(testedWord.Guess('j'), "Incorrect return value. Expected to return true.");
            Assert.IsFalse(testedWord.Guess('m'), "Incorrect return value. Expected to return true.");

        }

        [TestMethod]
        public void TestHiddenWordAfterCorrectGuess()
        {
            Word testedWord = new Word("tested");
            testedWord.Guess('d');
            Assert.AreEqual(testedWord.HiddenWord, "_____d", "Incorrect hidden word. Expected '_____d'");

            testedWord.Guess('t');
            Assert.AreEqual(testedWord.HiddenWord, "t__t_d", "Incorrect hidden word. Expected 't__t_d'");

        }

        [TestMethod]
        public void TestHiddenWordAfterIncorrectGuess()
        {
            Word testedWord = new Word("tested");
            testedWord.Guess('w');
            Assert.AreEqual(testedWord.HiddenWord, "______", "Incorrect hidden word. Expected '______'");

            testedWord.Guess('q');
            Assert.AreEqual(testedWord.HiddenWord, "______", "Incorrect hidden word. Expected '______'");

        }

        [TestMethod]
        public void TestIsGuessedReturnsFalse()
        {
            Word testedWord = new Word("tested");
            testedWord.Guess('t');
            Assert.IsFalse(testedWord.IsGuessed, "Incorrect return value. Expected false.");

            testedWord.Guess('d');

            Assert.IsFalse(testedWord.IsGuessed, "Incorrect return value. Expected false.");
        }

        [TestMethod]
        public void TestIsGuessedReturnsTrue()
        {
            Word testedWord = new Word("tested");
            testedWord.Guess('t');
            testedWord.Guess('d');
            testedWord.Guess('e');
            testedWord.Guess('s');

            Assert.IsTrue(testedWord.IsGuessed, "Incorrect return value. Expected true.");
        }
    }
}
