namespace HangmanGame
{
    using System;

    public class TopCommand : AbstractCommand
    {
        public TopCommand(IHangmanEngine engine)
            : base(engine)
        {
            
        }

        public override void Execute()
        {
            Console.Write(this.Engine.PlayersRanking.GetRanking());
        }
    }
}