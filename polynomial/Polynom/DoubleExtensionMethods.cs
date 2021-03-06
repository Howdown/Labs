﻿namespace Polynom
{

    using System;

    public static class DoubleExtensionMethods
    {
        private const double Inaccuracy = 0.00001;

        public static bool Eq(this double numberLeft, double numberRignt, double epsilon = Inaccuracy)
        {
            var equality = Math.Abs(numberLeft - numberRignt) < epsilon;
            return equality;
        }

        public static bool NotEq(this double numberLeft, double numberRight, double epsilon = Inaccuracy)
        {
            var equality = !numberLeft.Eq(numberRight, epsilon);
            return equality;
        }
    }
}