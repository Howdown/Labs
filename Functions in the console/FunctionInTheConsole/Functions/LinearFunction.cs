namespace FunctionInTheConsole.Functions
{
    using System;

    public class LinearFunction : FunctionBase
    {
        private readonly double firstArgument;

        private readonly double secondArgument;

        public LinearFunction(double first, double second)
        {
            this.firstArgument = first;
            this.secondArgument = second;
        }

        public override double Calculate(double value)
        {
            var result = this.secondArgument;
            result += this.firstArgument * value;
            return result;
        }

        public override FunctionBase GetDerivative() => new LinearFunction(this.firstArgument, 0);

        public override string ToString()
        {
            if (this.firstArgument.Eq(0) && this.secondArgument.Eq(0))
            {
                return "0";
            }

            if (this.firstArgument.Eq(0))
            {
                return $"{this.secondArgument}";
            }

            if (this.secondArgument.Eq(0))
            {
                return $"{this.firstArgument}x";
            }

            var linearFunction = $"{this.firstArgument}x";
            if (this.secondArgument > 0)
            {
                linearFunction += $" +{this.secondArgument}";
            }

            if (this.secondArgument < 0)
            {
                linearFunction += $" {this.secondArgument}";
            }

            return linearFunction;
        }
    }
}