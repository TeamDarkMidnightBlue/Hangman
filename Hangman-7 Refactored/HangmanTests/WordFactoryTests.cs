namespace HangmanTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using HangmanGame;
    using System.Collections.Generic;

    [TestClass]
    public class WordFactoryTests
    {
        [TestMethod]
        public void TestCreatingFactoryWithVariableParameters()
        {
            WordFactory factory = new WordFactory("gogo", "pepi", "mimi");
            Assert.AreEqual(factory.GetType(), typeof(WordFactory));
        }

        [TestMethod]
        public void TestCreatingFactoryWithIEnumerable()
        {
            IEnumerable<string> list = new List<string>() { "gogo", "pepi", "mimi" };
            WordFactory factory = new WordFactory(list);
            Assert.AreEqual(factory.GetType(), typeof(WordFactory));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAddingNullValue()
        {
            IEnumerable<string> list = new List<string>() { "gogo", "pepi", "mimi" };
            WordFactory factory = new WordFactory(list);
            factory.AddWord(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestAddingNullIEnumerable()
        {
            IEnumerable<string> list = new List<string>() { "gogo", "pepi", "mimi" };
            WordFactory factory = new WordFactory(list);
            factory.AddWords(null);
        }

        [TestMethod]
        public void TestCreateWord()
        {
            IEnumerable<string> list = new List<string>() { "gogo", "pepi", "mimi", "stanka" };
            WordFactory factory = new WordFactory(list);
            WordBase someWord = factory.CreateWord();

            Assert.AreEqual(someWord.GetType(), typeof(Word));
        }
    }
}
