using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Trivia.Models.Player;

namespace Trivia.Tests
{
    [TestClass]
    public class PlayerTests
    {
        [TestMethod]
        public void NormalPlayerConstructorShouldCreatePlayerWithGivenName()
        {
            var normalPlayer = new NormalPlayer("Fluffy Unicorn");
            Assert.AreEqual("Fluffy Unicorn", normalPlayer.Name);
        }

        [TestMethod]
        public void NormalPlayerConstructorShouldThrowANullExpectionIfNameIsNull()
        {
            Assert.ThrowsException<NullReferenceException>(() => new NormalPlayer(null));
        }

        [TestMethod]
        public void NormalPlayerPointsShouldNotBeNegative()
        {
            var normalPlayer = new NormalPlayer("Pink Unicorn");
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => normalPlayer.Points = -10);
        }

        [TestMethod]
        public void QuizzardPlayerConstructorShouldCreatePlayerWithGivenName()
        {
            var quizzardPlayer = new QuizzardPlayer("Master Of Tests");
            Assert.AreEqual("Master Of Tests", quizzardPlayer.Name);
        }

        [TestMethod]
        public void QuizzardPlayerConstructorShouldThrowANullExpectionIfNameIsNull()
        {
            Assert.ThrowsException<NullReferenceException>(() => new QuizzardPlayer(null));
        }
    }
}
