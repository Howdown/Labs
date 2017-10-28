namespace FunctionInTheConsole.Builders
{
    using System;
    using System.Text.RegularExpressions;

    using FunctionInTheConsole.Command;
    using FunctionInTheConsole.Functions;

    internal class AddLinearFunctionBuilder : ICommandBuilder
    {
        public ICommand BuildCommand(string input)
        {
            var regexForName = new Regex(@"\w+");
            var regexForArguments = new Regex(@"(-?\d+(,\d+)?)");
            var regForFunction = new Regex(@"\w+\((-?\d+(,\d+)?) (-?\d+(,\d+)?)\)$");
            var regexForParameters = new Regex(@"\((-?\d+(,\d+)?) (-?\d+(,\d+)?)\)$");
            var function = regForFunction.Match(input).ToString();
            var name = regexForName.Match(function).ToString();
            var parameters = regexForParameters.Match(function).ToString();
            var arguments = regexForArguments.Matches(parameters);
            var firstArgument = Convert.ToDouble(arguments[0].ToString());
            var secondArgument = Convert.ToDouble(arguments[1].ToString());
            var linearFunction = new LinearFunction(firstArgument, secondArgument);
            return new AddFunctionCommand(name, linearFunction);
        }
    }
}