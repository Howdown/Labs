
namespace FunctionInTheConsole.Functions
{
    using System;

    public class PowerFunction : FunctionBase
    {
        private readonly double degree;

        private double multiplier;

        public PowerFunction(double degree)
        {
            if (degree.Eq(0))
            {
                this.degree = 0;
                this.multiplier = 0;
            }
            else
            {
                this.degree = degree;
                this.multiplier = 1;
            }
        }

        public override FunctionBase GetDerivative()
        {
            if (Math.Abs(this.degree) < 0.000001)
            {
                var derivativeZero = new PowerFunction(0);
                return derivativeZero;
            }

            var derivative = new PowerFunction(this.degree - 1);
            derivative.multiplier = this.multiplier * this.degree;
            return derivative;
        }

        public override double Calculate(double value)
        {
            var result = Math.Round(Math.Pow(value * this.multiplier, this.degree), 4);
            return result;
        }

        public override string ToString()
        {
            if (Math.Abs(this.degree) < 0.000001 && Math.Abs(this.multiplier) < 0.000001)
            {
                return "0";
            }

            string powerFunction;
            if (Math.Abs(this.degree) < 0.000001)
            {
                powerFunction = $"{this.multiplier}";
                return powerFunction;
            }

            if (this.multiplier.Eq(1))
            {
                powerFunction = $"x^{this.degree}";
                return powerFunction;
            }

            powerFunction = $"{this.multiplier}x^{this.degree}";
            return powerFunction;
        }
    }
}
