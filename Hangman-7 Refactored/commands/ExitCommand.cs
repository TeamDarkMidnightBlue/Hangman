namespace HangmanGame
{
    class ExitCommand : AbstractCommand
    {
        public ExitCommand(IHangmanEngine engine)
            : base(engine)
        {

        }

        public override void Execute()
        {
            this.Engine.IsRunning = false;
        }
    }
}