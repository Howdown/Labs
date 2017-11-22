namespace FunctionInTheConsole.Command
{
    using System.Text.RegularExpressions;

    internal class DeleteFunctionCommand : ICommand
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
                return "error";
            }

            storage.DeleteFunction(this.name);
            return "success";
        }
    }
}