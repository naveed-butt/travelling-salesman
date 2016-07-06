using CSharpRemoteChallenge.Domain.Entities;

namespace Domain.Algorithms.Interfaces
{
    /// <summary>
    /// Interface for the algorithms that finds the shortest path between two given towns in a graph.
    /// </summary>
    internal interface IShortestPathAlgorithm
    {
        /// <summary>
        /// Finds the shortest path between the towns.
        /// </summary>
        /// <param name="graph">Graph where the search will happen.</param>
        /// <param name="origin">First town in path.</param>
        /// <param name="destiny">Last town in path.</param>
        /// <param name="maxStops">Maximum number of stops allowed in path (optional).</param>
        /// <returns>The shortest path between the towns.</returns>
        TraveledPath Find(Graph graph, Town origin, Town destiny);
    }
}
