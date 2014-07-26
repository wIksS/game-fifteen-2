using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameFifteen.Common;

namespace GameFifteen.Logic.Tests
{
    [TestClass()]
    public class OutOfMatrixCheckerTests
    {
        [TestMethod()]
        public void CheckIfOutOfMatrixTrueTest()
        {
            int matrixSize=4;
            Point point=new Point(2, 4);
            
            Assert.IsTrue(OutOfMatrixChecker.CheckIfOutOfMatrix(point, matrixSize));
        }

        [TestMethod()]
        public void CheckIfOutOfMatrixFalseTest()
        {
            int matrixSize = 4;
            Point point = new Point(2, 3);

            Assert.IsFalse(OutOfMatrixChecker.CheckIfOutOfMatrix(point, matrixSize));
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CheckIfOutOfMatrixInvalidSizeTest()
        {
            int matrixSize = 0;
            Point point = new Point(2, 3);

            OutOfMatrixChecker.CheckIfOutOfMatrix(point, matrixSize);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CheckIfOutOfMatrixNullTest()
        {
            int matrixSize = 4;
            Point point = null;

            OutOfMatrixChecker.CheckIfOutOfMatrix(point, matrixSize);
        }
    }
}
