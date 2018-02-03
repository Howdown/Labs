namespace FunctionInTheConsole.Command
{
    public interface ICommand
    {
        CommandResult Apply(FunctionsStorage storage);
    }

    public class CommandResultHelper
    {
        public CommandResult Success(string message = null)
        {
            var result = new CommandResult(true, message);
            return result;
        }

        public CommandResult Failure(string message)
        {
            var result = new CommandResult(false, message);
            return result;
        }
    }
}
