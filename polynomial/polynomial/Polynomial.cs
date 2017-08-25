namespace Polynomial
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Eventing.Reader;
    using System.Globalization;
    using System.Linq;
    using System.Runtime.CompilerServices;

    public class Polynomial
    {
        private List<double> coefficients;

        public Polynomial(List<double> index)
        {
            this.coefficients = index;
        }

        public Polynomial()
        {
            this.coefficients = new List<double>();
        }

        public static Polynomial operator +(Polynomial leftPolynomial, Polynomial rightPolynomial)
        {
            var result = new Polynomial();
            double summ;
            var leftCoefficients = leftPolynomial.coefficients;
            var rightCoefficients = rightPolynomial.coefficients;
            if (leftCoefficients.Count != rightCoefficients.Count)
            {
                var longLength = leftCoefficients.Count < rightCoefficients.Count
                                     ? rightCoefficients.Count
                                     : leftCoefficients.Count;
                var shortLength = leftCoefficients.Count > rightCoefficients.Count
                                      ? rightCoefficients.Count
                                      : leftCoefficients.Count;
                for (var i = 0; i < longLength; i++)
                {
                    if (i < shortLength)
                    {
                        summ = leftCoefficients[i] + rightCoefficients[i];
                        result.coefficients.Add(summ);
                    }
                    else
                    {
                        result.coefficients.Add(
                            leftCoefficients.Count > rightCoefficients.Count
                                ? leftCoefficients[i]
                                : rightCoefficients[i]);
                    }
                }
            }
            else
            {
                for (var i = 0; i < leftCoefficients.Count; i++)
                {
                    summ = leftCoefficients[i] + rightCoefficients[i];
                    result.coefficients.Add(summ);
                }
            }

            return result;
        }

        public static Polynomial operator -(Polynomial polynomialOfMinus)
        {
            var coefficients = polynomialOfMinus.coefficients.Select(t => (-1) * t).ToList();
            return new Polynomial(coefficients);
        }

        public static Polynomial operator -(Polynomial leftPolynomial, Polynomial rightPolynomial)
        {
            return leftPolynomial + (-rightPolynomial);
        }

        public static Polynomial operator *(Polynomial leftPolynomial, Polynomial rightPolynomial)
        {
            var result = new Polynomial();
            var leftCoefficients = leftPolynomial.coefficients;
            var rightCoefficients = rightPolynomial.coefficients;
            var corrector = 0;
            var summ = 0.0;
            var values = new double[leftCoefficients.Count,
                leftCoefficients.Count + rightCoefficients.Count - 1];
            for (var i = 0; i < leftCoefficients.Count; i++)
            {
                for (var j = 0; j < rightCoefficients.Count; j++)
                {
                    values[i, j + corrector] = leftCoefficients[i] * rightCoefficients[j];
                }

                corrector++;
            }

            for (var j = 0; j < (leftCoefficients.Count + rightCoefficients.Count - 1); j++)
            {
                for (var i = 0; i < leftCoefficients.Count; i++)
                {
                    summ += values[i, j];
                }

                result.coefficients.Add(summ);
                summ = 0;
            }

            return result;
        }

        public int GetDegree()
        {
            var polynomialDegree = 0;
            for (var i = this.coefficients.Count - 1; i >= 0; i--)
            {
                if (Math.Abs(this.coefficients[i]) > 0)
                {
                    polynomialDegree = i;
                    break;
                }
            }

            return polynomialDegree;
        }

        public double? GetCoefficient(int degree)
        {
            double? coefficientOfdegree = null;
            if (degree < this.coefficients.Count && degree >= 0)
            {
                coefficientOfdegree = this.coefficients[degree];
            }

            return coefficientOfdegree;
        }

        public override string ToString()
        {
            var representationPolynomial = string.Empty;
            for (var i = this.coefficients.Count - 1; i >= 0; i--)
            {
                if (i > 1)
                {
                    representationPolynomial += "(" + this.coefficients[i] + "x^" + i + ") + ";
                }
                else if (i == 1)
                {
                    representationPolynomial += "(" + this.coefficients[i] + "x) +";
                }
                else
                {
                    representationPolynomial += "(" + this.coefficients[i] + ")";
                }
            }

            return representationPolynomial;
        }

        public bool ComparePolynomials(Polynomial rightPolynomial)
        {
            return this.coefficients.SequenceEqual(rightPolynomial.coefficients);
        }

        public double Calculate(double powerFactor)
        {
            return this.coefficients.Select((t, i) => (double)Math.Pow(powerFactor, i) * t).Sum();
        }

        public double? FindRoot(double borderLeft, double borderRight, double epsilon)
        {
            var coefficientsPolynom = new Polynomial(this.coefficients);
            double? root = null;
            var halfInterval = (borderLeft + borderRight) / 2;
            if ((coefficientsPolynom.Calculate(borderLeft)
                 * coefficientsPolynom.Calculate(borderRight)) < 0)
            {
                while (Math.Abs(borderRight - borderLeft) > epsilon)
                {
                    if ((coefficientsPolynom.Calculate(borderLeft)
                         * coefficientsPolynom.Calculate(halfInterval)) > 0)
                    {
                        borderLeft = Math.Round(halfInterval, 5);
                    }
                    else
                    {
                        borderRight = Math.Round(halfInterval, 5);
                    }

                    var sum = Math.Abs(Math.Round(borderRight - borderLeft, 5));
                    halfInterval = Math.Round(borderLeft + borderRight, 5) / 2;
                }

                root = halfInterval;
            }

            return root;
        }

        public List<double> CalculatePolynomialSeveralVariables(List<double> variableValue)
        {
            var coefficientsPolynom = new Polynomial(this.coefficients);
            return variableValue.Select(value => coefficientsPolynom.Calculate(value)).ToList();
        }
    }
}