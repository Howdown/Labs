namespace FunctionInTheConsole
{
    using System;
    using System.Collections.Generic;

    using FunctionInTheConsole.Builders;

    public class Interpreter
    {
        private Dictionary<string, Func<ICommandBuilder>> bilder =
            new Dictionary<string, Func<ICommandBuilder>>()
            {
                [@"^add linear \w+\((-?\d+(,\d+)?) (-?\d+(,\d+)?)\)$"] = () => new AddLinearFunctionBuilder(),
                [@"^add sinus \w+$"] = () => new AddSinusFunctionBuilder(),
                [@"^add cosine \w+$"] = () => new AddCosineFunctionBuilder(),
                [@"^add power \w+\((-?\d+(,\d+)?)\)$"] = () => new AddPowerFunctionBuilder(),
                [@"^add derivative for \w+ with name \w+$"] = () => new AddDerivativeInStorage(),
                [@"^calc \w+\((-?\d+(,\d+)?)\)$"] = () => new CalculateFunctionBuilder(),
                [@"^del \w+$"] = () => new DeleteFunctionBuilder(),
                [@"^getDer \w+$"] = () => new GetDerivativeFunctionBuilder(),
                [@"^print \w+$"] = () => new PrintFunctionBuilder(),
            };

    }
}