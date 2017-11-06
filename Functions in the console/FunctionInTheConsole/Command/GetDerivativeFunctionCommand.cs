namespace FunctionInTheConsole.Command
{
    internal class GetDerivativeFunctionCommand : ICommand
    {
        private readonly string name;

        public GetDerivativeFunctionCommand(string name)
        {
            this.name = name;
        }

        public string Apply(FunctionsStorage storage)
        {
            if (!storage.ContainsFunctions(this.name))
            {
                return "error";
            }

            return storage.GetDerivativeFunction(this.name).ToString();
        }
    }
}