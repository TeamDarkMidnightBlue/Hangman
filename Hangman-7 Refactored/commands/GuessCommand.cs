namespace HangmanGame
{
    using System;

    class GuessCommand : AbstractCommand
    {
        private char charToGuess;

        public GuessCommand(IHangmanEngine engine)
            : base(engine)
        {
            
        }

        public override void Execute()
        {
            this.charToGuess = this.Data[0][0];

            if (this.Engine.WordToGuess.Guess(this.charToGuess))
            {
                Console.WriteLine(string.Format(Messages.CorrectGuessMessage, this.charToGuess));
                Console.WriteLine(string.Format(Messages.SecretWordMessage, this.Engine.WordToGuess.HiddenWord));
            }
            else
            {
                Console.WriteLine(Messages.WrongGuessMessage);
                this.Engine.CurrentPlayer.IncrementCurrentScore();
                Console.WriteLine(string.Format(Messages.SecretWordMessage, this.Engine.WordToGuess.HiddenWord));
            }

            if (this.Engine.WordToGuess.IsGuessed)
            {
                Console.WriteLine(string.Format(Messages.WinningMessage, this.Engine.CurrentPlayer.CurrentScore));
                //Console.WriteLine(string.Format(Messages.SecretWordMessage, this.Engine.WordToGuess.RevealedWord));

                if (this.Engine.HasUsedHelp)
                {
                    Console.WriteLine(Messages.CheatedMessage);
                }
                else
                {
                    Console.Write(Messages.EnterNameMessage);
                    string name = Console.ReadLine();

                    if (name.Length > 0)
                    {
                        this.Engine.CurrentPlayer.Name = name;
                    }

                    this.Engine.PlayersRanking.AddScore(this.Engine.CurrentPlayer);
                    Console.WriteLine(this.Engine.PlayersRanking.GetRanking());
                }

                this.Engine.WordToGuess = (Word)this.Engine.Factory.CreateWord();
                this.Engine.HasUsedHelp = false;
                this.Engine.CurrentPlayer = new Player("guest");

                Console.WriteLine(Messages.WelcomeMessage);
                Console.WriteLine(string.Format(Messages.SecretWordMessage, this.Engine.WordToGuess.HiddenWord));
                Console.Write(Messages.EnterGuessMessage);
            }
        }
    }
}