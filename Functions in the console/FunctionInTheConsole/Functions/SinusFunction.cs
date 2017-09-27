namespace FunctionInTheConsole.Functions
{
    using System;

    public class SinusFunction : FunctionBase
    {
        public override double Calculate(double value) => Math.Sin(value);

        public override FunctionBase GetDerivative() => new CosineFunction();

        public override string ToString() => "sin(x)";
    }
}