using CSharpRemoteChallenge.Domain.Entities;
using CSharpRemoteChallenge.Domain.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpRemoteChallenge.UnitTests.Entities
{
    [TestClass]
    public class RouteTests
    {
        [TestMethod, TestCategory("Route Entity")]
        public void ShouldntThrowException()
        {
            // Act
            new Route("AB1");
        }

        [TestMethod, TestCategory("Route Entity")]
        [ExpectedException(typeof(MalformedEntityException))]
        public void ShouldThrowExceptionBecauseTownsAreTheSame()
        {
            // Act
            new Route("TT7");
        }

        [TestMethod, TestCategory("Route Entity")]
        [ExpectedException(typeof(MalformedEntityException))]
        public void ShouldThrowExceptionBecauseStringIsNull()
        {
            // Act
            new Route(null);
        }

        [TestMethod, TestCategory("Route Entity")]
        [ExpectedException(typeof(MalformedEntityException))]
        public void ShouldThrowExceptionBecauseLengthIsInvalid()
        {
            // Act
            new Route("ABC5");
        }

        [TestMethod, TestCategory("Route Entity")]
        [ExpectedException(typeof(MalformedEntityException))]
        public void ShouldThrowExceptionBecauseLastCharIsntDigit()
        {
            // Act
            new Route("XYZ");
        }
    }
}
