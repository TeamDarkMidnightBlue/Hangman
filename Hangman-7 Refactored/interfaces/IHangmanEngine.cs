namespace HangmanGame
{
    using System.Text;

    public interface IHangmanEngine
    {
        bool IsRunning { get; set; }

        bool HasUsedHelp { get; set; }

        IWord WordToGuess { get; set; }

        Player CurrentPlayer { get; set; }

        Ranking PlayersRanking { get; }

        IWordFactory Factory { get; }

        StringBuilder Output { get; }

        void Run();
    }
}
