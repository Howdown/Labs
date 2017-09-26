// ReSharper disable InconsistentNaming
namespace FunctionInTheConsoleTests.FunctionsTests
{
    using FunctionInTheConsole;
    using FunctionInTheConsole.Functions;

    using NUnit.Framework;

    [TestFixture]
    public class CosineFunctionTests
    {
        [Test]
        public void ArgumentZero_Calculate_ResultMustBeUnit()
        {
            var variableCosine = new CosineFunction();

            Assert.AreEqual(1, variableCosine.Calculate(0));
        }

        [Test]
        public void ArgumentOfMinus_Calculate_ResultMustBeNumber()
        {
            var variableCosine = new CosineFunction();
            var result = variableCosine.Calculate(-3);


            Assert.AreEqual(result, -0.99, 0.001);
        }

        [Test]
        public void FractionalArgument_Calculate_ResultMastBeNumber()
        {
            var variableCosine = new CosineFunction();
            var result = variableCosine.Calculate(99.025);


            Assert.AreEqual(result, 0.064, 0.001);
        }

        [Test]
        public void TypeOfCosine_GetDerivative_ResultMustBeTypeOfSinus()
        {
            var variableCosine = new CosineFunction();
            var variableSinus = new SinusFunction();
            var result = variableCosine.GetDerivative();


            Assert.AreEqual(variableSinus.ToString(), result.ToString());
        }
    }
}
