namespace CommandPattern
{
    using CommandPattern.Core.Contracts;
    using System;
    using System.Linq;

    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            var result = string.Empty;
            var argsArr = args.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

            var commandName = argsArr[0].ToLower();
            var commandArgs = argsArr.Skip(1).ToArray();

            if (commandName == "Exit".ToLower())
            {
                var type = typeof(ExitCommand);
                var methodToInvoke = type.GetMethod("Execute");

                var classInstance = Activator.CreateInstance(type);

                methodToInvoke.Invoke(classInstance, new object[] { commandArgs });
            }
            else if (commandName == "Hello".ToLower())
            {
                var type = typeof(HelloCommand);
                var methodToInvoke = type.GetMethod("Execute");

                var classInstance = Activator.CreateInstance(type);

                result = methodToInvoke.Invoke(classInstance, new object[] { commandArgs }).ToString();
            }
            else
            {
                throw new ArgumentException("Unvalid command!");
            }

            return result;
        }
    }
}
