namespace GameFifteen.Contracts
{
    /// <summary>Interface for matrix generator.</summary>
    public interface IMatrixGenerator
    {
        /// <summary>Generates a matrix.</summary>
        /// <returns>The matrix.</returns>
        int[,] GenerateMatrix();
    }
}
