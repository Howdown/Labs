namespace FunctionInTheConsole
{
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    using FunctionInTheConsole.Functions;

    public class FunctionsStorage
    {
        private Dictionary<string, FunctionBase> functions;

        public FunctionsStorage()
        {
            this.functions = new Dictionary<string, FunctionBase>();
        }

        public Dictionary<string, FunctionBase> AddFunction(string name, FunctionBase viewFunction)
        {
            this.functions.Add(name, viewFunction);
            return this.functions;
        }

        public Dictionary<string, FunctionBase> DeleteFunction(string name)
        {
            this.functions.Remove(name);
            return this.functions;
        }

        public double CalculateFunction(string name, double value) => this.functions[$"{name}"].Calculate(value);

        public FunctionBase GetDerivativeFunction(string name) => this.functions[$"{name}"].GetDerivative();

    }
}