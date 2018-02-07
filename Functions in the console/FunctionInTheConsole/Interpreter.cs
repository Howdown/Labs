namespace FunctionInTheConsole
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    using FunctionInTheConsole.Builders;
    using FunctionInTheConsole.Command;

    public class Interpreter
    {
        private readonly Dictionary<string, Func<ICommandBuilder>> builder =
            new Dictionary<string, Func<ICommandBuilder>>()
            {
                [@"^add linear \w+\((-?\d+(,\d+)?) (-?\d+(,\d+)?)\)$"] = () => new AddLinearFunctionBuilder(),
                [@"^add sinus \w+$"] = () => new AddSinusFunctionBuilder(),
                [@"^add cosine \w+$"] = () => new AddCosineFunctionBuilder(),
                [@"^add power \w+\((-?\d+(,\d+)?)\)$"] = () => new AddPowerFunctionBuilder(),
                [@"^add derivative for \w+ with name \w+$"] = () => new AddDerivativeInStorageBuilder(),
                [@"^calc \w+\((-?\d+(,\d+)?)\)$"] = () => new CalculateFunctionBuilder(),
                [@"^del \w+$"] = () => new DeleteFunctionBuilder(),
                [@"^getDer \w+$"] = () => new GetDerivativeFunctionBuilder(),
                [@"^print \w+$"] = () => new PrintFunctionBuilder(),
            };

        private FunctionsStorage storage;

        public Interpreter(FunctionsStorage storage)
        {
            this.storage = storage;
        }

        public CommandResult SearchMatches(string inputCommand)
        {
            foreach (var command in this.builder)
            {
                if (Regex.IsMatch(command.Key, inputCommand))
                {
                    var result = command.Value().BuildCommand(inputCommand).Apply(this.storage);
                    return result;
                }
            }

            return new CommandResult(false, "the command is entered incorrectly");
        }
    }
}