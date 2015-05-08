namespace HangmanGame
{
    using System;

    class RestartCommand : AbstractCommand
    {
        public RestartCommand(IHangmanEngine engine)
            : base(engine)
        {
            this.Engine.WordToGuess = (Word)this.Engine.Factory.CreateWord();
            this.Engine.HasUsedHelp = false;
            this.Engine.CurrentPlayer = new Player("guest");
        }

        public override void Execute()
        {
            Console.WriteLine(Messages.WelcomeMessage);
            Console.WriteLine(string.Format(Messages.SecretWordMessage, this.Engine.WordToGuess.HiddenWord));
            Console.Write(Messages.EnterGuessMessage);
        }
    }
}