﻿namespace FunctionInTheConsole.Builders
{
    using Command;

    public class AddDerivativeInStorageBuilder : ICommandBuilder
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