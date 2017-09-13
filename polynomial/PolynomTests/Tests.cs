// ReSharper disable InconsistentNaming

namespace PolynomTests
{
    using System;
    using System.Collections.Generic;
    using NUnit.Framework;

    using Polynom;

    [TestFixture]
    public class Tests
    {
        [Test]
        public void OneZeroPolynomial_GetDegree_ResultMustBeZero()
        {
            // arrange
            var firstPolynomial = new Polynomial(0, 0, 0);
            var result = firstPolynomial.Degree;

            // assert
            Assert.AreEqual(0, result);
        }

        [Test]
        public void OnePolynomialWithLeadingZeros_GetDegree_ResultMustBe1()
        {
            // arrange
            var firstPolynomial = new Polynomial(3, 5, 0, 0, 0);
            var result = firstPolynomial.Degree;

            // assert
            Assert.AreEqual(1, result);
        }

        [Test]
        public void OnePolynomialContainingZero_GetDegree_ResultMustBe4()
        {
            // arrange
            var firstPolynomial = new Polynomial(3, 5, 0, 1, 8);
            var result = firstPolynomial.Degree;

            // assert
            Assert.AreEqual(4, result);
        }

        [Test]
        public void PolynomialAndNull_Adding_ResultMustBeException()
        {
            // arrange
            var first = new Polynomial(1, 5, 9);
            Polynomial second = null;

            // assert
            Assert.Multiple(
                () =>
                    {
                        Assert.Throws<ArgumentNullException>(
                            () =>
                                {
                                    var result = first + second;
                                });
                        Assert.Throws<ArgumentNullException>(
                            () =>
                                {
                                    var result = second + first;
                                });
                    });
        }

        [Test]
        public void TwoEmptyPolynomials_Adding_ResultMustBeEmpty()
        {
            // arrange
            var first = new Polynomial();
            var second = new Polynomial();

            // action
            var result = first + second;

            // assert
            Assert.IsTrue(result.Compare(new Polynomial()));
        }

        [Test]
        public void ZeroPolynomial_Adding_ResultMustBeValidPolynomial()
        {
            // arrange
            var first = new Polynomial(5, 5, 3, 0, 5);
            var second = new Polynomial(0, 0, 0, 0);

            // action
            var result = first + second;

            // assert
            Assert.IsTrue(result.Compare(first));
        }

        [Test]
        public void TwoPolynomialsDifferentLength_Adding_ResultMustSumTwoPolynomials()
        {
            // arrange
            var first = new Polynomial(5, 5.1, 3.5, 0, 5);
            var second = new Polynomial(0, 1.8, 7, 5);
            var comparison = new Polynomial(5, 6.9, 10.5, 5, 5);

            // action
            var resultFirst = first + second;
            var resultSecond = second + first;

            // assert
            Assert.Multiple(
                () =>
                    {
                        Assert.IsTrue(resultFirst.Compare(comparison));
                        Assert.IsTrue(resultSecond.Compare(comparison));
                    });
        }

        [Test]
        public void NullPolynomial_UnaryMinus_ResultMustBeException()
        {
            // assert
            Assert.Throws<ArgumentNullException>(
                () =>
                    {
                        var result = -(Polynomial)null;
                    });
        }

        [Test]
        public void PolynomialsWithNegativeCoefficients_UnaryMinus_ResultMustBeValidPolynomialsWithUnaryMinus()
        {
            // arrange
            var validPolynomial = new Polynomial(4, -7, 8, -0, -9);
            var unaryMinusPolynomial = new Polynomial(-4, 7, -8, 0, 9);

            // action
            var result = -validPolynomial;

            // assert
            Assert.IsTrue(result.Compare(unaryMinusPolynomial));
        }

        [Test]
        public void EmptyPolynomial_UnaryMinus_ResultMustBeEmpty()
        {
            // arrange
            var first = new Polynomial();

            // action
            var result = -first;

            // assert
            Assert.IsTrue(result.Compare(new Polynomial()));
        }

