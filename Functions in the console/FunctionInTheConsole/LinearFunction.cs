namespace FunctionInTheConsole
{
    using System;
    using System.Collections.Generic;

    public class LinearFunction : FunctionBase
    {
        private List<double> coefficients;

        public LinearFunction(List<double> coefficients)
        {
            this.coefficients = coefficients;
        }

        public LinearFunction()
        {
            this.coefficients = new List<double>();
        }

        public override FunctionBase GetDerivative()
        {
            var derivative = new LinearFunction();
            derivative.coefficients.Add(this.coefficients[1]);
            return derivative;
        }

        public override double Calculate(double value)
        {
            var result = this.coefficients[0];
            result += this.coefficients[1] * value;
            return result;
        }

        public override string ToString()
        {
            string linearFunction;
            if (this.coefficients.Count < 1)
            {
                throw new ArgumentException("Linear function cannot be empty");
            }

            if (this.coefficients.Count < 2)
            {
                linearFunction = $"{this.coefficients[0]}";
                return linearFunction;
            }

             linearFunction = $"{this.coefficients[1]}" + "x";
            if (this.coefficients[0] > 0)
            {
                linearFunction += " + " + $"{this.coefficients[0]}";
            }

            if (this.coefficients[0] < 0)
            {
                linearFunction += $"{this.coefficients[0]}";
            }

            return linearFunction;
        }
    }
}
