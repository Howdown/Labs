namespace FunctionInTheConsole.Functions
{
    using System;

    public class CosineFunction : FunctionBase
    {
        public override double Calculate(double value) => Math.Cos(value);

        public override FunctionBase GetDerivative() => new SinusFunction();

        public override string ToString() => "cos(x)";
    }
}