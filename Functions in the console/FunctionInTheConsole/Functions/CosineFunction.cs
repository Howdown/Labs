namespace FunctionInTheConsole.Functions
{
    using System;

    public class CosineFunction : FunctionBase
    {
        public override FunctionBase GetDerivative()
        {
            var derivative = new SinusFunction();
            return derivative;
        }

        public override double Calculate(double value)
        {
            var result = Math.Cos(value);
            return result;
        }

        public override string ToString()
        {
            return "cos(x)";
        }
    }
}
