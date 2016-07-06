using CSharpRemoteChallenge.Domain.Entities;
using CSharpRemoteChallenge.Domain.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpRemoteChallenge.UnitTests.Entities
{
    [TestClass]
    public class TownTests
    {
        [TestMethod, TestCategory("Town Entity")]
        public void ShouldNotThrowException()
        {
            // Act
            new Town('L');
            new Town("L");
        }

        [TestMethod, TestCategory("Town Entity")]
        public void ShouldUseUppercase()
        {
            // Arrange
            var town = new Town('t');

            // Act
            var letter = town.Letter;

            // Assert
            Assert.AreEqual('T', letter);
        }

        [TestMethod, TestCategory("Town Entity")]
        [ExpectedException(typeof(MalformedEntityException))]
        public void ShouldThrowExceptionBecauseOfNonLetter()
        {
            // Act
            new Town('7');
        }

        [TestMethod, TestCategory("Town Entity")]
        [ExpectedException(typeof(MalformedEntityException))]
        public void ShouldThrowExceptionBecauseOfNullString()
        {
            // Act
            new Town(null);
        }

        [TestMethod, TestCategory("Town Entity")]
        [ExpectedException(typeof(MalformedEntityException))]
        public void ShouldThrowExceptionBecauseOfEmptyString()
        {
            // Act
            new Town(string.Empty);
        }

        [TestMethod, TestCategory("Town Entity")]
        [ExpectedException(typeof(MalformedEntityException))]
        public void ShouldThrowExceptionBecauseOfLongString()
        {
            // Act
            new Town("Test");
        }

        [TestMethod, TestCategory("Town Entity")]
        public void ShouldUseLetter()
        {
            // Arrange
            var town = new Town('Y');

            // Act
            var str = town.ToString();

            // Assert
            Assert.AreEqual("Y", str);
        }

        [TestMethod, TestCategory("Town Entity")]
        public void ShouldCheckEquality()
        {
            // Arrange
            var a1 = new Town('A');
            var a2 = new Town('A');
            var x = new Town('X');

            // Assert
            Assert.AreEqual(a1, a2);
            Assert.AreNotEqual(a1, x);

            Assert.IsTrue(a1 == a2);
            Assert.IsFalse(a1 != a2);

            Assert.IsFalse(a1 == x);
            Assert.IsTrue(a1 != x);
        }
    }
}
