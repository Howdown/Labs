namespace FunctionInTheConsole.Command
{
    internal class CalculateFunctionCommand : CommandResultHelper
    {
        private readonly string name;
        private readonly double argument;

        public CalculateFunctionCommand(string name, double argument)
        {
            this.name = name;
            this.argument = argument;
        }

        public CommandResult Apply(FunctionsStorage storage)
        {
            return storage.ContainsFunctions(this.name) ? new CommandResult(true, storage.CalculateFunction(this.name, this.argument).ToString())
                : new CommandResult(false, "Function with this name is missing");
        }
    }
}