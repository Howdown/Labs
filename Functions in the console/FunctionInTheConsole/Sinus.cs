namespace FunctionInTheConsole
{
    using System;

    public class Sinus : FunctionBase
    {
        public override FunctionBase GetDerivative()
        {
            var derivative = new Cosine();
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
