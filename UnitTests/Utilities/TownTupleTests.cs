using CSharpRemoteChallenge.Domain.Entities;
using CSharpRemoteChallenge.Domain.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpRemoteChallenge.UnitTests.Utilities
{
    [TestClass]
    public class TownTupleTests
    {
        [TestMethod, TestCategory("TownTuple Utility")]
        public void ShouldConstruct()
        {
            // Arrange
            var item1 = new Town('A');
            var item2 = new Town('B');

            // Act
            var tuple = new TownTuple(item1, item2);

            // Assert
            Assert.AreEqual(item1, tuple.Item1);
            Assert.AreEqual(item2, tuple.Item2);
        }

        [TestMethod, TestCategory("TownTuple Utility")]
        public void ShouldCheckEquality()
        {
            // Arrange
            var ab1 = new TownTuple(new Town('A'), new Town('B'));
            var ab2 = new TownTuple(new Town('A'), new Town('B'));
            var xy = new TownTuple(new Town('X'), new Town('Y'));

            // Assert
            Assert.AreEqual(ab1, ab2);
            Assert.AreNotEqual(ab1, xy);
        }
    }
}
