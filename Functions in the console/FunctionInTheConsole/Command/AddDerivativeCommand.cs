namespace FunctionInTheConsole.Command
{
    public class AddDerivativeCommand : ICommand
    {
        private readonly string nameFunction;

        private readonly string nameDerivative;

        public AddDerivativeCommand(string nameDerivative, string nameFunction)
        {
            this.nameDerivative = nameDerivative;
            this.nameFunction = nameFunction;
        }

        public CommandResult Apply(FunctionsStorage storage)
        {
            CommandResult resultMessage;
            if (storage.ContainsFunctions(this.nameFunction))
            {
                if (storage.ContainsFunctions(this.nameDerivative))
                {
                    resultMessage = new CommandResult(false, "Function with the same name already exists");
                }
                else
                {
                    var derivative = storage.GetDerivativeFunction(this.nameFunction);
                    storage.AddFunction(this.nameDerivative, derivative);
                    resultMessage = new CommandResult(true);
                }
            }
            else
            {
                resultMessage = new CommandResult(false, "Function with this name is missing");
            }

            return resultMessage;
        }
    }
}