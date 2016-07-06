using CSharpRemoteChallenge.Domain.Utilities;

namespace CSharpRemoteChallenge.Domain.Exceptions
{
    /// <summary>
    /// Exception thrown when an unexisting route is used.
    /// </summary>
    public class NoSuchRouteException : DomainException
    {
        /// <summary>
        /// Ctor.
        /// </summary>
        /// <param name="townTuple">Route's towns.</param>
        internal NoSuchRouteException(TownTuple towns) :
            base("There isn't a route between towns " + towns.Item1 + " and " + towns.Item2) { }
    }
}
