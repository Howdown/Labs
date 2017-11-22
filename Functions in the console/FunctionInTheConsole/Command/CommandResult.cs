namespace FunctionInTheConsole.Command
{
    public class CommandResult
    {
        public CommandResult(bool identifier, string message)
        {
            this.Identifier = identifier;
            this.Message = message;
        }

<<<<<<< HEAD
        public CommandResult(bool identifier)
        {
            this.Identifier = identifier;
        }

        public bool Identifier { get; }

        public string Message { get; }
=======
        public bool Identifier { get; private set; }

        private string Message { get; private set; }
>>>>>>> Labs/master
    }
}