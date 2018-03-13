namespace FunctionInTheConsole.Builders
{
    using System;
    using System.Text.RegularExpressions;

    using Command;

    internal class CalculateFunctionBuilder : ICommandBuilder
    {
        public ICommand BuildCommand(string input)
        {
            var regexForName = new Regex(@"\w+");
            var regexForArguments = new Regex(@"(-?\d+(,\d+)?)");
            var regForFunction = new Regex(@"\w+\((-?\d+(,\d+)?)\)$");
            var regexForParameters = new Regex(@"\((-?\d+(,\d+)?)\)$");
            var function = regForFunction.Match(input).ToString();
            var name = regexForName.Match(function).ToString();
            var parameters = regexForParameters.Match(function).ToString();
            var argument = Convert.ToDouble(regexForArguments.Match(parameters).ToString());
            return new CalculateFunctionCommand(name, argument);
        }
    }
}