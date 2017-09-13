namespace Polynom
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    /// <summary>
    /// this class provides functions
    /// for working with polynomials
    /// </summary>
    public class Polynomial
    {
        private List<double> coefficients;

        /// <summary>
        /// Initializes a new instance of the <see cref="Polynomial"/> class. 
        /// </summary>
        /// <param name="index">coefficients polynomial</param>
        public Polynomial(List<double> index)
        {
            this.coefficients = index;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Polynomial"/> class. 
        /// </summary>
        /// <param name="coefficients">coefficients polynomial with used params</param>
        public Polynomial(params double[] coefficients)
        {
            this.coefficients = coefficients.ToList();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Polynomial"/> class. 
        /// </summary>
        public Polynomial()
        {
            this.coefficients = new List<double>();
        }

        public int Degree
        {
            get
            {
                var polynomialDegree = 0;
                for (var i = this.coefficients.Count - 1; i >= 0; i--)
                {
                    if (Math.Abs(this.coefficients[i]) > 0)
                    {
                        polynomialDegree = i;
                        break;
                    }

                    polynomialDegree = 0;
                }

                return polynomialDegree;
            }
        }

        public double? this[int index]
        {
            get
            {
                double? coefficient = null;

                if (index >= 0 && index < this.coefficients.Count)
                {
                    coefficient = this.coefficients[index];
                }

                return coefficient;
            }
        }

        /// <summary>
        /// this method allows you 
        /// to add two polynomial
        /// </summary>
        /// <param name="leftPolynomial">the polynomial on the left of the sign</param>
        /// <param name="rightPolynomial">the polynomial on the right of the sign</param>
        /// <returns>the sum of polynomials</returns>
        public static Polynomial operator +(Polynomial leftPolynomial, Polynomial rightPolynomial)
        {
            if (leftPolynomial == null)
            {
                throw new ArgumentNullException(nameof(leftPolynomial));
            }

            if (rightPolynomial == null)
            {
                throw new ArgumentNullException(nameof(rightPolynomial));
            }

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

        /// <summary>
        /// this method allows get the unary minus
        /// of the coefficients of the polynomial 
        /// </summary>
        /// <param name="polynomialOfMinus">coefficients polynomial </param>
        /// <returns>coefficients polynomial with unary minus</returns>
        public static Polynomial operator -(Polynomial polynomialOfMinus)
        {
            if (polynomialOfMinus == null)
            {
                throw new ArgumentNullException(nameof(polynomialOfMinus));
            }

            var coefficients = polynomialOfMinus.coefficients.Select(t => (-1) * t).ToList();
            return new Polynomial(coefficients);
        }

        /// <summary>
        /// this method allows to produce the difference of polynomials
        /// </summary>
        /// <param name="leftPolynomial">coefficients polynomial which is located to the left of the sign</param>
        /// <param name="rightPolynomial">coefficients polynomial which is located to the right of the sign</param>
        /// <returns>difference polynomials</returns>
        public static Polynomial operator -(Polynomial leftPolynomial, Polynomial rightPolynomial)
        {
            if (leftPolynomial == null)
            {
                throw new ArgumentNullException(nameof(leftPolynomial));
            }

            if (rightPolynomial == null)
            {
                throw new ArgumentNullException(nameof(rightPolynomial));
            }

            return leftPolynomial + (-rightPolynomial);
        }

        /// <summary>
        /// this method allow the multiplication of two polynomials
        /// </summary>
        /// <param name="leftPolynomial">coefficients polynomial which is located to the left of the sign</param>
        /// <param name="rightPolynomial">coefficients polynomials which is located to the right of the sign</param>
        /// <returns>the product of the polynomials</returns>
        public static Polynomial operator *(Polynomial leftPolynomial, Polynomial rightPolynomial)
        {
            if (leftPolynomial == null)
            {
                throw new ArgumentNullException(nameof(leftPolynomial));
            }

            if (rightPolynomial == null)
            {
                throw new ArgumentNullException(nameof(rightPolynomial));
            }

            if (leftPolynomial.coefficients.Count <= 0)
            {
                throw new ArgumentException("The dimension of the polynomial cannot be zero", nameof(leftPolynomial));
            }

            if (rightPolynomial.coefficients.Count <= 0)
            {
                throw new ArgumentException("The dimension of the polynomial cannot be zero", nameof(rightPolynomial));
            }

            var result = new Polynomial();
            var leftCoefficients = leftPolynomial.coefficients;
            var rightCoefficients = rightPolynomial.coefficients;
            var corrector = 0;
            var summ = 0.0;
            var values = new double[leftCoefficients.Count, leftCoefficients.Count + rightCoefficients.Count - 1];
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

        public double? GetCoefficient(int degree)
        {
            double? coefficientOfdegree = null;
            if (degree < this.coefficients.Count && degree >= 0)
            {
                coefficientOfdegree = this.coefficients[degree];
            }

            return coefficientOfdegree;
        }

        public bool Compare(Polynomial secondPolynomial)
        {
            if (secondPolynomial == null)
            {
                throw new ArgumentNullException(nameof(secondPolynomial));
            }

            var equal = true;
            if (this.coefficients.Count == secondPolynomial.coefficients.Count)
            {
                for (var i = 0; i < this.coefficients.Count; i++)
                {
                    if (this.coefficients[i].NotEq(secondPolynomial.coefficients[i]))
                    {
                        equal = false;
                        break;
                    }
                }
            }
            else
            {
                equal = false;
            }

            return equal;
        }

        public double Calculate(double powerFactor)
        {
            return this.coefficients.Select((t, i) => Math.Pow(powerFactor, i) * t).Sum();
        }

        /// <summary>
        /// Allow find a root of the polynomial
        /// </summary>
        /// <param name="borderLeft">Left boundary value</param>
        /// <param name="borderRight">Right boundary value</param>
        /// <param name="epsilon">Precision</param>
        /// <returns>Root polynomial</returns>
        public double? FindRoot(double borderLeft, double borderRight, double epsilon)
        {
            if (epsilon <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(epsilon));
            }

            if (borderLeft > borderRight)
            {
                var intermediateValue = borderLeft;
                borderLeft = borderRight;
                borderRight = intermediateValue;
            }

            var coefficientsPolynom = new Polynomial(this.coefficients);
            double? root = null;
            var halfInterval = (borderLeft + borderRight) / 2;
            if ((coefficientsPolynom.Calculate(borderLeft) * coefficientsPolynom.Calculate(borderRight)) < 0)
            {
                while (Math.Abs(borderRight - borderLeft) > epsilon)
                {
                    if ((coefficientsPolynom.Calculate(borderLeft) * coefficientsPolynom.Calculate(halfInterval)) > 0)
                    {
                        borderLeft = Math.Round(halfInterval, 5);
                    }
                    else
                    {
                        borderRight = Math.Round(halfInterval, 5);
                    }

                    halfInterval = Math.Round(borderLeft + borderRight, 5) / 2;
                }

                root = halfInterval;
            }

            return root;
        }

        /// <summary>
        /// This method allow the calculate the values of a polynomial
        /// </summary>
        /// <param name="variableValue">The values of the unknown</param>
        /// <returns>Values of a polynomial</returns>
        public List<double> CalculatePolynomialSeveralVariables(List<double> variableValue)
        {
            return variableValue.Select(this.Calculate).ToList();
        }

        /// <summary>
        /// this method allow to translate the parameters in string
        /// </summary>
        /// <returns>string parameter</returns>
        public override string ToString()
        {
            var representationPolynomial = string.Empty;
            for (var i = this.coefficients.Count - 1; i >= 0; i--)
            {
                if (this.coefficients[i].NotEq(0))
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
            }

            return representationPolynomial;
        }

        public Polynomial Copy()
        {
            var secondPolynomial = new Polynomial();
            foreach (var coeficient in this.coefficients)
            {
                secondPolynomial.coefficients.Add(coeficient);
            }

            return secondPolynomial;
        }
    }
}