namespace GameFifteen.Tests.Logic
{
    using System;
    using GameFifteen.Common;
    using GameFifteen.Contracts;
    using GameFifteen.Logic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass()]
    public class MatrixEmptyCellRandomizatorTests
    {
        private readonly INumberGenerator numberGenerator = new NumberGenerator(16);

        [TestMethod()]
        public void RandomizeTest()
        {
            IMatrixGenerator matrixGenerator = new MatrixGenerator(4, this.numberGenerator);

            var firstMatrix = matrixGenerator.GenerateMatrix();
            var secondMatrix = matrixGenerator.GenerateMatrix();

            MatrixEmptyCellRandomizator matrixRandomizator = new MatrixEmptyCellRandomizator();
            MatrixEmptyCellRandomizator matrixRandomizator2 = new MatrixEmptyCellRandomizator();

            Point emptyPoint = matrixRandomizator.Randomize(firstMatrix);
            Point emptyPoint2 = matrixRandomizator2.Randomize(secondMatrix);

            Assert.AreEqual(firstMatrix, secondMatrix);
        }

        [TestMethod()]
        public void IsRandomizedEmptyCellTest()
        {
            IMatrixGenerator matrixGenerator = new MatrixGenerator(4, this.numberGenerator);
            IMatrixGenerator testMatrixGenerator = new SortedMatrixGenerator(4);

            var firstMatrix = matrixGenerator.GenerateMatrix();

            MatrixEmptyCellRandomizator matrixRandomizator = new MatrixEmptyCellRandomizator();
            Point emptyPoint = matrixRandomizator.Randomize(firstMatrix);

            Assert.AreNotEqual(firstMatrix, testMatrixGenerator);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IsParameterNullOrEmptyTest()
        {
            int[,] matrix = null;
            MatrixEmptyCellRandomizator matrixRandomizator = new MatrixEmptyCellRandomizator();
            Point emptyPoint = matrixRandomizator.Randomize(matrix);
        }
    }
}
