namespace FunctionInTheConsole.Command
{
    using System;

    public interface ICommand
    {
        CommandResult Apply(IFunctionsStorage storage);
    }

    public abstract class CommandResultHelper : ICommand
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

        public CommandResult Apply(IFunctionsStorage storage)
        {
            try
            {
                return InnerApply(storage);
            }
            catch (Exception e)
            {
                return Failure(e.Message + e.TargetSite);
            }
        }

        public abstract CommandResult InnerApply(IFunctionsStorage storage);
    }
}
