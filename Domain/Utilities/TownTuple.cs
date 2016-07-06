using CSharpRemoteChallenge.Domain.Entities;
using System;

namespace CSharpRemoteChallenge.Domain.Utilities
{
    /// <summary>
    /// A tuple of towns.
    /// Useful with dictionaries and such due to equality being handled acordingly in this class.
    /// </summary>
    public class TownTuple : Tuple<Town, Town>
    {
        /// <summary>
        /// Ctor.
        /// </summary>
        /// <param name="item1">Town 1.</param>
        /// <param name="item2">Town 2.</param>
        public TownTuple(Town item1, Town item2) : base(item1, item2) { }

        /// <summary>
        /// Determines whether the given object is equal to this one.
        /// </summary>
        /// <param name="obj">The other object be compared with.</param>
        /// <returns>True if they are equal, false otherwise.</returns>
        public override bool Equals(object obj)
        {
            var other = obj as TownTuple;
            return other == null ? false : Item1.Equals(other.Item1) && Item2.Equals(other.Item2);
        }

        /// <summary>
        /// Returns a hash code for this object.
        /// </summary>
        /// <returns>A hash code for this object.</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
