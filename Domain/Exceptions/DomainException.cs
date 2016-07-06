using System;

namespace CSharpRemoteChallenge.Domain.Exceptions
{
    /// <summary>
    /// Base class for domain exceptions. 
    /// </summary>
    public abstract class DomainException : Exception
    {
        /// <summary>
        /// Ctor.
        /// </summary>
        /// <param name="message">Error message.</param>
        internal DomainException(string message) : base(message) { }
    }
}
