namespace FunctionInTheConsole.Builders
{
    using Command;

    public interface ICommandBuilder
    {
        ICommand BuildCommand(string input);
    }
}