        [Test]
        public void OnePolynomialsIsNull_Difference_ResultMustBeException()
        {
            // arrange
            var first = new Polynomial(1, 8, 9);
            Polynomial second = null;

            // assert
            Assert.Multiple(
                () =>
                    {
                        Assert.Throws<ArgumentNullException>(
                            () =>
                                {
                                    var result = first - second;
                                });
                        Assert.Throws<ArgumentNullException>(
                            () =>
                                {
                                    var result = second - first;
                                });
                    });
        }

        [Test]
        public void
            FirstPolynomialWithNegativCoefficientsAndSecondPolynomialWithNegativCoeficientsSameOrder_Difference_ResultMustBeDifferencePolynomials()
        {
            // arrange
            var first = new Polynomial(1, 5.4, -7, -3, 5);
            var second = new Polynomial(4, 3.6, -8, 1, -2);
            var resultDifference = new Polynomial(-3, 1.8, 1, -4, 7);

            // action
            var result = first - second;

            // assert
            Assert.IsTrue(result.Compare(resultDifference));
        }

        [Test]
        public void PolynomialsWithDifferenceOrders_Difference_ResultMustBeDifferencePolynomials()
        {
            // arrange
            var first = new Polynomial(1, 5, -7, -3, 5, 8, -7);
            var second = new Polynomial(4, 3, -8, 1, -2);
            var resultFirstDifference = new Polynomial(-3, 2, 1, -4, 7, 8, -7);
            var resultSecondDifference = new Polynomial(3, -2, -1, 4, -7, -8, 7);

            // action
            var resultFirst = first - second;
            var resultSecond = second - first;

            // assert
            Assert.Multiple(
                () =>
                    {
                        Assert.IsTrue(resultFirst.Compare(resultFirstDifference));
                        Assert.IsTrue(resultSecond.Compare(resultSecondDifference));
                    });
        }

        [Test]
        public void TwoEmptyPolynomials_Difference_ResultMustBeEmpty()
        {
            // arrange
            var first = new Polynomial();
            var second = new Polynomial();

            // action
            var result = first - second;

            // assert
            Assert.IsTrue(result.Compare(new Polynomial()));
        }

        [Test]
        public void OnePolynomialsIsNull_Multiplication_ResultMustBeException()
        {
            // arrange
            var first = new Polynomial(1, 8, 9);
            Polynomial second = null;

            // assert
            Assert.Multiple(
                () =>
                    {
                        Assert.Throws<ArgumentNullException>(
                            () =>
                                {
                                    var result = first * second;
                                });
                        Assert.Throws<ArgumentNullException>(
                            () =>
                                {
                                    var result = second * first;
                                });
                    });
        }

        [Test]
        public void FirstPolunomialIsZeroAndSecondPolynomialIsValid_Multiplication_ResultMustBeZeroPolynomial()
        {
            // arrange
            var first = new Polynomial(0, 0);
            var second = new Polynomial(5, -2, 7);
            var resultMultiplication = new Polynomial(0, 0, 0, 0);

            // action
            var result = first * second;

            // assert
            Assert.IsTrue(result.Compare(resultMultiplication));
        }

        [Test]
        public void TwoPolynomialWithNegativeCoefficients_Multiplication_ResultMustBePolynomial()
        {
            // arrange
            var first = new Polynomial(3, -1);
            var second = new Polynomial(5, -2, 7);
            var resultMultiplication = new Polynomial(15, -11, 23, -7);

            // action
            var result = first * second;

            // assert
            Assert.IsTrue(result.Compare(resultMultiplication));
        }

        [Test]
        public void TwoEmptyPolynomials_Multiplication_ResultMustBeException()
        {
            // arrange
            var first = new Polynomial();
            var second = new Polynomial();

            // assert
            Assert.Throws<ArgumentException>(
                () =>
                    {
                        var result = first * second;
                    });
        }

        [Test]
        public void OnePolynomialIsNull_ComparePolynomials_ResultMustBeException()
        {
            // arrange
            var first = new Polynomial(1, 2, 3.4);
            Polynomial second = null;

            // assert
            Assert.Throws<ArgumentNullException>(
                () =>
                    {
                        var result = first.Compare(second);
                    });
        }

        [Test]
        public void TwoEmptyPolynomials_ComparePolynomials_ResultMustBeTrue()
        {
            // arrange
            var first = new Polynomial();
            var second = new Polynomial();

            // assert
            Assert.IsTrue(first.Compare(second));
        }

