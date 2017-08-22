namespace Polynomial
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

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

        public static Polynomial operator +(Polynomial firstPolynomial, Polynomial secondPolynomial)
        {
            var result = new Polynomial();
            double summ;
            if (firstPolynomial.coefficients.Count != secondPolynomial.coefficients.Count)
            {
                var longLength = firstPolynomial.coefficients.Count < secondPolynomial.coefficients.Count
                                     ? secondPolynomial.coefficients.Count
                                     : firstPolynomial.coefficients.Count;
                var shortLength = firstPolynomial.coefficients.Count > secondPolynomial.coefficients.Count
                                      ? secondPolynomial.coefficients.Count
                                      : firstPolynomial.coefficients.Count;
                for (var i = 0; i < longLength; i++)
                {
                    if (i < shortLength)
                    {
                        summ = firstPolynomial.coefficients[i] + secondPolynomial.coefficients[i];
                        result.coefficients.Add(summ);
                    }
                    else
                    {
                        result.coefficients.Add(
                            firstPolynomial.coefficients.Count > secondPolynomial.coefficients.Count
                                ? firstPolynomial.coefficients[i]
                                : secondPolynomial.coefficients[i]);
                    }
                }
            }
            else
            {
                for (var i = 0; i < firstPolynomial.coefficients.Count; i++)
                {
                    summ = firstPolynomial.coefficients[i] + secondPolynomial.coefficients[i];
                    result.coefficients.Add(summ);
                }
            }

            return result;
        }

        public static string operator -(Polynomial polonomOfMinus)
        {
            var result = "-(";
            for (var i = polonomOfMinus.coefficients.Count - 1; i >= 0; i--)
            {
                    if (i > 1)
                    {
                        result += "(" + (polonomOfMinus.coefficients[i] * (-1)) + "x^" + i + ") + ";
                    }
                    else if (i == 1)
                    {
                        result += "(" + (polonomOfMinus.coefficients[i] * (-1)) + "x) +";
                    }
                    else
                    {
                        result += "(" + (polonomOfMinus.coefficients[i] * (-1)) + ")";
                    }
                }
            return result;
        }

        public static Polynomial operator -(Polynomial firstPolynomial, Polynomial secondPolynomial)
        {
            var result = new Polynomial();
            double difference;
            if (firstPolynomial.coefficients.Count != secondPolynomial.coefficients.Count)
            {
                var longLength = firstPolynomial.coefficients.Count < secondPolynomial.coefficients.Count
                                     ? secondPolynomial.coefficients.Count
                                     : firstPolynomial.coefficients.Count;
                var shortLength = firstPolynomial.coefficients.Count > secondPolynomial.coefficients.Count
                                      ? secondPolynomial.coefficients.Count
                                      : firstPolynomial.coefficients.Count;
                for (var i = 0; i < longLength; i++)
                {
                    if (i < shortLength)
                    {
                        difference = firstPolynomial.coefficients[i] - secondPolynomial.coefficients[i];
                        result.coefficients.Add(difference);
                    }
                    else
                    {
                        result.coefficients.Add(
                            firstPolynomial.coefficients.Count > secondPolynomial.coefficients.Count
                                ? firstPolynomial.coefficients[i]
                                : -secondPolynomial.coefficients[i]);
                    }
                }
            }
            else
            {
                for (var i = 0; i < firstPolynomial.coefficients.Count; i++)
                {
                    difference = firstPolynomial.coefficients[i] - secondPolynomial.coefficients[i];
                    result.coefficients.Add(difference);
                }
            }

            return result;
        }

        public static Polynomial operator *(Polynomial firstPolynomial, Polynomial secondPolynomial)
        {
            var result = new Polynomial();
            var corrector = 0;
            var summ = 0.0;
            var values = new double[firstPolynomial.coefficients.Count,
                firstPolynomial.coefficients.Count + secondPolynomial.coefficients.Count - 1];
            for (var i = 0; i < firstPolynomial.coefficients.Count; i++)
            {
                for (var j = 0; j < secondPolynomial.coefficients.Count; j++)
                {
                    values[i, j + corrector] = firstPolynomial.coefficients[i] * secondPolynomial.coefficients[j];
                }

                corrector++;
            }

            for (var j = 0; j < (firstPolynomial.coefficients.Count + secondPolynomial.coefficients.Count - 1); j++)
            {
                for (var i = 0; i < firstPolynomial.coefficients.Count; i++)
                {
                    summ += values[i, j];
                }

                result.coefficients.Add(summ);
                summ = 0;
            }

            return result;
        }

        public string BuildPolynomial()
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


        public bool ComparisonPolynomials(Polynomial secondPolynomial)
        {
            var comparison = true;
            if (this.coefficients.Count != secondPolynomial.coefficients.Count)
            {
                comparison = false;
            }
            else
            {
                for (var i = 0; i < this.coefficients.Count; i++)
                {
                    if (Math.Abs(this.coefficients[i] - secondPolynomial.coefficients[i]) > 0)
                    {
                        comparison = false;
                        break;
                    }
                }
            }

            return comparison;
        }

        public double CalculatePolynomials(double powerFactor)
        {
            return this.coefficients.Select((t, i) => (double)Math.Pow(powerFactor, i) * t).Sum();
        }

        public double? FindRoots(double borderLeft, double borderRight, double epsilon)
        {
            var coefficientsPolynom = new Polynomial(this.coefficients);
            double? roots = null;
            var halfInterval = (borderLeft + borderRight) / 2;
            if ((coefficientsPolynom.CalculatePolynomials(borderLeft)
                 * coefficientsPolynom.CalculatePolynomials(borderRight)) < 0)
            {
                while (Math.Abs(borderRight - borderLeft) > epsilon)
                {
                    if ((coefficientsPolynom.CalculatePolynomials(borderLeft)
                         * coefficientsPolynom.CalculatePolynomials(halfInterval)) > 0)
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

                roots = halfInterval;
            }

            return roots;
        }

        public List<double> CalculatePolynomialOfSeveralVariables(List<double> variableValue)
        {
            var coefficientsPolynom = new Polynomial(this.coefficients);
            return variableValue.Select(value => coefficientsPolynom.CalculatePolynomials(value)).ToList();
        }
    }
}
