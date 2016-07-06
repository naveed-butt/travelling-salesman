using CSharpRemoteChallenge.Domain.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace CSharpRemoteChallenge.Domain.Entities
{
    /// <summary>
    /// A path of towns with the total traveled distance.
    /// </summary>
    public class TraveledPath
    {
        /// <summary>
        /// Ordered list of routes in this path.
        /// </summary>
        private readonly IList<Route> _routes;

        /// <summary>
        /// The total distance of the routes in this path.
        /// </summary>
        public int Distance
        {
            get
            {
                return (
                    from route in _routes
                    select route.Distance
                ).Sum();
            }
        }

        /// <summary>
        /// The number of stops in this path.
        /// </summary>
        public int Stops
        {
            get
            {
                return _routes.Count;
            }
        }

        /// <summary>
        /// The last town in this path.
        /// </summary>
        public Town LastTown
        {
            get
            {
                return _routes.Last().Towns.Item2;
            }
        }

        /// <summary>
        /// Ctor.
        /// </summary>
        /// <param name="route">The first route traveled.</param>
        public TraveledPath(Route route)
        {
            if (route == null)
            {
                throw new MalformedEntityException("The route can't be null.");
            }
            else
            {
                _routes = new List<Route> { route };
            }
        }

        /// <summary>
        /// Ctor.
        /// </summary>
        /// <param name="path">Path to be copied.</param>
        public TraveledPath(TraveledPath path)
        {
            if (path == null)
            {
                throw new MalformedEntityException("The path can't be null.");
            }
            else
            {
                _routes = new List<Route>(path._routes);
            }
        }

        /// <summary>
        /// Returns true if the given town is present in this path.
        /// </summary>
        /// <param name="town">Town to check if is in path.</param>
        /// <returns>True if the town is present in this path, false otherwise.</returns>
        public bool Contains(Town town)
        {
            return (
                from route in _routes
                where route.Towns.Item1 == town || route.Towns.Item2 == town
                select route
            ).Any();
        }

        /// <summary>
        /// Appends the given route to this path.
        /// </summary>
        /// <param name="town">Route to be appended.</param>
        /// <returns>This reference (useful for sequential appends).</returns>
        public TraveledPath Append(Route route)
        {
            if (route.Towns.Item1 == LastTown)
            {
                _routes.Add(route);
            }
            else
            {
                throw new MalformedEntityException("The first town of the route must be the last town from the path.");
            }
            return this;
        }

        /// <summary>
        /// Returns this path as a string in the 'A-B-C (x stops, distance y)' format.
        /// </summary>
        /// <returns>This path as a string in the 'A-B-C (x stops, distance y)' format.</returns>
        public override string ToString()
        {
            var towns = (
                from route in _routes
                select route.Towns.Item1
            ).ToList();

            towns.Add(LastTown);

            return string.Join("-", towns) + " (" + Stops + " stops, distance " + Distance + ")";
        }

        /// <summary>
        /// Determines whether the given object is equal to this one.
        /// </summary>
        /// <param name="obj">The other object be compared with.</param>
        /// <returns>True if they are equal, false otherwise.</returns>
        public override bool Equals(object obj)
        {
            var other = obj as TraveledPath;
            return other == null ? false : ToString() == other.ToString();
        }

        /// <summary>
        /// Returns a hash code for this object.
        /// </summary>
        /// <returns>A hash code for this object.</returns>
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }
    }
}
