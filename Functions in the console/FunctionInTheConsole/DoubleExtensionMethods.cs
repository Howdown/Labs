namespace FunctionInTheConsole
{
    using System;

    public static class DoubleExtensionMethods
    {
        private const double Inaccuracy = 0.00001;

        public static bool Eq(this double numberLeft, double numberRight, double epsilon = Inaccuracy)
        {
            return Math.Abs(numberLeft - numberRight) < epsilon;
        }

        public static bool NotEq(this double numberLeft, double numberRight, double epsilon = Inaccuracy)
        {
            return !numberLeft.Eq(numberRight, epsilon);
        }
    }
}