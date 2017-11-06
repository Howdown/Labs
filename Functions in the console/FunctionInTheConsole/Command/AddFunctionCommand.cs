namespace FunctionInTheConsole.Command
{
    using FunctionInTheConsole.Functions;

    public class AddFunctionCommand : ICommand
    {
        private readonly string nameFunction;

        private readonly FunctionBase function;

        public AddFunctionCommand(string nameFunction, FunctionBase function)
        {
            this.nameFunction = nameFunction;
            this.function = function;
        }

        public string Apply(FunctionsStorage storage)
        {
            if (storage.ContainsFunctions(this.nameFunction))
            {
                return "error";
            }

            storage.AddFunction(this.nameFunction, this.function);
            return "success";
        }
    }
}