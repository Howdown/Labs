namespace FunctionInTheConsole.Builders
{
    using System.Text.RegularExpressions;

    using FunctionInTheConsole.Command;
    using FunctionInTheConsole.Functions;

    internal class AddCosineFunctionBuilder : ICommandBuilder
    {
        public ICommand BuildCommand(string input)
        {
            var regexForName = new Regex(@"\w+$");
            var name = regexForName.Match(input).ToString();
            var cos = new CosineFunction();
            return new AddFunctionCommand(name, cos);
        }
    }
}