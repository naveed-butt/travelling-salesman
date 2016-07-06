using CSharpRemoteChallenge.Domain.Exceptions;

namespace CSharpRemoteChallenge.Domain.Entities
{
    /// <summary>
    /// A town.
    /// Serves as graph's nodes.
    /// </summary>
    public class Town
    {
        /// <summary>
        /// Identification letter.
        /// </summary>
        public readonly char Letter;

        /// <summary>
        /// Ctor.
        /// </summary>
        /// <param name="letter">A letter used to identificate the town.</param>
        public Town(char letter) : this(letter.ToString()) { }

        /// <summary>
        /// Ctor.
        /// </summary>
        /// <param name="letter">A letter used to identificate the town.</param>
        public Town(string letter)
        {
            if (string.IsNullOrWhiteSpace(letter))
            {
                throw new MalformedEntityException("The town letter can't be empty.");
            }
            else if (letter.Length > 1)
            {
                throw new MalformedEntityException("The town letter must be a single character.");
            }
            else if (char.IsLetter(letter[0]))
            {
                // If 'exotic' letters such as Ω (omega) shoudn't be valid, a [a-zA-Z] regex would be more suitable.
                Letter = char.ToUpper(letter[0]);
            }
            else
            {
                throw new MalformedEntityException("The town letter must be a valid Unicode letter.");
            }
        }

        /// <summary>
        /// Returns the town letter as a string.
        /// </summary>
        /// <returns>The town letter as a string.</returns>
        public override string ToString()
        {
            return Letter.ToString();
        }

        /// <summary>
        /// Determines whether the given object is equal to this one.
        /// </summary>
        /// <param name="obj">The other object be compared with.</param>
        /// <returns>True if they are equal, false otherwise.</returns>
        public override bool Equals(object obj)
        {
            var other = obj as Town;
            return other == null ? false : this == other;
        }

        /// <summary>
        /// Returns a hash code for this object.
        /// </summary>
        /// <returns>A hash code for this object.</returns>
        public override int GetHashCode()
        {
            return Letter.GetHashCode();
        }

        /// <summary>
        /// Equality operator.
        /// </summary>
        /// <param name="a">First reference.</param>
        /// <param name="b">Second reference.</param>
        /// <returns>True if they are equal, false otherwise.</returns>
        public static bool operator ==(Town a, Town b)
        {
            if ((object)a == null && (object)b == null)
                return true;

            else if ((object)a == null || (object)b == null)
                return false;

            else
                return a.Letter == b.Letter;
        }

        /// <summary>
        /// Inequality operator.
        /// </summary>
        /// <param name="a">First reference.</param>
        /// <param name="b">Second reference.</param>
        /// <returns>True if they are inequal, false otherwise.</returns>
        public static bool operator !=(Town a, Town b)
        {
            return !(a == b);
        }
    }
}

