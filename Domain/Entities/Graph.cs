using CSharpRemoteChallenge.Domain.Exceptions;
using CSharpRemoteChallenge.Domain.Utilities;
using Domain.Algorithms.Factories;
using Domain.Algorithms.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace CSharpRemoteChallenge.Domain.Entities
{
    /// <summary>
    /// Graph of towns (nodes) and routes (edges).
    /// </summary>
    public class Graph
    {
        /// <summary>
        /// Routes (and their towns) in this graph.
        /// The key is a tuple of route's towns.
        /// </summary>
        private readonly IDictionary<TownTuple, Route> _routes;

        /// <summary>
        /// The algorithm used to find all paths in the graph.
        /// </summary>
        private readonly IAllPathsAlgorithm _allPathsAlgorithm;

        /// <summary>
        /// The algorithm used to find the shortest path in the graph.
        /// </summary>
        private readonly IShortestPathAlgorithm _shortestPathAlgorithm;

        /// <summary>
        /// Ctor.
        /// </summary>
        /// <param name="graph">A graph string in the format 'AB5, BC4, CD8'.</param>
        public Graph(string graph)
        {
            _allPathsAlgorithm = AllPathsAlgorithmFactory.Fabricate();
            _shortestPathAlgorithm = ShortestPathAlgorithmFactory.Fabricate();
            _routes = new Dictionary<TownTuple, Route>();

            var tokens = graph.Replace(" ", string.Empty).Split(',');
            foreach (var token in tokens)
            {
                var route = new Route(token);
                _routes.Add(route.Towns, route);
            }
        }

        /// <summary>
        /// Computes the total distance between the routes in the given path.
        /// </summary>
        /// <param name="path">The path with the routes to be computed.</param>
        /// <returns>The total distance between all routes of the path.</returns>
        public int ComputeDistance(Path path)
        {
            return (
                from towns in path.Tuples()
                select GetRoute(towns).Distance
            ).Sum();
        }

        /// <summary>
        /// Lists all available routes in this graph between the given two towns that doesn't exceed the given stops.
        /// </summary>
        /// <param name="origin">First town in path.</param>
        /// <param name="destiny">Last town in path.</param>
        /// <param name="maxStops">Maximum number of stops allowed (optional).</param>
        /// <returns>The available routes between the two towns.</returns>
        public IEnumerable<TraveledPath> ListAvailableRoutes(Town origin, Town destiny, int? maxStops = null)
        {
            return _allPathsAlgorithm.Find(this, origin, destiny, maxStops);
        }

        /// <summary>
        /// Finds the shortest route (in terms of distance to travel) in the graph from the given two towns.
        /// </summary>
        /// <param name="origin">First town in path.</param>
        /// <param name="destiny">Last town in path.</param>
        /// <returns>The shortest route between the two towns.</returns>
        public TraveledPath FindShortestRoute(Town origin, Town destiny)
        {
            return _shortestPathAlgorithm.Find(this, origin, destiny);
        }

        /// <summary>
        /// Returns the routes to the neighbors of the given town.
        /// </summary>
        /// <param name="town">Town to find the route to neighbors.</param>
        /// <returns>The routes to the neighbors of the town.</returns>
        public IEnumerable<Route> GetRoutesToNeighbors(Town town)
        {
            return from route in _routes.Values
                   where route.Towns.Item1 == town
                   select route;
        }

        /// <summary>
        /// Returns the route of the given two towns.
        /// </summary>
        /// <param name="towns">The towns of the route.</param>
        /// <returns>The route of the towns.</returns>
        private Route GetRoute(TownTuple towns)
        {
            if (_routes.ContainsKey(towns))
            {
                return _routes[towns];
            }
            else
            {
                throw new NoSuchRouteException(towns);
            }
        }
    }
}
