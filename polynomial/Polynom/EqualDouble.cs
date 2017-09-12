namespace Polynom
{
    using System;

    public static class EqualDouble
    {
        public static bool Eq(this double numberLeft, double numberRignt, double epsilon = 0.00001)
        {
            var equality = false || Math.Abs(numberLeft - numberRignt) < epsilon;
            return equality;
        }

        public static bool NotEquals(this double numberLeft, double numberRight, double epsilon = 0.00001)
        {
            var equality = !numberLeft.Eq(numberRight, epsilon);
            return equality;
        }
    }
}