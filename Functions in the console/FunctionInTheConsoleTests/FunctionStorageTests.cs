// ReSharper disable InconsistentNaming
namespace FunctionInTheConsoleTests
{
    using FunctionInTheConsole;
    using FunctionInTheConsole.Functions;
    using NUnit.Framework;

    [TestFixture]
    public class FunctionStorageTests
    {
        [Test]
        public void SinusFunction_Calculate_ResultMustBeNumber()
        {
            var sinusFunction = new SinusFunction();
            var name = "sinus";
            var storage = new FunctionsStorage();


            storage.AddFunction(name, sinusFunction);


            Assert.AreEqual(storage.CalculateFunction(name, 2), 0.90929742682, 0.0001);
        }

        [Test]
        public void PowerFunction_Calculate_ResultMustBeNumber()
        {
            var powerFunction = new PowerFunction(3);
            var name = "powerFunction";
            var storage = new FunctionsStorage();


            storage.AddFunction(name, powerFunction);


            Assert.AreEqual(storage.CalculateFunction(name, 2.2), 10.648, 0.0001);
        }


        [Test]
        public void LinearFunction_GetDerivative_ResultMustBeNumber()
        {
            var linearFunction = new LinearFunction(2.1, 5);
            var name = "LinearFunction";
            var storage = new FunctionsStorage();


            storage.AddFunction(name, linearFunction);


            Assert.AreEqual(storage.GetDerivativeFunction(name).ToString(), "2,1x");
        }
    }
}