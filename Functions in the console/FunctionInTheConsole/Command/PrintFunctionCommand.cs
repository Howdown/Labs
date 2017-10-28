namespace FunctionInTheConsole.Command
{
    internal class PrintFunctionCommand : ICommand
    {
        private readonly string name;

        public PrintFunctionCommand(string name)
        {
            this.name = name;
        }

        public string Apply(FunctionsStorage storage)
        {
            if (!storage.CheckForRepeatability(this.name))
            {
                return "error";
            }

            return storage.GetFunction(this.name).ToString();
        }
    }
}