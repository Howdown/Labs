namespace FunctionInTheConsole.Builders
{
    using FunctionInTheConsole.Command;

    internal interface ICommandBuilder
    {
        ICommand BuildCommand(string input);
    }
}