namespace FunctionInTheConsole.Functions
{
    using System;

    public class SinusFunction : FunctionBase
    {
        public override FunctionBase GetDerivative()
        {
            var derivative = new CosineFunction();
            return derivative;
        }

        public override double Calculate(double value)
        {
            var result = Math.Round(Math.Sin(value), 3);
            return result;
        }

        public override string ToString()
        {
            return "sin(x)";
        }
    }
}
