namespace FunctionInTheConsole.Command
{
    internal class GetDerivativeFunctionCommand : ICommand
    {
        private readonly string name;

        public GetDerivativeFunctionCommand(string name)
        {
            this.name = name;
        }

        public CommandResult Apply(FunctionsStorage storage)
        {
            var resultMessage = storage.ContainsFunctions(this.name) ? new CommandResult(true, storage.GetDerivativeFunction(this.name).ToString())
                : new CommandResult(false, "a function with this name is missing");
            return resultMessage;
        }
    }
}