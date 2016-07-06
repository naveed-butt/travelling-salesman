using CSharpRemoteChallenge.Domain.Exceptions;
using CSharpRemoteChallenge.Domain.Utilities;
using System.Collections.Generic;

namespace CSharpRemoteChallenge.Domain.Entities
{
    /// <summary>
    /// A path of towns.
    /// This path doesn't consider the traveled distance, it is used as input from code outside the library.
    /// For a path that tracks traveled distance, use TraveledPath instead.
    /// </summary>
    public class Path
    {
        /// <summary>
        /// Ordered list of the towns in this path.
        /// </summary>
        private readonly IList<Town> _towns;

        /// <summary>
        /// Ctor.
        /// </summary>
        /// <param name="path">A path string in the format 'A-B-C'.</param>
        public Path(string path)
        {
            _towns = new List<Town>();

            if (string.IsNullOrWhiteSpace(path))
            {
                throw new MalformedEntityException("The path can't be empty.");
            }
            else
            {
                var tokens = path.Split('-');
                foreach (var token in tokens)
                {
                    if (token.Length > 1)
                    {
                        throw new MalformedEntityException(
                            "The path string is invalid. It should be in the 'A-B-C' format.");
                    }
                    else
                    {
                        var town = new Town(token[0]);
                        _towns.Add(town);
                    }
                }
            }
        }

        /// <summary>
        /// Returns the towns in path as tuples.
        /// </summary>
        /// <returns>Towns in path as tuples.</returns>
        public IEnumerable<TownTuple> Tuples()
        {
            for (var i = 1; i < _towns.Count; ++i)
            {
                yield return new TownTuple(_towns[i - 1], _towns[i]);
            }
        }

        /// <summary>
        /// Returns the path as string in the format 'A-B-C'.
        /// </summary>
        /// <returns>The path as string in the format 'A-B-C'.</returns>
        public override string ToString()
        {
            return string.Join("-", _towns);
        }
    }
}
