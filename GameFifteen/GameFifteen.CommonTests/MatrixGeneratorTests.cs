namespace GameFifteen.Common.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass()]
    public class MatrixGeneratorTests
    {
        [TestMethod()]
        public void IfOutOfMAtrixTest()
        {
            Assert.Fail();
        }
        [TestMethod()]
        public void TestMatrixWithZeroLength()
        {
            var testMatrix = new MatrixGenerator(0);
        }
        [TestMethod()]
        public void TestMatrixWithOneHundredLength()
        {
            var testMatrix = new MatrixGenerator(100);
        }

        [TestMethod()]
        public void TestMatrixWithNegativeLength()
        {
            var testMatrix = new MatrixGenerator(-3);
        }
    }
}
