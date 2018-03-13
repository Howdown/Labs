namespace FunctionInTheConsole
{
    using System.Collections.Generic;

    using FunctionInTheConsole.Functions;

    public interface IFunctionsStorage
    {
        void AddFunction(string name, FunctionBase viewFunction);

        void DeleteFunction(string name);

        double CalculateFunction(string name, double value);

        FunctionBase GetDerivativeFunction(string name);

        bool ContainsFunctions(string name);

        FunctionBase GetFunction(string name);
    }

    public class FunctionsStorage : IFunctionsStorage
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