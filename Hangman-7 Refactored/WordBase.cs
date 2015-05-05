namespace HangmanGame
{
    public abstract class WordBase : IWord
    {
        public WordBase(string word)
        {

        }

        //remove after refactoring
        public WordBase()
        {

        }

        public abstract string HiddenWord { get; }
        public abstract bool IsGuessed { get; }
        public abstract string RevealedWord { get; }

        public abstract bool Guess(char charToGuess);
    }
}
