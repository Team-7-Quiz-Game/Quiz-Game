using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Trivia.Core.Contracts;
using Trivia.Core;

namespace Trivia.Tests.EngineTests
{
    [TestClass]
    public class EngineTests
    {
        [TestMethod]
        public void EngineShouldNotBeNull()
        {
            var mockFactory = new Mock<IFactory>();
            var mockDatabase = new Mock<IDatabase>();
            var engine = new Engine(mockFactory.Object, mockDatabase.Object);
            Assert.IsNotNull(engine);
        }

        [TestMethod]
        public void EngineShouldReturnAValidAnswer()
        {
            var text = "test answer";
            var isCorrect = true;
            var mockFactory = new Mock<IFactory>();
            var mockDatabase = new Mock<IDatabase>();
            mockFactory.Setup(x => x.CreateAnswer(text, isCorrect)).Verifiable();
            var engine = new Engine(mockFactory.Object, mockDatabase.Object);

            engine.CreateAnswer(text, isCorrect);

            mockFactory.Verify(x => x.CreateAnswer(It.IsAny<string>(), It.IsAny<bool>()), Times.Once);
        }
    }
}
