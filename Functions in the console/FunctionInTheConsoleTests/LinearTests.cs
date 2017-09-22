// ReSharper disable InconsistentNaming
namespace FunctionInTheConsoleTests
{
    using System;
    using System.Collections.Generic;

    using FunctionInTheConsole;

    using NUnit.Framework;

    [TestFixture]
    public class LinearTests
    {
        [Test]
        public void TwoArgumentisZero_Calculate_ResultMustBeZero()
        {
            var coefficients = new List<double>() { 0, 0 };
            var coefficientsLinearFunction = new LinearFunction(coefficients);


            Assert.Zero(coefficientsLinearFunction.Calculate(2));
        }

        [Test]
        public void VariableIsZero_Calculate_ResultMustBeNumber()
        {
            var coefficients = new List<double>() { -3.1, 2.1 };
            var coefficientsLinearFunction = new LinearFunction(coefficients);


            Assert.IsTrue(coefficientsLinearFunction.Calculate(0).Eq(-3.1));
        }

        [Test]
        public void VariableIsNegative_Calculate_ResulMustBeNumber()
        {
            var coefficients = new List<double>() { 3.6, -2.4 };
            var coefficientsLinearFunction = new LinearFunction(coefficients);

            Assert.IsTrue(coefficientsLinearFunction.Calculate(2).Eq(-1.2));
        }

        [Test]
        public void TwoArgumentIsZero_GetDerivative_ResultMustBeZero()
        {
            var coefficients = new List<double>() { 0, 0 };
            var coefficientsLinearFunction = new LinearFunction(coefficients);
            var result = coefficientsLinearFunction.GetDerivative();


            Assert.AreEqual(result.ToString(), "0");
        }

        [Test]
        public void FirstArgumentIsZero_GetDerivative_ResultMustBeZero()
        {
            var coefficients = new List<double>() { 3, 0 };
            var coefficientsLinearFunction = new LinearFunction(coefficients);


            Assert.AreEqual(coefficientsLinearFunction.GetDerivative().ToString(), "0");
        }

        [Test]
        public void FirstArgumentOfNegative_GetDerivative_ResultMustBeNumber()
        {
            var coefficients = new List<double>() { 3, -3.2 };
            var coefficientsLinearFunction = new LinearFunction(coefficients);


            Assert.AreEqual(coefficientsLinearFunction.GetDerivative().ToString(), "-3,2");
        }

        [Test]
        public void FirstArgumentIsZero_ToString_ResultMustBeZero()
        {
            var coefficients = new List<double>() { 3, 0 };
            var coefficientsLinearFunction = new LinearFunction(coefficients);


            Assert.AreEqual(coefficientsLinearFunction.ToString(), "0x + 3");
        }

        [Test]
        public void ArgumentsOfNegative_ToString_ResultMustBeNumber()
        {
            var coefficients = new List<double>() { -3, -2.3 };
            var coefficientsLinearFunction = new LinearFunction(coefficients);


            Assert.AreEqual(coefficientsLinearFunction.ToString(), "-2,3x -3");
        }

        [Test]
        public void OneArgumentsIsNull_ToString_ResultMustBeNumber()
        {
            var coefficients = new List<double>() { -2.3 };
            var coefficientsLinearFunction = new LinearFunction(coefficients);


            Assert.AreEqual(coefficientsLinearFunction.ToString(), "-2,3");
        }

        [Test]
        public void TwoArgumentsIsNull_ToString_ResultMustBeNumber()
        {
            var coefficients = new List<double>();
            var coefficientsLinearFunction = new LinearFunction(coefficients);


            Assert.Throws<ArgumentException>(
                () =>
                    {
                        var result = coefficientsLinearFunction.ToString();
                    });
        }
    }
}
