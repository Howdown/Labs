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

        public override FunctionBase GetDerivative()
        {
            var derivative = new LinearFunction(this.firstArgument, 0);
            return derivative;
        }

        public override double Calculate(double value)
        {
            var result = this.secondArgument;
            result += this.firstArgument * value;
            return result;
        }

        public override string ToString()
        {
            if (Math.Abs(this.firstArgument) < 0.000001 && Math.Abs(this.secondArgument) < 0.000001)
            {
                return "0";
            }

                string linearFunction;
            if (Math.Abs(this.firstArgument) < 0.000001)
            {
                linearFunction = $"{this.secondArgument}";
                return linearFunction;
            }

            if (Math.Abs(this.secondArgument) < 0.000001)
            {
                return $"{this.firstArgument}x";
            }

            linearFunction = $"{this.firstArgument}x";
            if (this.secondArgument > 0)
            {
                linearFunction += $" +{this.secondArgument}";
            }

            if (this.secondArgument < 0)
            {
                var s = linearFunction += $" {this.secondArgument}";
            }

            return linearFunction;
        }
    }
}
