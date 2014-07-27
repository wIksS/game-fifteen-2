namespace GameFifteen.Contracts
{
    /// <summary>Interface for number generator.</summary>
    public interface INumberGenerator
    {
        /// <summary>Gets a number.</summary>
        /// <param name="number" type="int">Number.</param>
        /// <returns>The number.</returns>
        int GetNumber(int number);
    }
}
