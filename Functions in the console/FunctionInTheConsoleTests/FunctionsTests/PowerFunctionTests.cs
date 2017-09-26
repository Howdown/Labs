// ReSharper disable InconsistentNaming
namespace FunctionInTheConsoleTests.FunctionsTests
{
    using FunctionInTheConsole;
    using FunctionInTheConsole.Functions;

    using NUnit.Framework;

    [TestFixture]
    public class PowerFunctionTests
    {
        [Test]
        public void ArgumentIsZero_Calculate_ResultMustBeZero()
        {
            var number = new PowerFunction(4);


            Assert.Zero(number.Calculate(0));
        }

        [Test]
        public void DegreeIsZero_Calculate_ResultMustBeZero()
        {
            var number = new PowerFunction(0);


            Assert.IsTrue(number.Calculate(2.2).Eq(1));
        }

        [Test]
        public void ArgumentOfNegativeAndEvenDegree_Calculate_ResultMustBeNonNegativeNumber()
        {
            var number = new PowerFunction(2);


            Assert.IsTrue(number.Calculate(-2.9).Eq(8.41));
        }

        [Test]
        public void ArgumentOfNegativeAndOddDegree_Calculate_ResultMustBeNegativeNumber()
        {
            var number = new PowerFunction(3);


            Assert.IsTrue(number.Calculate(-2.9).Eq(-24.389));
        }

        [Test]
        public void DegreeNegative_Calculate_ResultMustBeNumber()
        {
            var number = new PowerFunction(-1);


            Assert.IsTrue(number.Calculate(-2.9).Eq(-0.3448));
        }

        [Test]
        public void DegreeIsZero_GetDerivative_ResultMustBeNumber()
        {
            var number = new PowerFunction(0);


            Assert.AreEqual(number.GetDerivative().ToString(), "0");
        }

        [Test]
        public void DegreeIsNumber_GetDerivative_ResultMustBeNumber()
        {
            var number = new PowerFunction(3);


            Assert.AreEqual(number.GetDerivative().ToString(), "3x^2");
        }

        [Test]
        public void DegreeOfNegative_GetDerivative_ResultMustBeNumber()
        {
            var number = new PowerFunction(-3);


            Assert.AreEqual(number.GetDerivative().ToString(), "-3x^-4");
        }

        [Test]
        public void DegreeIsZeroMultiplierIsZero_ToString_ResultMustBeZero()
        {
            var number = new PowerFunction(0);


            Assert.AreEqual(number.ToString(), "0");
        }

        [Test]
        public void DegreeIsZero_ToString_ResultMustBeNumber()
        {
            var number = new PowerFunction(1);


            Assert.AreEqual(number.GetDerivative().ToString(), "1");
        }

        [Test]
        public void DegreeIsNegative_ToString_ResultMustBeNumber()
        {
            var number = new PowerFunction(-2);


            Assert.AreEqual(number.ToString(), "x^-2");
        }

        [Test]
        public void DegreeAndMultiplierOfValid_ToString_ResultMustBeNumber()
        {
            var number = new PowerFunction(5);


            Assert.AreEqual(number.GetDerivative().ToString(), "5x^4");
        }
    }
}
