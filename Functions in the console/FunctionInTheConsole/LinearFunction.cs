namespace FunctionInTheConsole
{
    using System;
    using System.Collections.Generic;

    public class LinearFunction : FunctionBase
    {
        private double firstArgument;

        private double secondArgument;

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
            if (this.firstArgument == 0 && this.secondArgument == 0)
            {
                return "0";
            }

                string linearFunction;
            if (this.firstArgument == 0)
            {
                linearFunction = $"{this.secondArgument}";
                return linearFunction;
            }

            if (this.secondArgument == 0)
            {
                linearFunction = $"{this.firstArgument}x";
                return linearFunction;
            }

            linearFunction = $"{this.firstArgument}x";
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
