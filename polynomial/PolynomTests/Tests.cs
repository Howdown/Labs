namespace PolynomTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

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
            var a = new Polynomial(1, 5, 9);
            Polynomial b = null;

            // assert
            Assert.Throws<ArgumentNullException>(
                () =>
                    {
                        var d = a + b;
                    });
        }

        [Test]
        public void NullAndPolynomial_Adding_ResultMustBeException()
        {
            // arrange
            Polynomial a = null;
            Polynomial b = new Polynomial(1, 5, 9);

            // assert
            Assert.Throws<ArgumentNullException>(
                () =>
                    {
                        var d = a + b;
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
        public void ValidPolynomialAndZeroPolynomial_Adding_ResultMustBeValidPolynomial()
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
        public void TwoPolynomialsFirstGreaterExtentThanSecond_Adding_ResultMustSumTwoPolynomials()
        {
            // arrange
            var first = new Polynomial(5, 5, 3, 0, 5);
            var second = new Polynomial(0, 1, 7, 5);
            var comparison = new Polynomial(5, 6, 10, 5, 5);

            // action
            var result = first + second;

            // assert
            Assert.IsTrue(result.Compare(comparison));
        }

        [Test]
        public void TwoPolynomialsFirstLessExtentThanSecond_Adding_ResultMustSumTwoPolynomials()
        {
            // arrange
            var first = new Polynomial(1, 8, 9);
            var second = new Polynomial(0, 1, 7, 5, 8);
            var comparison = new Polynomial(1, 9, 16, 5, 8);

            // action
            var result = first + second;

            // assert
            Assert.IsTrue(result.Compare(comparison));
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
        public void ValidPolynomialWithNegativeCoefficients_UnaryMinus_ResultMustBeValidPolynomialsWithUnaryMinus()
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
        public void FirstPolynomialIsValidAndSecondPolynomialIsNull_Difference_ResultMustBeExeption()
        {
            // arrange
            var first = new Polynomial(1, 8, 9);
            Polynomial second = null;

            // assert
            Assert.Throws<ArgumentNullException>(
                () =>
                    {
                        var result = first - second;
                    });
        }

        [Test]
        public void FirstPolynomialIsNullAndSecondPolynomialIsValid_Difference_ResultMustBeExeption()
        {
            // arrange
            Polynomial first = null;
            var second = new Polynomial(1, 5, 7, -3);

            // assert 
            Assert.Throws<ArgumentNullException>(
                () =>
                    {
                        var result = first - second;
                    });
        }

        [Test]
        public void
            FirstPolynomialWithNegativCoefficientsAndSecondPolynomialWithNegativCoeficientsSameOrder_Difference_ResultMustBeDifferencePolynomials()
        {
            // arrange
            var first = new Polynomial(1, 5, -7, -3, 5);
            var second = new Polynomial(4, 3, -8, 1, -2);
            var resultDifference = new Polynomial(-3, 2, 1, -4, 7);

            // action
            var result = first - second;

            // assert
            Assert.IsTrue(result.Compare(resultDifference));
        }

        [Test]
        public void
            FirstPolynomialGreaterOrdersThenSecondPolynomial_Difference_ResultMustBeDifferencePolynomials()
        {
            // arrange
            var first = new Polynomial(1, 5, -7, -3, 5, 8, -7);
            var second = new Polynomial(4, 3, -8, 1, -2);
            var resultDifference = new Polynomial(-3, 2, 1, -4, 7, 8, -7);

            // action
            var result = first - second;

            // assert
            Assert.IsTrue(result.Compare(resultDifference));
        }

        [Test]
        public void
            FirstPolynomialLessOrdersThenSecondPolynomial_Difference_ResultMustBeDifferencePolynomials()
        {
            // arrange
            var first = new Polynomial(1, 5, -7, -3, 5);
            var second = new Polynomial(4, 3, -8, 1, -2, 8, -7);
            var resultDifference = new Polynomial(-3, 2, 1, -4, 7, -8, 7);

            // action
            var result = first - second;

            // assert
            Assert.IsTrue(result.Compare(resultDifference));
        }

        [Test]
        public void TwoEmptyPolynomials_Diference_ResultMustBeEmpty()
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
        public void FirstPolynomialIsValidAndSecondPolynomialIsNull_Multyplication_ResultMustBeExeption()
        {
            // arrange
            var first = new Polynomial(1, 8, 9);
            Polynomial second = null;

            // assert
            Assert.Throws<ArgumentNullException>(
                () =>
                    {
                        var result = first * second;
                    });
        }

        [Test]
        public void FirstPolynomialIsNullAndSecondPolynomialIsValid_Multiplication_ResultMustBeExeption()
        {
            // arrange
            Polynomial first = null;
            var second = new Polynomial(1, 5, 7, -3);

            // assert 
            Assert.Throws<ArgumentNullException>(
                () =>
                    {
                        var result = first * second;
                    });
        }

        [Test]
        public void FirstPolunomialIsZeroAndSecondPolynomialIsValid_Multyplication_ResultMustBeZeroPolynomial()
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
        public void TwoPolynomialWithNegativeCoefficients_Multyplication_ResultMustBePolynomial()
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
        public void TwoEmptyPolynomials_Multiplication_ResultMustBeExeption()
        {
            // arrange
            var first = new Polynomial();
            var second = new Polynomial();

            // assert
            Assert.Throws<ArgumentOutOfRangeException>(
                () =>
                    {
                       var result = first * second;
                    });
        }

        [Test]
        public void EmptyPolynomials_GetCoeficients_ResultMustBeNull()
        {
            // arrange
            var first = new Polynomial();

            // action
            var result = first.GetCoefficient(0);

            // assert
            Assert.IsTrue(result == null);
        }

        [Test]
        public void Polynomials_GetCoeficients_ResultMustBeZeroDegree()
        {
            // arrange
            var first = new Polynomial(0, 2, 5, 3);

            // action
            var result = first.GetCoefficient(0);

            // assert
            Assert.IsTrue(result == 0);
        }

        [Test]
        public void Polynomials_GetCoeficients_ResultMustBeNull()
        {
            // arrange
            var first = new Polynomial(0, 2, 5, 3);

            // action
            var result = first.GetCoefficient(4);

            // assert
            Assert.IsTrue(result == null);
        }

        [Test]
        public void PolynomialAndZeroArgument_Calculate_ResultMustBeOne()
        {
            // arrange
            var a = new Polynomial(1, 2, 5, 0);
            var x = 0;

            // action 
            var result = a.Calculate(x);

            // assert 
            Assert.IsTrue(result == 1);
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
            Assert.IsTrue(result == 36);
        }

        [Test]
        public void EpsilonIsZero_FindRoot_ResultMustBeExeption()
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
            Assert.IsTrue(result == null);
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
            Assert.IsTrue(result == null);
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
            Assert.IsTrue(result == 0.34739);
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
            Assert.IsTrue(result == null);
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
            Assert.IsTrue(result.SequenceEqual(new List<double> { 0, 0, 0 }));
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
            Assert.IsTrue(result.SequenceEqual(new List<double> { 3, 33.24, 43 }));
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
            Assert.IsTrue(result.SequenceEqual(a));
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
            Assert.IsTrue(result.SequenceEqual(a));
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
    }
}
