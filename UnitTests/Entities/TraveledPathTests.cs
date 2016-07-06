using CSharpRemoteChallenge.Domain.Entities;
using CSharpRemoteChallenge.Domain.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpRemoteChallenge.UnitTests.Entities
{
    [TestClass]
    public class TraveledPathTests
    {
        [TestMethod, TestCategory("TraveledPath Entity")]
        public void ShouldntThrowException()
        {
            // Arrange
            var route = new Route("AB5");

            // Act
             var traveledPath = new TraveledPath(route);
             new TraveledPath(traveledPath);
        }

        [TestMethod, TestCategory("TraveledPath Entity")]
        [ExpectedException(typeof(MalformedEntityException))]
        public void ShouldThrowExceptionBecauseRouteIsNull()
        {
            // Act
            new TraveledPath(null as Route);
        }

        [TestMethod, TestCategory("TraveledPath Entity")]
        [ExpectedException(typeof(MalformedEntityException))]
        public void ShouldThrowExceptionBecausePathIsNull()
        {
            // Act
            new TraveledPath(null as TraveledPath);
        }

        [TestMethod, TestCategory("TraveledPath Entity")]
        [ExpectedException(typeof(MalformedEntityException))]
        public void ShouldThrowExceptionBecauseTheFirstTownInRouteIsNotTheLastTownInPath()
        {
            // Arrange
            var ab = new Route("AB5");
            var xy = new Route("XY7");
            var path = new TraveledPath(ab);

            // Act
            path.Append(xy);
        }

        [TestMethod, TestCategory("TraveledPath Entity")]
        public void ShouldReturnQuantityOfStops()
        {
            // Arrange
            var ab = new Route("AB1");
            var bc = new Route("BC2");
            var cd = new Route("CD3");
            var path = new TraveledPath(ab);

            // Act
            path.Append(bc).Append(cd);

            // Assert
            Assert.AreEqual(3, path.Stops);
        }

        [TestMethod, TestCategory("TraveledPath Entity")]
        public void ShouldReturnLastTown()
        {
            // Arrange
            var ab = new Route("AB1");
            var bc = new Route("BC2");
            var cd = new Route("CD3");
            var d = new Town('D');
            var path = new TraveledPath(ab);

            // Act
            path.Append(bc).Append(cd);

            // Assert
            Assert.AreEqual(path.LastTown, d);
        }

        [TestMethod, TestCategory("TraveledPath Entity")]
        public void ShouldContainsTown()
        {
            // Arrange
            var ab = new Route("AB1");
            var bc = new Route("BC2");
            var cd = new Route("CD3");
            var b = new Town('B');
            var path = new TraveledPath(ab);

            // Act
            path.Append(bc).Append(cd);

            // Assert
            Assert.IsTrue(path.Contains(b));
        }

        [TestMethod, TestCategory("TraveledPath Entity")]
        public void ShouldFormatStringCorrectly()
        {
            // Arrange
            var ab = new Route("AB1");
            var bc = new Route("BC2");
            var cd = new Route("CD3");
            var d = new Town('D');
            var path = new TraveledPath(ab);

            // Act
            path.Append(bc).Append(cd);

            // Assert
            Assert.AreEqual("A-B-C-D (3 stops, distance 6)", path.ToString());
        }

        [TestMethod, TestCategory("TraveledPath Entity")]
        public void ShouldCheckEquality()
        {
            // Arrange
            var ab = new Route("AB1");
            var bc = new Route("BC2");
            var cd = new Route("CD3");
            var path1 = new TraveledPath(ab).Append(bc).Append(cd);
            var path2 = new TraveledPath(ab).Append(bc).Append(cd);

            // Assert
            Assert.AreEqual(path1, path2);
        }
    }
}
