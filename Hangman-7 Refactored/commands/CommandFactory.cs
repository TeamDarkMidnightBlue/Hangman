namespace HangmanGame
{
    using System;
    using System.Linq;
    using System.Reflection;


    public static class CommandFactory
    {
        private const string CommandSuffix = "Command";

        public static IExecutable Create(string commandInput, IHangmanEngine engine)
        {
            string[] data = commandInput.Split(' ');
            string commandName = data[0].ToLower();

            var commandClass = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => t.IsClass && t.Namespace == typeof(CommandFactory).Namespace)
                .Where(t => t.Name.EndsWith(CommandSuffix))
                .First(t => t.Name
                    .Replace(CommandSuffix, string.Empty)
                    .ToLower()
                    .Equals(commandName));

            var command = Activator.CreateInstance(commandClass, engine) as AbstractCommand;

            if (data.Length > 1)
            {
                command.Data.Add(data[1]);
            }

            return (IExecutable)command;
        }
    }
}
