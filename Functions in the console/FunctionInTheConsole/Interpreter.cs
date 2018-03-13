namespace FunctionInTheConsole
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using Builders;
    using Command;

    public class Interpreter
    {
        private readonly Dictionary<string, Func<ICommandBuilder>> builders;

        private IFunctionsStorage storage;

        public Interpreter(IFunctionsStorage storage, Dictionary<string, Func<ICommandBuilder>> builders)
        {
            this.storage = storage;
            this.builders = builders;
        }

        public CommandResult SearchMatches(string inputCommand)
        {
            foreach (var builder in this.builders)
            {
                if (Regex.IsMatch(inputCommand, builder.Key))
                {
                    var result = builder.Value().BuildCommand(inputCommand).Apply(this.storage);
                    return result;
                }
            }

            return new CommandResult(false, "the command is entered incorrectly");
        }
    }
}