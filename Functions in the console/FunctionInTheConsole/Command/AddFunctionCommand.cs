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
<<<<<<< HEAD
            CommandResult resultMessage;
            if (storage.ContainsFunctions(this.nameFunction))
            {
                resultMessage = new CommandResult(false, "Function with the same name already exists");
            }
            else
            {
                resultMessage = new CommandResult(true);
                storage.AddFunction(this.nameFunction, this.function);
            }

            return resultMessage;
=======
            var identifier = storage.ContainsFunctions(this.nameFunction);
            var resultMessage = new CommandResult(identifier);
            if (!identifier)
            {
                storage.AddFunction(this.nameFunction, this.function);
            }
            
>>>>>>> Labs/master
        }
    }
}