namespace GameFifteen.Tests.Logic
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using GameFifteen.Common;
    using GameFifteen.Contracts;
    using GameFifteen.Logic;

    [TestClass()]
    public class OutOfMatrixCheckerTests
    {
        private Point point;
        private int matrixLength;

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void OutOfMatrixCheckerShouldThrowExceptionOnZeroMatrixLengthPassed()
        {
            this.point = new Point(0, 0);
            this.matrixLength = 0;
            OutOfMatrixChecker.CheckIfOutOfMatrix(point,matrixLength);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void OutOfMatrixCheckerShouldThrowExceptionOnNullPointPassed()
        {
            this.point = null;
            this.matrixLength = 16;
            OutOfMatrixChecker.CheckIfOutOfMatrix(point, matrixLength);
        }

        [TestMethod()]
        public void OutOfMatrixCheckerShouldRetrunTrueOnPointOutsideMatrix()
        {
            this.point = new Point(4, 0);
            this.matrixLength = 4;
            Assert.AreEqual(true,OutOfMatrixChecker.CheckIfOutOfMatrix(point, matrixLength));
        }

        [TestMethod()]
        public void OutOfMatrixCheckerShouldRetrunFalseOnPointInsideMatrix()
        {
            this.point = new Point(3, 0);
            this.matrixLength = 4;
            Assert.AreEqual(false, OutOfMatrixChecker.CheckIfOutOfMatrix(point, matrixLength));
        }
    }
}
