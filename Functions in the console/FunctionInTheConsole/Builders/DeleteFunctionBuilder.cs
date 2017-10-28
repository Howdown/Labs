namespace FunctionInTheConsole.Builders
{
    using System.Text.RegularExpressions;

    using FunctionInTheConsole.Command;

    internal class DeleteFunctionBuilder : ICommandBuilder
    {
        public ICommand BuildCommand(string input)
        {
            var regexForName = new Regex(@"\w+$");
            var name = regexForName.Match(input).ToString();
            return new DeleteFunctionCommand(name);
        }
    }
}