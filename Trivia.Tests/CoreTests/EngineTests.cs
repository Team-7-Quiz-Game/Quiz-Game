using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Trivia.Core.Contracts;
using Trivia.Core;
using Trivia.Common.Enums;
using System;
using Trivia.Contracts;
using Trivia.Models.Category;
using System.Collections.Generic;
using Trivia.Common.Exceptions;

namespace Trivia.Tests.CoreTests
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
            var engine = new Engine(mockFactory.Object, mockDatabase.Object);

            engine.CreateAnswer(text, isCorrect);

            mockFactory.Verify(x => x.CreateAnswer(It.IsAny<string>(), It.IsAny<bool>()), Times.Once);
        }

        [TestMethod]
        public void EngineShouldReturnAValidNormalQuestion()
        {
            var questionText = "How are you?";
            var mockFactory = new Mock<IFactory>();
            var mockDatabase = new Mock<IDatabase>();
            var engine = new Engine(mockFactory.Object, mockDatabase.Object);

            engine.CreateNormalQuestion(questionText, DifficultyLevel.Normal, CategoryType.Random);

            mockFactory.Verify(x => x.CreateNormalQuestion(It.IsAny<string>(), It.IsAny<DifficultyLevel>(), It.IsAny<CategoryType>()), Times.Once);
        }

        [TestMethod]
        public void EngineShouldThrowAnExceptionWhenGivenNullParameterForNormalQuestionCreation()
        {
            string questionText = null;
            var mockFactory = new Mock<IFactory>();
            var mockDatabase = new Mock<IDatabase>();
            var engine = new Engine(mockFactory.Object, mockDatabase.Object);

            Assert.ThrowsException<NullReferenceException>(() => engine.CreateNormalQuestion(questionText, DifficultyLevel.Normal, CategoryType.Random));
        }

        [TestMethod]
        public void EngineShouldReturnAValidBonusQuestion()
        {
            var questionText = "How are you?";
            var pointsMultiplier = 5;
            var mockFactory = new Mock<IFactory>();
            var mockDatabase = new Mock<IDatabase>();
            var engine = new Engine(mockFactory.Object, mockDatabase.Object);

            engine.CreateBonusQuestion(questionText, DifficultyLevel.Normal, CategoryType.Random, pointsMultiplier);

            mockFactory.Verify(x => x.CreateBonusQuestion(It.IsAny<string>(), It.IsAny<DifficultyLevel>(), It.IsAny<CategoryType>(), It.IsAny<int>()), Times.Once);
        }

        [TestMethod]
        public void EngineShouldThrowAnExceptionWhenGivenNullParameterForBonusQuestionCreation()
        {
            string questionText = null;
            var pointsMultiplier = 5;
            var mockFactory = new Mock<IFactory>();
            var mockDatabase = new Mock<IDatabase>();
            var engine = new Engine(mockFactory.Object, mockDatabase.Object);

            Assert.ThrowsException<NullReferenceException>(() => engine.CreateBonusQuestion(questionText, DifficultyLevel.Normal, CategoryType.Random, pointsMultiplier));
        }

        [TestMethod]
        public void EngineShouldThrowAnExceptionWhenPointsMultiplierParameterIsGreaterThanMaxValueForBonusQuestionCreation()
        {
            string questionText = "How are you again?";
            var pointsMultiplier = 11;
            var mockFactory = new Mock<IFactory>();
            var mockDatabase = new Mock<IDatabase>();
            var engine = new Engine(mockFactory.Object, mockDatabase.Object);

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => engine.CreateBonusQuestion(questionText, DifficultyLevel.Normal, CategoryType.Random, pointsMultiplier));
        }

        [TestMethod]
        public void EngineShouldThrowAnExceptionWhenPointsMultiplierParameterIsLowerThanMinValueForBonusQuestionCreation()
        {
            string questionText = "How are you again?";
            var pointsMultiplier = -1;
            var mockFactory = new Mock<IFactory>();
            var mockDatabase = new Mock<IDatabase>();
            var engine = new Engine(mockFactory.Object, mockDatabase.Object);

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => engine.CreateBonusQuestion(questionText, DifficultyLevel.Normal, CategoryType.Random, pointsMultiplier));
        }

        [TestMethod]
        public void EngineShouldReturnAValidTimedQuestion()
        {
            var questionText = "Are you a timed question?";
            var timeForAnswer = 15;
            var mockFactory = new Mock<IFactory>();
            var mockDatabase = new Mock<IDatabase>();
            var engine = new Engine(mockFactory.Object, mockDatabase.Object);

            engine.CreateTimedQuestion(questionText, DifficultyLevel.Normal, CategoryType.Random, timeForAnswer);

            mockFactory.Verify(x => x.CreateTimedQuestion(It.IsAny<string>(), It.IsAny<DifficultyLevel>(), It.IsAny<CategoryType>(), It.IsAny<int>()), Times.Once);
        }

        [TestMethod]
        public void EngineShouldThrowAnExceptionWhenTimeForAnswerParameterIsGreaterThanMaxValueForTimedQuestionCreation()
        {
            var questionText = "Are you a timed question with wrong time to answer?";
            var timeForAnswer = 50;
            var mockFactory = new Mock<IFactory>();
            var mockDatabase = new Mock<IDatabase>();
            var engine = new Engine(mockFactory.Object, mockDatabase.Object);

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => engine.CreateTimedQuestion(questionText, DifficultyLevel.Normal, CategoryType.Random, timeForAnswer));
        }

        [TestMethod]
        public void EngineShouldThrowAnExceptionWhenTimeForAnswerParameterIsLowerThanMinValueForTimedQuestionCreation()
        {
            var questionText = "Are you a timed question with wrong time to answer?";
            var timeForAnswer = 2;
            var mockFactory = new Mock<IFactory>();
            var mockDatabase = new Mock<IDatabase>();
            var engine = new Engine(mockFactory.Object, mockDatabase.Object);

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => engine.CreateTimedQuestion(questionText, DifficultyLevel.Normal, CategoryType.Random, timeForAnswer));
        }

        [TestMethod]
        public void EngineShouldCreatFiftyFiftyHint()
        {
            var mockFactory = new Mock<IFactory>();
            var mockDatabase = new Mock<IDatabase>();
            var engine = new Engine(mockFactory.Object, mockDatabase.Object);

            mockFactory.Verify(x => x.CreateFiftyFiftyHint(It.IsAny<int>()), Times.Once);
        }

        [TestMethod]
        public void EngineShouldThrowAnArgumentOutOfRangeExceptionWhenFiftyFiftyHintQuantityIsOutOfRange()
        {
            var quantity = -2;
            var mockFactory = new Mock<IFactory>();
            var mockDatabase = new Mock<IDatabase>();
            var engine = new Engine(mockFactory.Object, mockDatabase.Object);

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => engine.CreateFiftyFiftyHint(quantity));
        }

        [TestMethod]
        public void EngineShouldCreatSkipQuestionHint()
        {
            var mockFactory = new Mock<IFactory>();
            var mockDatabase = new Mock<IDatabase>();
            var engine = new Engine(mockFactory.Object, mockDatabase.Object);

            mockFactory.Verify(x => x.CreateSkipQuestionHint(It.IsAny<int>()), Times.Once);
        }

        [TestMethod]
        public void EngineShouldThrowAnArgumentOutOfRangeExceptionWhenSkipQuestionHintQuantityIsOutOfRange()
        {
            var quantity = -5;
            var mockFactory = new Mock<IFactory>();
            var mockDatabase = new Mock<IDatabase>();
            var engine = new Engine(mockFactory.Object, mockDatabase.Object);

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => engine.CreateSkipQuestionHint(quantity));
        }

        [TestMethod]
        public void EngineShouldReturnNormalPlayer()
        {
            var playerName = "Mr Unicorn";
            var mockFactory = new Mock<IFactory>();
            var mockDatabase = new Mock<IDatabase>();
            var engine = new Engine(mockFactory.Object, mockDatabase.Object);

            engine.CreateNormalPlayer(playerName);

            mockFactory.Verify(x => x.CreateNormalPlayer(It.IsAny<string>()), Times.Once);
        }

        [TestMethod]
        public void EngineShouldThrowAnExceptionWhenGivenNullParameterForNormalPlayersName()
        {
            string playerName = null;
            var mockFactory = new Mock<IFactory>();
            var mockDatabase = new Mock<IDatabase>();
            var engine = new Engine(mockFactory.Object, mockDatabase.Object);

            Assert.ThrowsException<NullReferenceException>(() => engine.CreateNormalPlayer(playerName));
        }

        [TestMethod]
        public void EngineShouldReturnQuizzardPlayer()
        {
            var playerName = "Mr Unicorn";
            var mockFactory = new Mock<IFactory>();
            var mockDatabase = new Mock<IDatabase>();
            var engine = new Engine(mockFactory.Object, mockDatabase.Object);

            engine.CreateQuizzardPlayer(playerName);

            mockFactory.Verify(x => x.CreateQuizzardPlayer(It.IsAny<string>()), Times.Once);
        }

        [TestMethod]
        public void EngineShouldThrowAnExceptionWhenGivenNullParameterForQuizzardPlayersName()
        {
            string playerName = null;
            var mockFactory = new Mock<IFactory>();
            var mockDatabase = new Mock<IDatabase>();
            var engine = new Engine(mockFactory.Object, mockDatabase.Object);

            Assert.ThrowsException<NullReferenceException>(() => engine.CreateQuizzardPlayer(playerName));
        }

        [TestMethod]
        public void EngineShouldReturnListWithEasyQuestions()
        {
            var mockFactory = new Mock<IFactory>();
            var mockDatabase = new Mock<IDatabase>();
            var engine = new Engine(mockFactory.Object, mockDatabase.Object);
            var easyQuestionsList = engine.GetEasyQuestions();
            Assert.IsNotNull(easyQuestionsList);
        }

        [TestMethod]
        public void EngineShouldReturnListWithNormalQuestions()
        {
            var mockFactory = new Mock<IFactory>();
            var mockDatabase = new Mock<IDatabase>();
            var engine = new Engine(mockFactory.Object, mockDatabase.Object);
            var normalQuestionsList = engine.GetNormalQuestions();
            Assert.IsNotNull(normalQuestionsList);
        }

        [TestMethod]
        public void EngineShouldReturnListWithHardQuestions()
        {
            var mockFactory = new Mock<IFactory>();
            var mockDatabase = new Mock<IDatabase>();
            var engine = new Engine(mockFactory.Object, mockDatabase.Object);
            var hardQuestionsList = engine.GetHardQuestions();
            Assert.IsNotNull(hardQuestionsList);
        }

        [TestCategory("CreateCategoryTests")]
        [TestMethod]
        public void EngineShouldThrowNullReferenceExceptionWhenNullListParameterIsProvidedForCreateCategory()
        {
            var mockFactory = new Mock<IFactory>();
            var mockDatabase = new Mock<IDatabase>();
            var engine = new Engine(mockFactory.Object, mockDatabase.Object);

            Assert.ThrowsException<NullReferenceException>(() => engine.CreateCategory(null));
        }

        [TestCategory("CreateCategoryTests")]
        [TestMethod]
        public void EngineShouldThrowCategoryAlreadyExistsExceptionWhenSameCategoryIsProvidedForCreateCategory()
        {
            var mockFactory = new Mock<IFactory>();
            var mockDatabase = new Mock<IDatabase>();
            var engine = new Engine(mockFactory.Object, mockDatabase.Object);
            var mockMath = new Mock<ICategory>();

            mockFactory.Setup(x => x.CreateCategory(CategoryType.Math)).Returns(mockMath.Object);
            mockDatabase.Setup(x => x.GetRandomQuestions(It.IsAny<ICategory>(), It.IsAny<int>())).Returns(new List<IQuestion>());

            var categories = new List<string>() { "Math", "Math" };

            Assert.ThrowsException<CategoryAlreadyExistsException>(() => engine.CreateCategory(categories));
        }

        [TestCategory("CreateCategoryTests")]
        [TestMethod]
        public void EngineShouldCallFactoryCreateCategoryMethodOnceWhenOneCategoryIsProvidedForCreateCategory()
        {
            var mockFactory = new Mock<IFactory>();
            var mockDatabase = new Mock<IDatabase>();
            var engine = new Engine(mockFactory.Object, mockDatabase.Object);
            var mockMath = new Mock<ICategory>();

            mockFactory.Setup(x => x.CreateCategory(CategoryType.Math)).Returns(mockMath.Object);
            mockDatabase.Setup(x => x.GetRandomQuestions(It.IsAny<ICategory>(), It.IsAny<int>())).Returns(new List<IQuestion>());

            var categories = new List<string>() { "Math" };

            engine.CreateCategory(categories);

            mockFactory.Verify(x => x.CreateCategory(It.IsAny<CategoryType>()), Times.Once);
        }

        [TestCategory("CreateCategoryTests")]
        [TestMethod]
        public void EngineShouldHaveExactlyTwoCategoriesWhenTwoCategoriesAreProvidedForCreateCategory()
        {
            var mockFactory = new Mock<IFactory>();
            var mockDatabase = new Mock<IDatabase>();
            var engine = new Engine(mockFactory.Object, mockDatabase.Object);
            var mockMath = new Mock<ICategory>();
            var mockHistory = new Mock<ICategory>();

            mockFactory.Setup(x => x.CreateCategory(CategoryType.Math)).Returns(mockMath.Object);
            mockFactory.Setup(x => x.CreateCategory(CategoryType.History)).Returns(mockHistory.Object);
            mockDatabase.Setup(x => x.GetRandomQuestions(It.IsAny<ICategory>(), It.IsAny<int>())).Returns(new List<IQuestion>());

            var categories = new List<string>() { "Math", "History" };

            engine.CreateCategory(categories);

            Assert.AreEqual(2, engine.Categories.Count);
        }

        [TestCategory("CreateCategoryTests")]
        [TestMethod]
        public void EngineShouldReturnDifferentCopiesOfCategoriesForCategoriesProperty()
        {
            var mockFactory = new Mock<IFactory>();
            var mockDatabase = new Mock<IDatabase>();
            var engine = new Engine(mockFactory.Object, mockDatabase.Object);
            var mockMath = new Mock<ICategory>();
            var mockHistory = new Mock<ICategory>();

            mockFactory.Setup(x => x.CreateCategory(CategoryType.Math)).Returns(mockMath.Object);
            mockFactory.Setup(x => x.CreateCategory(CategoryType.History)).Returns(mockHistory.Object);
            mockDatabase.Setup(x => x.GetRandomQuestions(It.IsAny<ICategory>(), It.IsAny<int>())).Returns(new List<IQuestion>());

            var categories = new List<string>() { "Math", "History" };

            engine.CreateCategory(categories);

            Assert.AreNotSame(categories, engine.Categories);
        }

        [TestCategory("CreateCategoryTests")]
        [TestMethod]
        public void EngineShouldCallDatabaseGetRandomQuetionsMethodOnceWhenOneCategoryIsProvidedForCreateCategory()
        {
            var mockFactory = new Mock<IFactory>();
            var mockDatabase = new Mock<IDatabase>();
            var engine = new Engine(mockFactory.Object, mockDatabase.Object);
            var mockMath = new Mock<ICategory>();

            mockFactory.Setup(x => x.CreateCategory(CategoryType.Math)).Returns(mockMath.Object);
            mockDatabase.Setup(x => x.GetRandomQuestions(It.IsAny<ICategory>(), It.IsAny<int>())).Returns(new List<IQuestion>());

            var categories = new List<string>() { "Math" };

            engine.CreateCategory(categories);

            mockDatabase.Verify(x => x.GetRandomQuestions(It.IsAny<ICategory>(), It.IsAny<int>()), Times.Once);
        }
    }
}
