namespace FunctionInTheConsole.Builders
{
    using FunctionInTheConsole.Command;

    public class AddDerivativeInStorage : ICommandBuilder
    {
        public ICommand BuildCommand(string input)
        {
            var words = input.Split(' ');
            var nameFunction = words[3];
            var nameDerivative = words[6];
            return new AddDerivativeCommand(nameDerivative, nameFunction);
        }
    }

}