        [Test]
        public void OneEmptyPolynomials_ComparePolynomials_ResultMustBeTrue()
        {
            // arrange
            var first = new Polynomial(1.2, 0.25, 2.56);
            var second = new Polynomial();

            // assert
            Assert.Multiple(
                () =>
                    {
                        Assert.IsFalse(first.Compare(second));
                        Assert.IsFalse(second.Compare(first));
                    });
        }

        [Test]
        public void TwoSamePolynomials_ComparePolynomials_ResultMustBeTrue()
        {
            // arrange
            var first = new Polynomial(1.2, -0.25, 2.56, 5, -1);
            var second = new Polynomial(1.2, -0.25, 2.56, 5, -1);

            // assert
            Assert.IsTrue(first.Compare(second));
        }

        [Test]
        public void EmptyPolynomials_GetCoefficient_ResultMustBeNull()
        {
            // arrange
            var first = new Polynomial();

            // action
            var result = first.GetCoefficient(0);

            // assert
            Assert.IsNull(result);
        }

        [Test]
        public void Polynomials_GetCoefficient_ResultMustBeCoefficientZeroDegree()
        {
            // arrange
            var first = new Polynomial(7, 2, 5, 3);

            // action
            var result = first.GetCoefficient(0);

            // assert
            Assert.AreEqual(7, result, 0.0001);
        }

        [Test]
        public void Polynomials_GetCoefficient_ResultMustBeNull()
        {
            // arrange
            var first = new Polynomial(0, 2, 5, 3);

            // action
            var result = first.GetCoefficient(4);

            // assert
            Assert.IsNull(result);
        }

        [Test]
        public void PolynomialAndZeroArgument_Calculate_ResultMustBeOne()
        {
            // arrange
            var a = new Polynomial(1, 2.5, 5, 0);
            var x = 0;

            // action 
            var result = a.Calculate(x);

            // assert 
            Assert.AreEqual(1, result, 0.0001);
        }

        [Test]
        public void PolynomialWithZeroCoefficientsAndNegativeArgument_Calculate_ResultMustBeNumber()
        {
            // arrange
            var a = new Polynomial(0, 0, 5, 0, -1, -1, 0, 0);
            var x = -2;

            // action 
            var result = a.Calculate(x);

            // assert 
            Assert.AreEqual(36, result, 0.0001);
        }

        [Test]
        public void EpsilonIsZero_FindRoot_ResultMustBeException()
        {
            // arrange
            var a = 0;
            var b = 2;
            var eps = 0;
            var first = new Polynomial(1, 2);

            // action 
            Assert.Throws<ArgumentOutOfRangeException>(
                () =>
                    {
                        var result = first.FindRoot(a, b, eps);
                    });
        }

        [Test]
        public void PolynomialIsZero_FindRoot_ResultMustBeNull()
        {
            // arrange
            var a = 0;
            var b = 2;
            var eps = 0.0001;
            var first = new Polynomial(0, 0);

            // action 
            var result = first.FindRoot(a, b, eps);

            // assert
            Assert.IsNull(result);
        }

        [Test]
        public void PolynomialWithoutRootsOnInterval_FindRoot_ResultMustBeNull()
        {
            // arrange
            var a = 0;
            var b = 2;
            var eps = 0.001;
            var first = new Polynomial(2, -3, 5);

            // action 
            var result = first.FindRoot(a, b, eps);

            // assert
            Assert.IsNull(result);
        }

        [Test]
        public void Polynomial_FindRoot_ResultMustBeNumber()
        {
            // arrange
            var a = 0;
            var b = 1;
            var eps = 0.0001;
            var first = new Polynomial(1, -3, 0, 1);

            // action 
            var result = first.FindRoot(a, b, eps);

            // assert
            Assert.AreEqual(0.34739, result, 0.000001);
        }

        [Test]
        public void SameEndsTheInterval_FindRoot_ResultMustBeNull()
        {
            // arrange
            var b = 1;
            var eps = 0.0001;
            var first = new Polynomial(1, -3, 0, 1);

            // action 
            var result = first.FindRoot(b, b, eps);

            // assert
            Assert.IsNull(result);
        }

