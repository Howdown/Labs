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

        public override double Calculate(double value) => Math.Pow(value * this.multiplier, this.degree);

        public override FunctionBase GetDerivative()
        {
            if (Math.Abs(this.degree) < 0.000001)
            {
                return new PowerFunction(0);
            }

            var derivative = new PowerFunction(this.degree - 1);
            derivative.multiplier = this.multiplier * this.degree;
            return derivative;
        }

        public override string ToString()
        {
            if (this.degree.Eq(0) && this.multiplier.Eq(0))
            {
                return "0";
            }

            if (this.degree.Eq(0))
            {
                return $"{this.multiplier}";
            }

            if (this.multiplier.Eq(1))
            {
                return $"x^{this.degree}";
            }

            return $"{this.multiplier}x^{this.degree}";
        }
    }
}