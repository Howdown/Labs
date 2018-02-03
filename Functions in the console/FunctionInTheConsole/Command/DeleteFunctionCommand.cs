namespace FunctionInTheConsole.Command
{
    internal class DeleteFunctionCommand : CommandResultHelper
    {
        private readonly string name;

        public DeleteFunctionCommand(string name)
        {
            this.name = name;
        }

        public CommandResult Apply(FunctionsStorage storage)
        {
            if (!storage.ContainsFunctions(this.name))
            {
                return this.Failure("Function with this name is missing");
            }

            storage.DeleteFunction(this.name);
            return this.Success();
        }
    }
}