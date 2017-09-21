// ReSharper disable InconsistentNaming
namespace FunctionInTheConsoleTests
{
    using FunctionInTheConsole;

    using NUnit.Framework;

    [TestFixture]
    public class CosineTests
    {
        [Test]
        public void ArgumentZero_Calculate_ResultMustBeUnit()
        {
            var variableCosine = new Cosine();

            Assert.AreEqual(1, variableCosine.Calculate(0));
        }

        [Test]
        public void ArgumentOfMinus_Calculate_ResultMustBeNumber()
        {
            var varibleCosine = new Cosine();
            var result = varibleCosine.Calculate(-3);


            Assert.IsTrue(result.Eq(-0.99));
        }

        [Test]
        public void FractionalArgument_Calculate_ResultMastBeNumber()
        {
            var varibleCosine = new Cosine();
            var result = varibleCosine.Calculate(99.025);


            Assert.IsTrue(result.Eq(0.065));
        }

        [Test]
        public void TypeOfCisine_GetDerivative_ResultMustBeTypeOfSinus()
        {
            var varibleCosine = new Cosine();
            var varibleSinus = new Sinus();
            var result = varibleCosine.GetDerivative();


            Assert.AreEqual(varibleSinus.ToString(), result.ToString());
        }
    }
}
