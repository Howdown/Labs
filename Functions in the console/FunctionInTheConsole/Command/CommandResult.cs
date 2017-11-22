namespace FunctionInTheConsole.Command
{
    public class CommandResult
    {
        public CommandResult(bool identifier, string message)
        {
            this.Identifier = identifier;
            this.Message = message;
        }

        public bool Identifier { get; private set; }

        private string Message { get; private set; }
    }
}