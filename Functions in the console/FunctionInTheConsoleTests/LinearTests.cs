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
            var coefficientsLinearFunction = new LinearFunction(0, 0);


            Assert.Zero(coefficientsLinearFunction.Calculate(2));
        }

        [Test]
        public void VariableIsZero_Calculate_ResultMustBeNumber()
        {
            var coefficientsLinearFunction = new LinearFunction(-3.1, 2.1);


            Assert.IsTrue(coefficientsLinearFunction.Calculate(0).Eq(2.1));
        }

        [Test]
        public void VariableIsNegative_Calculate_ResulMustBeNumber()
        {
            var coefficientsLinearFunction = new LinearFunction(3.6, 2.9);

            Assert.IsTrue(coefficientsLinearFunction.Calculate(-2).Eq(-4.3));
        }

        [Test]
        public void TwoArgumentIsZero_GetDerivative_ResultMustBeZero()
        {
            var coefficientsLinearFunction = new LinearFunction(0, 0);
            var result = coefficientsLinearFunction.GetDerivative();


            Assert.AreEqual(result.ToString(), "0");
        }

        [Test]
        public void FirstArgumentIsZero_GetDerivative_ResultMustBeZero()
        {
            var coefficientsLinearFunction = new LinearFunction(0, 3);


            Assert.AreEqual(coefficientsLinearFunction.GetDerivative().ToString(), "0");
        }

        [Test]
        public void FirstArgumentOfNegative_GetDerivative_ResultMustBeNumber()
        {
            var coefficientsLinearFunction = new LinearFunction(-3.2, 3);


            Assert.AreEqual(coefficientsLinearFunction.GetDerivative().ToString(), "-3,2x");
        }

        [Test]
        public void FirstArgumentIsZero_ToString_ResultMustBeZero()
        {
            var coefficientsLinearFunction = new LinearFunction(0, 3);


            Assert.AreEqual(coefficientsLinearFunction.ToString(), "3");
        }

        [Test]
        public void SecondArgumentIsZero_ToString_ResultMustBeZero()
        {
            var coefficientsLinearFunction = new LinearFunction(3, 0);


            Assert.AreEqual(coefficientsLinearFunction.ToString(), "3x");
        }

        [Test]
        public void ArgumentsOfNegative_ToString_ResultMustBeNumber()
        {
            var coefficientsLinearFunction = new LinearFunction(-3, -2.3);


            Assert.AreEqual(coefficientsLinearFunction.ToString(), "-3x -2,3");
        }

        [Test]
        public void TwoArgumentsIsZero_ToString_ResultMustBeExeption()
        {
            var coefficientsLinearFunction = new LinearFunction(0, 0);

            Assert.AreEqual(coefficientsLinearFunction.ToString(), "0");
        }
    }
}
