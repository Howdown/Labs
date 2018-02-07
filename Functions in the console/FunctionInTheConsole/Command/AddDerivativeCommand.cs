namespace FunctionInTheConsole.Command
{
    public class AddDerivativeCommand : CommandResultHelper
    {
        private readonly string nameFunction;

        private readonly string nameDerivative;

        public AddDerivativeCommand(string nameDerivative, string nameFunction)
        {
            this.nameDerivative = nameDerivative;
            this.nameFunction = nameFunction;
        }

        public override CommandResult Apply(FunctionsStorage storage)
        {
            if (!storage.ContainsFunctions(this.nameFunction))
            {
                return this.Failure("Function with this name is missing");
            }

            if (storage.ContainsFunctions(this.nameDerivative))
            {
                return this.Failure("Function with the same name already exists");
            }

            var derivative = storage.GetDerivativeFunction(this.nameFunction);
            storage.AddFunction(this.nameDerivative, derivative);
            return this.Success();
        }
    }
}