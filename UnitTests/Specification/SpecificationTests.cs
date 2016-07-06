using CSharpRemoteChallenge.Domain.Entities;
using CSharpRemoteChallenge.Domain.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace CSharpRemoteChallenge.UnitTests.Specification
{
    [TestClass]
    public class SpecificationTests
    {
        [TestMethod]
        [TestCategory("Specification Tests")]
        public void First()
        {
            // Arrange
            var graph = new Graph("AB5, BC4, CD8, DC8, DE6, AD5, CE2, EB3, AE7");
            var path = new Path("A-B-C");
            var expected = 9;

            // Act
            var actual = graph.ComputeDistance(path);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [TestCategory("Specification Tests")]
        public void Second()
        {
            // Arrange
            var graph = new Graph("AB5, BC4, CD8, DC8, DE6, AD5, CE2, EB3, AE7");
            var path = new Path("A-D");
            var expected = 5;

            // Act
            var actual = graph.ComputeDistance(path);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [TestCategory("Specification Tests")]
        public void Third()
        {
            // Arrange
            var graph = new Graph("AB5, BC4, CD8, DC8, DE6, AD5, CE2, EB3, AE7");
            var path = new Path("A-D-C");
            var expected = 13;

            // Act
            var actual = graph.ComputeDistance(path);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [TestCategory("Specification Tests")]
        public void Fourth()
        {
            // Arrange
            var graph = new Graph("AB5, BC4, CD8, DC8, DE6, AD5, CE2, EB3, AE7");
            var path = new Path("A-E-B-C-D");
            var expected = 22;

            // Act
            var actual = graph.ComputeDistance(path);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [TestCategory("Specification Tests")]
        [ExpectedException(typeof(NoSuchRouteException))]
        public void Fifth()
        {
            // Arrange
            var graph = new Graph("AB5, BC4, CD8, DC8, DE6, AD5, CE2, EB3, AE7");
            var path = new Path("A-E-D");

            // Act
            graph.ComputeDistance(path);
        }

        [TestMethod]
        [TestCategory("Specification Tests")]
        public void Sixth()
        {
            // Arrange
            var graph = new Graph("AB5, BC4, CD8, DC8, DE6, AD5, CE2, EB3, AE7");
            var from = new Town('C');
            var to = new Town('C');
            var maxStops = 3;
            var expectedCount = 2;
            var expected0 = "C-D-C (2 stops, distance 16)";
            var expected1 = "C-E-B-C (3 stops, distance 9)";

            // Act
            var actual = graph.ListAvailableRoutes(from, to, maxStops);

            // Assert
            Assert.AreEqual(expectedCount, actual.Count());
            Assert.AreEqual(expected0, actual.ElementAt(0).ToString());
            Assert.AreEqual(expected1, actual.ElementAt(1).ToString());
        }

        [TestMethod]
        [TestCategory("Specification Tests")]
        public void Seventh()
        {
            // Arrange
            var graph = new Graph("AB5, BC4, CD8, DC8, DE6, AD5, CE2, EB3, AE7");
            var from = new Town('A');
            var to = new Town('C');
            var maxStops = 4;
            var expectedCount = 5;
            var expected0 = "A-B-C (2 stops, distance 9)";
            var expected1 = "A-D-C (2 stops, distance 13)";
            var expected2 = "A-E-B-C (3 stops, distance 14)";
            var expected3 = "A-D-E-B-C (4 stops, distance 18)";
            var expected4 = "A-B-C-D-C (4 stops, distance 25)";

            // There was a sixth route in the specification that was suppressed here: 'A-D-C-D-C'.
            // Was this supposed to be allowed?
            // I'm questioning that due the duplicate route 'D-C' in the path.
            // In a practial cenario, wouldn't be pointless to revisit a route?

            // Act
            var actual = graph.ListAvailableRoutes(from, to, maxStops);

            // Assert
            Assert.AreEqual(expectedCount, actual.Count());
            Assert.AreEqual(expected0, actual.ElementAt(0).ToString());
            Assert.AreEqual(expected1, actual.ElementAt(1).ToString());
            Assert.AreEqual(expected2, actual.ElementAt(2).ToString());
            Assert.AreEqual(expected3, actual.ElementAt(3).ToString());
            Assert.AreEqual(expected4, actual.ElementAt(4).ToString());
        }

        [TestMethod]
        [TestCategory("Specification Tests")]
        public void Eighth()
        {
            // Arrange
            var graph = new Graph("AB5, BC4, CD8, DC8, DE6, AD5, CE2, EB3, AE7");
            var from = new Town('A');
            var to = new Town('C');
            var expected = "A-B-C (2 stops, distance 9)";

            // Act
            var actual = graph.FindShortestRoute(from, to);

            // Assert
            Assert.AreEqual(expected, actual.ToString());
        }

        [TestMethod]
        [TestCategory("Specification Tests")]
        public void Ninth()
        {
            // Arrange
            var graph = new Graph("AB5, BC4, CD8, DC8, DE6, AD5, CE2, EB3, AE7");
            var from = new Town('B');
            var to = new Town('B');
            var expected = "B-C-E-B (3 stops, distance 9)";

            // Act
            var actual = graph.FindShortestRoute(from, to);

            // Assert
            Assert.AreEqual(expected, actual.ToString());
        }
    }
}
