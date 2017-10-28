// ReSharper disable InconsistentNaming
namespace FunctionInTheConsoleTests
{
    using FunctionInTheConsole.Functions;

    using NUnit.Framework;

    [TestFixture]
    public class LinearFunctionTests
    {
        [Test]
        public void TwoArgumentsAreZero_Calculate_ResultMustBeZero()
        {
            var coefficientsLinearFunction = new LinearFunction(0, 0);


            Assert.Zero(coefficientsLinearFunction.Calculate(2));
        }

        [Test]
        public void VariableIsZero_Calculate_ResultMustBeNumber()
        {
            var coefficientsLinearFunction = new LinearFunction(-3.1, 2.1);


            Assert.AreEqual(coefficientsLinearFunction.Calculate(0), 2.1, 0.1);
        }

        [Test]
        public void VariableIsNegative_Calculate_ResultMustBeNumber()
        {
            var coefficientsLinearFunction = new LinearFunction(3.6, 2.9);

            Assert.AreEqual(coefficientsLinearFunction.Calculate(-2), -4.3, 0.1);
        }

        [Test]
        public void TwoArgumentAreZero_GetDerivative_ResultMustBeZero()
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
        public void ArgumentsAreNegative_ToString_ResultMustBeNumber()
        {
            var coefficientsLinearFunction = new LinearFunction(-3, -2.3);


            Assert.AreEqual(coefficientsLinearFunction.ToString(), "-3x -2,3");
        }

        [Test]
        public void TwoArgumentsAreZero_ToString_ResultMustBeZero()
        {
            var coefficientsLinearFunction = new LinearFunction(0, 0);

            Assert.AreEqual(coefficientsLinearFunction.ToString(), "0");
        }
    }
}
