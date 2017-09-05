namespace PolynomTests
{
    using ClassLibrary2;

    using NUnit.Framework;

    [TestFixture]
    public class Tests
    {
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
