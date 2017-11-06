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

        public string Apply(FunctionsStorage storage)
        {
            if (storage.ContainsFunctions(this.nameFunction) && !storage.ContainsFunctions(this.nameDerivative))
            {
                var derivative = storage.GetDerivativeFunction(this.nameFunction);
                storage.AddFunction(this.nameDerivative, derivative);
            }

            return "error";
        }
    }
}