namespace HangmanGame
{
    public interface ICommand : IExecutable
    {
        

        IHangmanEngine Engine { get; }
    }
}
