namespace FunctionInTheConsole.Command
{
    public class CommandResult
    {
        public CommandResult(bool identifier, string message)
        {
            this.Identifier = identifier;
            this.Message = message;
        }

        public bool Identifier { get; }

        public string Message { get; }
    }
}