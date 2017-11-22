namespace FunctionInTheConsole.Command
{
    internal class PrintFunctionCommand : ICommand
    {
        private readonly string name;

        public PrintFunctionCommand(string name)
        {
            this.name = name;
        }

        public CommandResult Apply(FunctionsStorage storage)
        {
            var resultMessage = storage.ContainsFunctions(this.name) ? new CommandResult(true, storage.GetFunction(this.name).ToString())
                : new CommandResult(false, "Function with this name is missing");
            return resultMessage;
        }
    }
}