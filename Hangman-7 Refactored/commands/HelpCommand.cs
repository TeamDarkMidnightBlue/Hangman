namespace HangmanGame
{
    using System;

    public class HelpCommand : AbstractCommand
    {
        public HelpCommand(IHangmanEngine engine)
            : base(engine)
        {

        }

        public override void Execute()
        {
            Console.WriteLine(string.Format(Messages.RevealNextLetterMessage, this.Engine.WordToGuess.Help()));
            Console.WriteLine(this.Engine.WordToGuess.HiddenWord);
            this.Engine.HasUsedHelp = true;

            if (this.Engine.WordToGuess.IsGuessed)
            {
                Console.WriteLine(string.Format(Messages.WinningMessage, this.Engine.CurrentPlayer.CurrentScore));
                Console.WriteLine(string.Format(Messages.SecretWordMessage, this.Engine.WordToGuess.RevealedWord));

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