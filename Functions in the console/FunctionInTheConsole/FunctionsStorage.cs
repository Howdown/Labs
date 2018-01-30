namespace FunctionInTheConsole
{
    using System.Collections.Generic;

    using FunctionInTheConsole.Functions;

    public class FunctionsStorage
    {
        private Dictionary<string, FunctionBase> functions;

        public FunctionsStorage()
        {
            this.functions = new Dictionary<string, FunctionBase>();
        }

        public void AddFunction(string name, FunctionBase viewFunction)
        {
            this.functions.Add(name, viewFunction);
        }

        public void DeleteFunction(string name)
        {
            this.functions.Remove(name);
        }

        public double CalculateFunction(string name, double value) => this.functions[name].Calculate(value);

        public FunctionBase GetDerivativeFunction(string name) => this.functions[name].GetDerivative();

        public bool ContainsFunctions(string name)
        {
            return this.functions.ContainsKey(name);
        }

        public FunctionBase GetFunction(string name)
        {
            return this.functions[name];
        }
    }
}