namespace FunctionInTheConsole.Command
{
    using System.Globalization;

    public class CalculateFunctionCommand : CommandResultHelper
    {
        private readonly string name;
        private readonly double argument;

        public CalculateFunctionCommand(string name, double argument)
        {
            this.name = name;
            this.argument = argument;
        }

        public override CommandResult InnerApply(IFunctionsStorage storage)
        {
            return storage.ContainsFunctions(this.name) ? new CommandResult(true, storage.CalculateFunction(this.name, this.argument).ToString(CultureInfo.InvariantCulture))
                : new CommandResult(false, "Function with this name is missing");
        }
    }
}