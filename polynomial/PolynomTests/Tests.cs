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
        public void ListIsNull_InitializesNewInstanceTheClass_ResultMustBeException()
        {
            // assert
            Assert.Throws<ArgumentNullException>(
                () =>
                    {
                        var c = new Polynomial((List<double>)null);
                    });
        }

        [Test]
        public void ParamsIsNull_InitializesNewInstanceTheClass_ResultMustBeException()
        {
            double x = null;
            // assert
            Assert.Throws<ArgumentNullException>(
                () =>
                    {
                        var c = new Polynomial(x);
                    });
        }

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
    }
}
