namespace FunctionInTheConsole.Command
{
    internal class PrintFunctionCommand : CommandResultHelper
    {
        private readonly string name;

        public PrintFunctionCommand(string name)
        {
            this.name = name;
        }

        public override CommandResult InnerApply(IFunctionsStorage storage)
        {
            return storage.ContainsFunctions(this.name) ? this.Success(storage.GetFunction(this.name).ToString())
                : this.Failure("Function with this name is missing");
        }
    }
}