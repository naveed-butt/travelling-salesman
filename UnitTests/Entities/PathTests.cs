using CSharpRemoteChallenge.Domain.Entities;
using CSharpRemoteChallenge.Domain.Exceptions;
using CSharpRemoteChallenge.Domain.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace CSharpRemoteChallenge.UnitTests.Entities
{
    [TestClass]
    public class PathTests
    {
        [TestMethod, TestCategory("Path Entity")]
        public void ShouldntThrowException()
        {
            // Act
            new Path("A-B-C");
        }

        [TestMethod, TestCategory("Path Entity")]
        [ExpectedException(typeof(MalformedEntityException))]
        public void ShouldThrowExceptionBecausePathIsNullString()
        {
            // Act
            new Path(null as string);
        }

        [TestMethod, TestCategory("Path Entity")]
        [ExpectedException(typeof(MalformedEntityException))]
        public void ShouldThrowExceptionBecausePathIsEmptyString()
        {
            // Act
            new Path(string.Empty);
        }

        [TestMethod, TestCategory("Path Entity")]
        public void ShouldReturnCorrectTuples()
        {
            // Arrange
            var path = new Path("Q-W-E-R-T-Y");
            var expected = new List<TownTuple>
            {
                new TownTuple(new Town('Q'), new Town('W')),
                new TownTuple(new Town('W'), new Town('E')),
                new TownTuple(new Town('E'), new Town('R')),
                new TownTuple(new Town('R'), new Town('T')),
                new TownTuple(new Town('T'), new Town('Y')),
            };

            // Act
            var actual = path.Tuples().ToList();

            // Assert
            Assert.AreEqual(expected.Count, actual.Count);
            Assert.AreEqual(expected[0], actual[0]);
            Assert.AreEqual(expected[1], actual[1]);
            Assert.AreEqual(expected[2], actual[2]);
            Assert.AreEqual(expected[3], actual[3]);
            Assert.AreEqual(expected[4], actual[4]);
        }

        [TestMethod, TestCategory("Path Entity")]
        public void ShouldFormatStringCorrectly()
        {
            // Arrange
            var path = new Path("T-O-W-N-S");

            // Act
            var str = path.ToString();

            // Assert
            Assert.AreEqual("T-O-W-N-S", str);
        }
    }
}
