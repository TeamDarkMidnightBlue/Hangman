namespace HangmanGame
{
    using System;
    using System.Text;

    public class HangmanEngine : IHangmanEngine
    {
        private IWordFactory wordFactory;
        private Ranking theRanking;
        private bool isRunning = true;
        private IWord wordToGuess;
        private StringBuilder output = new StringBuilder();

        public HangmanEngine(IWordFactory factory)
        {
            this.wordFactory = factory;
            this.theRanking = new Ranking();
        }

        public bool IsRunning
        {
            get
            {
                return this.isRunning;
            }
            set
            {
                this.isRunning = value;
            }
        }

        public IWord WordToGuess
        {
            get
            {
                return this.wordToGuess;
            }
            set
            {
                this.wordToGuess = value;
            }
        }

        public Ranking PlayersRanking
        {
            get
            {
                return this.theRanking;
            }
        }

        public IWordFactory Factory
        {
            get
            {
                return this.wordFactory;
            }
        }

        public StringBuilder Output
        {
            get
            {
                return this.output;
            }
        }

        public bool HasUsedHelp { get; set; }

        public Player CurrentPlayer { get; set; }

        public void Run()
        {
            IExecutable startCommand = CommandFactory.Create("restart", this);
            startCommand.Execute();

            Console.WriteLine(this.output);

            while (this.IsRunning)
            {
                this.ExecuteCommandLoop();
            }
        }

        protected virtual void ExecuteCommandLoop()
        {
            this.Output.Clear();

            var inputCommand = Console.ReadLine();

            if (inputCommand.Length == 1 && inputCommand[0] >= 'a' && inputCommand[0] <= 'z')
            {
                inputCommand = "guess " + inputCommand;
            }

            try
            {
                IExecutable command = CommandFactory.Create(inputCommand, this);
                command.Execute();
            }
            catch (CommandException ex)
            {
                this.Output.AppendLine(ex.Message);
            }
            catch (InvalidOperationException)
            {
                this.Output.AppendLine(Messages.IncorrectCommandMessage);
            }

            Console.Write(this.Output);
        }


        private static bool IsValid(string input)
        {
            bool result = (input.Length == 1 && char.ToLower(input[0]) >= 'a' && char.ToLower(input[0]) <= 'z');
            return result;
        }
    }
}