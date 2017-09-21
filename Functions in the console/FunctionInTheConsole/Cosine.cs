namespace FunctionInTheConsole
{
    using System;

    public class Cosine : FunctionBase
    {
        public override FunctionBase GetDerivative()
        {
            var derivative = new Sinus();
            return derivative;
        }

        public override double Calculate(double value)
        {
            var result = Math.Round(Math.Cos(value), 3);
            return result;
        }

        public override string ToString()
        {
            return "cos(x)";
        }
    }
}
