namespace PolynomTests
{
    using System;
    using System.Collections.Generic;
    using NUnit.Framework;
    using Polynom;

    [TestFixture]
    public class Tests
    {
        [Test]
        public void TwoEptyPolynomials_AddInstanceOfTheClass_ValueResultCannotBeEmpty()
        {
            // assert
            Assert.Throws<ArgumentNullException>(() =>
                    {
                        var first = new Polynomial(null);
                    });
        }

        [Test]
        public void TwoEptyPolynomials_Adding_ResultMustBe()
        {
            // arrange
            var a = new Polynomial();
            Polynomial b = null;

            // assert
            Assert.Throws<ArgumentNullException>(
                () =>
                    {
                        var d = a + b;
                    });
        }

        [Test]
        public void TwoEmptyPolynomials_Adding_ResultMustBeEmpty()
        {
            // arrange
            var first = new Polynomial();
            var second = new Polynomial();

            // action
            var result = first + second;

            // assert
            Assert.IsTrue(result.Compare(new Polynomial()));
        }
    }
}
