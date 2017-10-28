namespace FunctionInTheConsole.Builders
{
    using System.Text.RegularExpressions;

    using FunctionInTheConsole.Command;
    using FunctionInTheConsole.Functions;

    internal class AddSinusFunctionBuilder : ICommandBuilder
    {
        public ICommand BuildCommand(string input)
        {
            var regexForName = new Regex(@"\w+$");
            var name = regexForName.Match(input).ToString();
            var sin = new SinusFunction();
            return new AddFunctionCommand(name, sin);
        }
    }
}