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

        public CommandResult Apply(FunctionsStorage storage)
        {
            var identifier = storage.ContainsFunctions(this.nameFunction);
            var resultMessage = new CommandResult(identifier);
            if (!identifier)
            {
                storage.AddFunction(this.nameFunction, this.function);
            }
            
        }
    }
}