        [Test]
        public void EmptyPolynomial_CalculateSeveralVariables_ResultMustBeNull()
        {
            // arrange
            var first = new Polynomial();
            var atributs = new List<double> { 1, 5.2, 6 };

            // action 
            var result = first.CalculatePolynomialSeveralVariables(atributs);

            // assert
            Assert.AreEqual(new List<double> { 0, 0, 0 }, result);
        }

        [Test]
        public void PolynomialAndCoefficients_CalculateSeveralVariables_ResultMustBeValid()
        {
            // arrange
            var first = new Polynomial(1, 1, 1);
            var atributs = new List<double> { 1, 5.2, 6 };

            // action 
            var result = first.CalculatePolynomialSeveralVariables(atributs);

            // assert
            Assert.AreEqual(new List<double> { 3, 33.24, 43 }, result);
        }

        [Test]
        public void EmptyPolynomial_representationPolynomial_ResultMustBeEmptyString()
        {
            // arrange
            var first = new Polynomial();
            string a = string.Empty;

            // action
            var result = first.ToString();

            // assert
            Assert.AreEqual(a, result);
        }

        [Test]
        public void PolynomialWithZeroCoefficients_representationPolynomial_ResultMustBeString()
        {
            // arrange
            var first = new Polynomial(2, 0, 0, 7);
            string a = "(7x^3) + (2)";

            // action
            var result = first.ToString();

            // assert
            Assert.AreEqual(a, result);
        }

        [Test]
        public void EmptyPolynomial_Copy_ResultMustBeEmpty()
        {
            // arrange
            var first = new Polynomial();

            // action
            var result = first.Copy();

            // assert
            Assert.IsTrue(result.Compare(new Polynomial()));
        }

        [Test]
        public void Polynomial_Copy_ResultMustBePolynomial()
        {
            // arrange
            var first = new Polynomial(2, 5, -9, 0, 0, 6);

            // action
            var result = first.Copy();

            // assert
            Assert.IsTrue(result.Compare(new Polynomial(2, 5, -9, 0, 0, 6)));
        }

        [Test]
        public void TwoDoubleNumbersAndInaccuracy_Compare_ResultMustBeInequality()
        {
            var left = 2.5;
            var right = 2.50001;
            var epsilon = 0.000001;

            var result = left.Eq(right, epsilon);

            Assert.IsFalse(result);
        }

        [Test]
        public void TwoDoubleNumbersAndInaccuracy_CompareDoubleNumber_ResultMustBeEquality()
        {
            var left = 2.5;
            var right = 2.50001;
            var epsilon = 0.001;

            var result = left.Eq(right, epsilon);

            Assert.IsTrue(result);
        }

        [Test]
        public void TwoDoubleNumbersWithoutInaccuracy_Compare_ResultMustBeEquality()
        {
            var left = 2.5;
            var right = 2.5000001;

            var result = left.Eq(right);

            Assert.IsTrue(result);
        }

        [Test]
        public void TwoDoubleNumbersWithoutInaccuracy_Compare_ResultMustBeInequality()
        {
            var left = 2.5;
            var right = 2.501;

            var result = left.Eq(right);

            Assert.IsFalse(result);
        }

        [Test]
        public void TwoDoubleNumbersAndInaccuracy_CheckInequality_ResultMustBeInequality()
        {
            var left = 2.5;
            var right = 2.50001;
            var epsilon = 0.000001;

            var result = left.NotEq(right, epsilon);

            Assert.IsTrue(result);
        }

        [Test]
        public void TwoDoubleNumbersAndInaccuracy_CheckInequality_ResultMustBeEquality()
        {
            var left = 2.5;
            var right = 2.50001;
            var epsilon = 0.001;

            var result = left.NotEq(right, epsilon);

            Assert.IsFalse(result);
        }

        [Test]
        public void TwoDoubleNumbersWithoutInaccuracy_CheckInequality_ResultMustBeEquality()
        {
            var left = 2.5;
            var right = 2.5000001;

            var result = left.NotEq(right);

            Assert.IsFalse(result);
        }

        [Test]
        public void TwoDoubleNumbersWithoutInaccuracy_CheckInequality_ResultMustBeInequality()
        {
            var left = 2.5;
            var right = 2.501;

            var result = left.NotEq(right);

            Assert.IsTrue(result);
        }
    }
}