namespace FunctionInTheConsole.Command
{
    using System;

    using Functions;

    public class AddFunctionCommand : CommandResultHelper
    {
        private readonly string nameFunction;

        private readonly FunctionBase function;

        public AddFunctionCommand(string nameFunction, FunctionBase function)
        {
            this.nameFunction = nameFunction;
            this.function = function;
        }

        public override CommandResult InnerApply(IFunctionsStorage storage)
        {
            if (storage.ContainsFunctions(this.nameFunction))
            {
                return this.Failure("Function with the same name already exists");
            }

            storage.AddFunction(this.nameFunction, this.function);
            return this.Success();
        }
    }
}