namespace GameFifteen.Contracts
{
    /// <summary>Interface for equal matrix checker.</summary>
    public interface IEqualMatrixChecker
    {
        /// <summary>Query if 'matrix' is sorted.</summary>
        /// <param name="matrix" type="int[,]">The matrix.</param>
        /// <returns>true if sorted, false if not.</returns>
        bool IsSorted(int[,] matrix);
    }
}
