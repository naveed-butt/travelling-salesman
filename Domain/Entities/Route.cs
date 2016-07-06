using CSharpRemoteChallenge.Domain.Exceptions;
using CSharpRemoteChallenge.Domain.Utilities;
using System;

namespace CSharpRemoteChallenge.Domain.Entities
{
    /// <summary>
    /// A route between two towns.
    /// Serves as graph's edges.
    /// </summary>
    public class Route
    {
        /// <summary>
        /// The two towns of the route (edge's links).
        /// </summary>
        public readonly TownTuple Towns;

        /// <summary>
        /// The distance magnitude.
        /// </summary>
        public readonly int Distance;

        /// <summary>
        /// Ctor.
        /// </summary>
        /// <param name="route">A route string in the format "AB5".</param>
        public Route(string route)
        {
            ValidateString(route);

            var item1 = new Town(route[0]);
            var item2 = new Town(route[1]);
            if (item1 == item2)
            {
                throw new MalformedEntityException("The route must be between two different towns.");
            }

            Towns = new TownTuple(item1, item2);
            Distance = int.Parse(route[2].ToString());
        }

        /// <summary>
        /// Validates the given route string in the format "AB5".
        /// </summary>
        /// <param name="route">The route string to be validated.</param>
        private void ValidateString(string route)
        {
            if (string.IsNullOrWhiteSpace(route))
            {
                throw new MalformedEntityException("The route string can't be empty.");
            }
            else if (route.Length != 3)
            {
                throw new MalformedEntityException("The route string must have exactly 3 characters.");
            }
            else if (!char.IsDigit(route, 2))
            {
                throw new MalformedEntityException(
                    "The last character of the route string must be a single digit (1-9).");
            }
        }

        /// <summary>
        /// Returns the route as a string in the format "AB5".
        /// </summary>
        /// <returns>A string representation of this object.</returns>
        public override string ToString()
        {
            return Towns.Item1.ToString() + Towns.Item2.ToString() + Distance.ToString();
        }
    }
}
