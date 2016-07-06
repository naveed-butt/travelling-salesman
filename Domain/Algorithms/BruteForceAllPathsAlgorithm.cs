using CSharpRemoteChallenge.Domain.Entities;
using Domain.Algorithms.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Algorithms
{
    /// <summary>
    /// Algorithm that finds all possible paths between two given towns in a graph by travelling through all possible
    /// paths.
    /// </summary>
    internal class BruteForceAllPathsAlgorithm : IAllPathsAlgorithm
    {
        public IEnumerable<TraveledPath> Find(Graph graph, Town origin, Town destiny, int? maxStops = null)
        {
            // Listing one stop neighbors as visited (required to travel further)
            var visited = new List<TraveledPath>();
            foreach (var neighborRoute in graph.GetRoutesToNeighbors(origin))
            {
                var path = new TraveledPath(neighborRoute);
                visited.Add(path);
            }

            // Traveling
            var availableRoutes = TravelPaths(graph, visited, destiny, maxStops);

            // Sorting and returning
            return from availableRoute in availableRoutes
                   orderby availableRoute.Stops, availableRoute.Distance
                   select availableRoute;
        }

        /// <summary>
        /// Travel through all possible paths in the graph.
        /// </summary>
        /// <param name="graph">Graph being traveled.</param>
        /// <param name="visited">Already visited paths.</param>
        /// <param name="destiny">Destiny town.</param>
        /// <param name="maxStops">Maximum number of stops allowed (optional).</param>
        /// <returns>All possible paths in the graph to the given destiny.</returns>
        private IEnumerable<TraveledPath> TravelPaths(
            Graph graph, IEnumerable<TraveledPath> visited, Town destiny, int? maxStops = null)
        {
            // Visits performed on this method call
            var currentVisit = new List<TraveledPath>();

            foreach (var path in visited)
            {
                // If we reached the maximum number of stops
                if (maxStops.HasValue && path.Stops >= maxStops.Value)
                {
                    continue;
                }

                // Current iteration town
                var town = path.LastTown;

                // Routes to current town neighbors
                var neighborRoutes = graph.GetRoutesToNeighbors(town);

                foreach (var neighborRoute in neighborRoutes)
                {
                    // The neighbor town
                    var neighborTown = neighborRoute.Towns.Item2;

                    // Flag indicating if destiny has been reached
                    var reachedDestiny = neighborTown == destiny;

                    // Flag indicating if the neighbor has already been visited
                    var newVisit = !path.Contains(neighborTown);

                    if (reachedDestiny || newVisit)
                    {
                        // Path with the current neighbor
                        var neighborPath = new TraveledPath(path).Append(neighborRoute);

                        // Traveling through neighbor's neighbors
                        var neighborVisits = new List<TraveledPath> { neighborPath };
                        var neighborPaths = TravelPaths(graph, neighborVisits, destiny, maxStops);

                        // Adding neighbor's visits to this method call current visits
                        currentVisit.AddRange(neighborPaths);

                        // Adding this visit to current visits if destiny has been reached
                        if (reachedDestiny)
                        {
                            currentVisit.Add(neighborPath);
                        }
                    }
                }
            }
            return currentVisit;
        }
    }
}
