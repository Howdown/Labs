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

        [Test]
        public void Function_ContainsFunctions_ResultMustBeIsTrue()
        {
            var storage = new FunctionsStorage();

            storage.AddFunction("Linear", new LinearFunction(2.3, 3));
            var result = storage.ContainsFunctions("Linear");

            Assert.IsTrue(result);
        }

        [Test]
        public void Function_ContainsFunctions_ResultMustBeIsFalse()
        {
            var storage = new FunctionsStorage();

            storage.AddFunction("linear", new LinearFunction(2.3, 5));
            var result = storage.ContainsFunctions("Linear");

            Assert.IsFalse(result);
        }

        [Test]
        public void Function_GetFunction_ResultMustBeFunction()
        {
            var cos = new CosineFunction();
            var storage = new FunctionsStorage();

            storage.AddFunction("Cos", new CosineFunction());
            var result = storage.GetFunction("Cos");

            Assert.AreEqual(cos.ToString(), result.ToString());
        }

        [Test]
        public void Function_DeleteFunction_ResultMustBeIsTrue()
        {
            var storage = new FunctionsStorage();

            storage.AddFunction("Cos", new CosineFunction());
            storage.DeleteFunction("Cos");
            var result = storage.ContainsFunctions("Cos");

            Assert.IsFalse(result);
        }

    }
}