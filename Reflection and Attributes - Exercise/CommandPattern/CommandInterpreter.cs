namespace CommandPattern
{
    using CommandPattern.Core.Contracts;
    using System;
    using System.Linq;

    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            if (args == null)
            {
                throw new ArgumentNullException("Value cannot be null!");
            }

            var value = args.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

            var commandName = value[0];

            if (commandName == "Hello".ToLower())
            {
                var commandArgs = value.Skip(1).ToArray();

                HelloCommand command = new HelloCommand();
                return command.Execute(commandArgs);
            }
            else if (commandName == "Exit".ToLower())
            {
                ExitCommand command = new ExitCommand();
                return command.Execute(null);
            }
            else
            {
                throw new InvalidOperationException("Invalid command!");
            }


        }
    }
}
