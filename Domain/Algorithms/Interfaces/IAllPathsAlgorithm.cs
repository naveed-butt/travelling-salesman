using CSharpRemoteChallenge.Domain.Entities;
using System.Collections.Generic;

namespace Domain.Algorithms.Interfaces
{
    /// <summary>
    /// Interface for the algorithms that finds all possible paths between two given towns in a graph.
    /// </summary>
    internal interface IAllPathsAlgorithm
    {
        /// <summary>
        /// Finds all possible paths between the towns that doens't exceed the maximum stops in the graph.
        /// </summary>
        /// <param name="graph">Graph where the search will happen.</param>
        /// <param name="origin">First town in path.</param>
        /// <param name="destiny">Last town in path.</param>
        /// <param name="maxStops">Maximum number of stops allowed in path (optional).</param>
        /// <returns>All possible paths between the towns in the graph.</returns>
        IEnumerable<TraveledPath> Find(Graph graph, Town origin, Town destiny, int? maxStops = null);
    }
}
