namespace Hangman
{
    public interface IWord
    {
        string RevealedWord { get; }

        string HiddenWord { get; }

        bool IsGuessed { get; }

        bool Guess(char charToGuess);
    }
}