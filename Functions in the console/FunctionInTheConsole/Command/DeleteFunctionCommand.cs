namespace FunctionInTheConsole.Command
{
    using System.Text.RegularExpressions;

    internal class DeleteFunctionCommand : ICommand
    {
        private readonly string name;

        public DeleteFunctionCommand(string name)
        {
            this.name = name;
        }

        public CommandResult Apply(FunctionsStorage storage)
        {
            CommandResult resultMessage;
            if (storage.ContainsFunctions(this.name))
            {
                resultMessage = new CommandResult(true);
                storage.DeleteFunction(this.name);
            }
            else
            {
                resultMessage = new CommandResult(false, "Function with this name is missing");
            }

            return resultMessage;
        }
    }
}