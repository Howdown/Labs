// ReSharper disable InconsistentNaming
namespace FunctionInTheConsoleTests
{
    using FunctionInTheConsole;

    using NUnit.Framework;

    [TestFixture]
    public class SinusTests
    {
        [Test]
        public void ArgumentZero_Calculate_ResultMustBeZero()
        {
            var variableSinus = new Sinus();


            Assert.Zero(variableSinus.Calculate(0));
        }

        [Test]
        public void ArgumentOfMinus_Calculate_ResultMustBeNumber()
        {
            var variableSinus = new Sinus();
            var result = variableSinus.Calculate(-2);
            var validResult = -0.909;


            Assert.IsTrue(result.Eq(validResult));
        }

        [Test]
        public void FractionalArgument_Calculate_ResultMustBeNumber()
        {
            var variableSinus = new Sinus();
            var result = variableSinus.Calculate(999.09);
            var validResult = 0.063;


            Assert.IsTrue(result.Eq(validResult));
        }

        [Test]
        public void TypeOfSinus_GetDerivative_ResultMustBeTypeOfCosine()
        {
            var variableOfSinus = new Sinus();
            var result = new Cosine();
            Assert.AreEqual(result.ToString(), variableOfSinus.GetDerivative().ToString());
        }
    }
}


