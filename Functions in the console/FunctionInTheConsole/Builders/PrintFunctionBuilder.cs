namespace FunctionInTheConsole.Builders
{
    using System.Text.RegularExpressions;

    using Command;

    internal class PrintFunctionBuilder : ICommandBuilder
    {
        public ICommand BuildCommand(string input)
        {
            var regexForName = new Regex(@"\w+$");
            var name = regexForName.Match(input).ToString();
            return new PrintFunctionCommand(name);
        }
    }
}