namespace FunctionInTheConsole.Command
{
    public interface ICommand
    {
        CommandResult Apply(FunctionsStorage storage);
    }
}