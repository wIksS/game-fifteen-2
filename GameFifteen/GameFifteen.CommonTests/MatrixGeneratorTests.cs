namespace GameFifteen.Common.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using GameFifteen.Common;
    using GameFifteen.Common.Contracts;

    [TestClass()]
    public class MatrixGeneratorTests
    {
        private INumberGenerator numberGenerator = new NumberGenerator(16);

        [TestMethod()]
        public void IfOutOfMAtrixTest()
        {
            Assert.Fail();
        }
        [TestMethod()]
        public void TestMatrixWithZeroLength()
        {
            var testMatrix = new MatrixGenerator(0,numberGenerator);
        }
        [TestMethod()]
        public void TestMatrixWithOneHundredLength()
        {
            var testMatrix = new MatrixGenerator(100, numberGenerator);
        }

        [TestMethod()]
        public void TestMatrixWithNegativeLength()
        {
            var testMatrix = new MatrixGenerator(-3, numberGenerator);
        }
    }
}
