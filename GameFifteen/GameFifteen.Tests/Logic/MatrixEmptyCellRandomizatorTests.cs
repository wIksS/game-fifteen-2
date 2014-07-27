namespace GameFifteen.Tests.Logic
{
    using System;
    using GameFifteen.Contracts;
    using GameFifteen.Logic;
    using GameFifteen.Common;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass()]
    public class MatrixEmptyCellRandomizatorTests
    {
        [TestMethod(), Timeout(580)]
        public void IsRandomTest()
        {
            IMatrixGenerator matrixGenerator = new SortedMatrixGenerator(4);
            var firstRandomMatrix = matrixGenerator.GenerateMatrix();
            var secondRandomMatrix = matrixGenerator.GenerateMatrix();

            MatrixEmptyCellRandomizator matrixRandomizator = new MatrixEmptyCellRandomizator();
            matrixRandomizator.Randomize(firstRandomMatrix);
            matrixRandomizator.Randomize(secondRandomMatrix);

            MatrixComparer comparer = new MatrixComparer();

            Assert.IsFalse(comparer.AreEqual(firstRandomMatrix, secondRandomMatrix));
        }

        [TestMethod()]
        public void IsRandomEveryInstanceTest()
        {
            IMatrixGenerator matrixGenerator = new SortedMatrixGenerator(4);
            var firstRandomMatrix = matrixGenerator.GenerateMatrix();
            var secondRandomMatrix = matrixGenerator.GenerateMatrix();

            MatrixEmptyCellRandomizator matrixRandomizator = new MatrixEmptyCellRandomizator();
            matrixRandomizator.Randomize(firstRandomMatrix);

            matrixRandomizator = new MatrixEmptyCellRandomizator();
            matrixRandomizator.Randomize(secondRandomMatrix);

            MatrixComparer comparer = new MatrixComparer();

            Assert.IsFalse(comparer.AreEqual(firstRandomMatrix, secondRandomMatrix));
        }

        [TestMethod()]
        public void IsRandomizedEmptyCellTest()
        {
            IMatrixGenerator matrixGenerator = new SortedMatrixGenerator(4);
            int[,] matrix = matrixGenerator.GenerateMatrix();
            MatrixEmptyCellRandomizator matrixRandomizator = new MatrixEmptyCellRandomizator();
            matrixRandomizator.Randomize(matrix);
            MatrixComparer comparer = new MatrixComparer();

            Assert.IsFalse(comparer.IsSorted(matrix));
        }

        [TestMethod()]
        public void RandomizOneCellTest()
        {
            IMatrixGenerator matrixGenerator = new SortedMatrixGenerator(1);
            int[,] matrix = matrixGenerator.GenerateMatrix();
            MatrixEmptyCellRandomizator matrixRandomizator = new MatrixEmptyCellRandomizator();
            matrixRandomizator.Randomize(matrix);
        }

        [TestMethod()]
        public void RandomizZeroCellTest()
        {
            IMatrixGenerator matrixGenerator = new SortedMatrixGenerator(0);
            int[,] matrix = matrixGenerator.GenerateMatrix();
            MatrixEmptyCellRandomizator matrixRandomizator = new MatrixEmptyCellRandomizator();
            matrixRandomizator.Randomize(matrix);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IsParameterNullOrEmptyTest()
        {
            int[,] matrix = null;
            MatrixEmptyCellRandomizator matrixRandomizator = new MatrixEmptyCellRandomizator();
            matrixRandomizator.Randomize(matrix);
        }
    }
}
