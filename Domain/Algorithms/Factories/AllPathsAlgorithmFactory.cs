using Domain.Algorithms.Interfaces;

namespace Domain.Algorithms.Factories
{
    /// <summary>
    /// A factory for the algorithms that finds all possible paths in a graph.
    /// </summary>
    internal static class AllPathsAlgorithmFactory
    {
        /// <summary>
        /// Constructs and returns the algorithm currently chosen to handle finding all possible paths in a graph.
        /// </summary>
        /// <returns>The algorithm currently chosen to handle finding all possible paths in a graph.</returns>
        internal static IAllPathsAlgorithm Fabricate()
        {
            return new BruteForceAllPathsAlgorithm();
        }
    }
}
