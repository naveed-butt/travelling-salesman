using Domain.Algorithms.Interfaces;

namespace Domain.Algorithms.Factories
{
    /// <summary>
    /// A factory for the algorithms that finds the shortest path in a graph.
    /// </summary>
    internal static class ShortestPathAlgorithmFactory
    {
        /// <summary>
        /// Constructs and returns the algorithm currently chosen to handle finding the shortest path in a graph.
        /// </summary>
        /// <returns>The algorithm currently chosen to handle finding the shortest path in a graph.</returns>
        internal static IShortestPathAlgorithm Fabricate()
        {
            return new BruteForceShortestPathAlgorithm();
        }
    }
}
