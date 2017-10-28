namespace FunctionInTheConsole.Command
{
    public interface ICommand
    {
        string Apply(FunctionsStorage storage);
    }
}