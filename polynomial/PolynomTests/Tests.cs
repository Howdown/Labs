namespace PolynomTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using ClassLibrary2;

    using NUnit.Framework;

    [TestFixture]
    public class Tests
    {
        [Test]
        public void TwoEptyPolynomials_AddInstanceOfTheClass_ValueResultCannotBeEmpty()
        {
            Assert.Throws<ArgumentNullException>(() =>
                    {
                        var first = new Polynomial(null);
                    });
        }

        [Test]
        public void TwoEptyPolynomials_Adding_ResultMustBe()
        {
            Polynomial a = new Polynomial();
            Polynomial b = null;
            Assert.Throws<ArgumentNullException>(
                () =>
                    {
                        var d = a + b;
                    });
        }
        [Test]
        public void TwoEmptyPolynomials_Adding_ResultMustBeEmpty()
        {
            //arrange
            var first = new Polynomial();
            var second = new Polynomial();

            //action
            var result = first + second;

            //assert
            Assert.IsTrue(result.Compare(new Polynomial()));
        }
    }
}
