using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameFifteen.Common;

namespace GameFifteen.Logic.Tests
{
    [TestClass()]
    public class EmptyCellMoverTests
    {
        [TestMethod()]
        public void MoveEmptyCellTest()
        {
            SortedMatrixGenerator testMatrixGenerator = new SortedMatrixGenerator(4);
            int[,] matrix = testMatrixGenerator.GenerateMatrix();
            Point point=new Point(3,3);
            Point newPoint = new Point(2, 3);
            EmptyCellMover.MoveEmptyCell(point, newPoint, matrix);

            Assert.IsTrue(matrix[3, 3] == 12 && matrix[2, 3] == 16);
        }

        [TestMethod()]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void MoveEmptyOutOfRangeTest()
        {
            SortedMatrixGenerator testMatrixGenerator = new SortedMatrixGenerator(4);
            int[,] matrix = testMatrixGenerator.GenerateMatrix();
            Point point = new Point(3, 4);
            Point newPoint = new Point(2, 3);

            EmptyCellMover.MoveEmptyCell(point, newPoint, matrix);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MoveEmptyCellNullPointTest()
        {
            SortedMatrixGenerator testMatrixGenerator = new SortedMatrixGenerator(5);
            int[,] matrix = testMatrixGenerator.GenerateMatrix();
            Point point = null;
            Point newPoint = new Point(2, 3);

            EmptyCellMover.MoveEmptyCell(point, newPoint, matrix);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MoveEmptyCellNullMatrixTest()
        {
            int[,] matrix = null;
            Point point = new Point(2, 3);
            Point newPoint = new Point(2, 3);

            EmptyCellMover.MoveEmptyCell(point, newPoint, matrix);
        }
    }
}
