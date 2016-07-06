namespace CSharpRemoteChallenge.Domain.Exceptions
{
    /// <summary>
    /// Exception thrown when an attempt to construct a malformed entity is made.
    /// </summary>
    public class MalformedEntityException : DomainException
    {
        /// <summary>
        /// Ctor.
        /// </summary>
        /// <param name="message">Error message.</param>
        internal MalformedEntityException(string message) : base(message) { }
    }
}
