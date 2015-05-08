namespace HangmanGame
{
    using System.Collections.Generic;

    public abstract class AbstractCommand : ICommand
    {
        protected AbstractCommand(IHangmanEngine engine)
        {
            this.Engine = engine;
        }

        public readonly List<string> Data = new List<string>();

        public IHangmanEngine Engine { get; private set; }

        public abstract void Execute();
    }
}
