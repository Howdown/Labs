namespace FunctionInTheConsole.Command
{
    internal class CalculateFunctionCommand : ICommand
    {
        private readonly string name;
        private readonly double argument;

        public CalculateFunctionCommand(string name, double argument)
        {
            this.name = name;
            this.argument = argument;
        }

        public string Apply(FunctionsStorage storage)
        {
            if (!storage.ContainsFunctions(this.name))
            {
                return "error";
            }

            return storage.CalculateFunction(this.name, this.argument).ToString();
        }
    }
}