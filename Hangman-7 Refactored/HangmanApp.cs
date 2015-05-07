namespace HangmanGame
{
    public class HangmanApp
    {
        public static void Main(string[] args)
        {
            WordFactory factory = new WordFactory(WordRepository.Words);
            HangmanEngine engine = new HangmanEngine(factory);
            engine.Run();
        }
    }
}
