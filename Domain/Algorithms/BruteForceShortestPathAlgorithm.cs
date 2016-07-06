using CSharpRemoteChallenge.Domain.Entities;
using Domain.Algorithms.Interfaces;
using System.Linq;

namespace Domain.Algorithms
{
    /// <summary>
    /// Algorithm that finds the shortest path between two given towns in a graph by travelling through all possible
    /// paths.
    /// </summary>
    internal class BruteForceShortestPathAlgorithm : IShortestPathAlgorithm
    {
        public TraveledPath Find(Graph graph, Town origin, Town destiny)
        {
            var bruteForceAlgorithm = new BruteForceAllPathsAlgorithm();

            var availableRoutes = bruteForceAlgorithm.Find(graph, origin, destiny);

            return (
                from availableRoute in availableRoutes
                orderby availableRoute.Distance, availableRoute.Stops
                select availableRoute
            ).FirstOrDefault();
        }
    }
}
