namespace FunctionInTheConsole.Command
{
    internal class GetDerivativeFunctionCommand : CommandResultHelper
    {
        private readonly string name;

        public GetDerivativeFunctionCommand(string name)
        {
            this.name = name;
        }

        public override CommandResult InnerApply(IFunctionsStorage storage)
        {
            return storage.ContainsFunctions(this.name) ? this.Success(storage.GetDerivativeFunction(this.name).ToString())
                : this.Failure("a function with this name is missing");
        }
    }
}