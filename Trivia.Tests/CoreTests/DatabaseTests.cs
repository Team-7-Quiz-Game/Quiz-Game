using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using Trivia.Common.Enums;
using Trivia.Contracts;
using Trivia.Core;
using Trivia.Core.Contracts;

namespace Trivia.Tests.CoreTests
{
    [TestClass]
    public class DatabaseTests
    {
        [TestMethod]
        public void DatabaseCategoriesShouldNotBeNull()
        {
            var mockFactory = new Mock<IFactory>();

            var mathMock = new Mock<ICategory>();
            var historyMock = new Mock<ICategory>();
            var randomMock = new Mock<ICategory>();
            var sciFiMock = new Mock<ICategory>();
            var moviesMock = new Mock<ICategory>();
            var literatureMock = new Mock<ICategory>();
            var scienceMock = new Mock<ICategory>();
            var geographyMock = new Mock<ICategory>();

            var answerMock = new Mock<IAnswer>();
            var questionMock = new Mock<IQuestion>();

            mathMock.SetupGet(x => x.CategoryType).Returns(CategoryType.Math);
            historyMock.SetupGet(x => x.CategoryType).Returns(CategoryType.History);
            randomMock.SetupGet(x => x.CategoryType).Returns(CategoryType.Random);
            sciFiMock.SetupGet(x => x.CategoryType).Returns(CategoryType.SciFi);
            moviesMock.SetupGet(x => x.CategoryType).Returns(CategoryType.Movies);
            literatureMock.SetupGet(x => x.CategoryType).Returns(CategoryType.Literature);
            scienceMock.SetupGet(x => x.CategoryType).Returns(CategoryType.Science);
            geographyMock.SetupGet(x => x.CategoryType).Returns(CategoryType.Geography);

            mockFactory.Setup(x => x.CreateCategory(CategoryType.Math)).Returns(mathMock.Object);
            mockFactory.Setup(x => x.CreateCategory(CategoryType.History)).Returns(historyMock.Object);
            mockFactory.Setup(x => x.CreateCategory(CategoryType.Random)).Returns(randomMock.Object);
            mockFactory.Setup(x => x.CreateCategory(CategoryType.SciFi)).Returns(sciFiMock.Object);
            mockFactory.Setup(x => x.CreateCategory(CategoryType.Movies)).Returns(moviesMock.Object);
            mockFactory.Setup(x => x.CreateCategory(CategoryType.Literature)).Returns(literatureMock.Object);
            mockFactory.Setup(x => x.CreateCategory(CategoryType.Science)).Returns(scienceMock.Object);
            mockFactory.Setup(x => x.CreateCategory(CategoryType.Geography)).Returns(geographyMock.Object);

            mockFactory.Setup(x => x.CreateNormalQuestion(It.IsAny<string>(), It.IsAny<DifficultyLevel>(), It.IsAny<CategoryType>())).Returns(questionMock.Object);
            mockFactory.Setup(x => x.CreateAnswer(It.IsAny<string>(), It.IsAny<bool>())).Returns(answerMock.Object);

            var db = new Database(mockFactory.Object);

            Assert.IsNotNull(db.Categories);
        }

        [TestMethod]
        public void DatabaseCategoriesShouldContainAllEightOfTheCategories()
        {
            var mockFactory = new Mock<IFactory>();

            var mathMock = new Mock<ICategory>();
            var historyMock = new Mock<ICategory>();
            var randomMock = new Mock<ICategory>();
            var sciFiMock = new Mock<ICategory>();
            var moviesMock = new Mock<ICategory>();
            var literatureMock = new Mock<ICategory>();
            var scienceMock = new Mock<ICategory>();
            var geographyMock = new Mock<ICategory>();

            var answerMock = new Mock<IAnswer>();
            var questionMock = new Mock<IQuestion>();

            mathMock.SetupGet(x => x.CategoryType).Returns(CategoryType.Math);
            historyMock.SetupGet(x => x.CategoryType).Returns(CategoryType.History);
            randomMock.SetupGet(x => x.CategoryType).Returns(CategoryType.Random);
            sciFiMock.SetupGet(x => x.CategoryType).Returns(CategoryType.SciFi);
            moviesMock.SetupGet(x => x.CategoryType).Returns(CategoryType.Movies);
            literatureMock.SetupGet(x => x.CategoryType).Returns(CategoryType.Literature);
            scienceMock.SetupGet(x => x.CategoryType).Returns(CategoryType.Science);
            geographyMock.SetupGet(x => x.CategoryType).Returns(CategoryType.Geography);

            mockFactory.Setup(x => x.CreateCategory(CategoryType.Math)).Returns(mathMock.Object);
            mockFactory.Setup(x => x.CreateCategory(CategoryType.History)).Returns(historyMock.Object);
            mockFactory.Setup(x => x.CreateCategory(CategoryType.Random)).Returns(randomMock.Object);
            mockFactory.Setup(x => x.CreateCategory(CategoryType.SciFi)).Returns(sciFiMock.Object);
            mockFactory.Setup(x => x.CreateCategory(CategoryType.Movies)).Returns(moviesMock.Object);
            mockFactory.Setup(x => x.CreateCategory(CategoryType.Literature)).Returns(literatureMock.Object);
            mockFactory.Setup(x => x.CreateCategory(CategoryType.Science)).Returns(scienceMock.Object);
            mockFactory.Setup(x => x.CreateCategory(CategoryType.Geography)).Returns(geographyMock.Object);

            mockFactory.Setup(x => x.CreateNormalQuestion(It.IsAny<string>(), It.IsAny<DifficultyLevel>(), It.IsAny<CategoryType>())).Returns(questionMock.Object);
            mockFactory.Setup(x => x.CreateAnswer(It.IsAny<string>(), It.IsAny<bool>())).Returns(answerMock.Object);

            var db = new Database(mockFactory.Object);

            Assert.AreEqual(8, db.Categories.Count);
        }

        [TestMethod]
        public void DatabaseGetRandomQuestionsShouldNotReturnEmptyList()
        {
            var mockFactory = new Mock<IFactory>();

            var mathMock = new Mock<ICategory>();
            var historyMock = new Mock<ICategory>();
            var randomMock = new Mock<ICategory>();
            var sciFiMock = new Mock<ICategory>();
            var moviesMock = new Mock<ICategory>();
            var literatureMock = new Mock<ICategory>();
            var scienceMock = new Mock<ICategory>();
            var geographyMock = new Mock<ICategory>();

            var answerMock = new Mock<IAnswer>();
            var questionMock = new Mock<IQuestion>();

            mathMock.SetupGet(x => x.CategoryType).Returns(CategoryType.Math);
            mathMock.SetupGet(x => x.EasyQuestions).Returns(new List<IQuestion>() { questionMock.Object });
            mathMock.SetupGet(x => x.NormalQuestions).Returns(new List<IQuestion>() { questionMock.Object });
            mathMock.SetupGet(x => x.HardQuestions).Returns(new List<IQuestion>() { questionMock.Object });

            historyMock.SetupGet(x => x.CategoryType).Returns(CategoryType.History);
            randomMock.SetupGet(x => x.CategoryType).Returns(CategoryType.Random);
            sciFiMock.SetupGet(x => x.CategoryType).Returns(CategoryType.SciFi);
            moviesMock.SetupGet(x => x.CategoryType).Returns(CategoryType.Movies);
            literatureMock.SetupGet(x => x.CategoryType).Returns(CategoryType.Literature);
            scienceMock.SetupGet(x => x.CategoryType).Returns(CategoryType.Science);
            geographyMock.SetupGet(x => x.CategoryType).Returns(CategoryType.Geography);

            mockFactory.Setup(x => x.CreateCategory(CategoryType.Math)).Returns(mathMock.Object);
            mockFactory.Setup(x => x.CreateCategory(CategoryType.History)).Returns(historyMock.Object);
            mockFactory.Setup(x => x.CreateCategory(CategoryType.Random)).Returns(randomMock.Object);
            mockFactory.Setup(x => x.CreateCategory(CategoryType.SciFi)).Returns(sciFiMock.Object);
            mockFactory.Setup(x => x.CreateCategory(CategoryType.Movies)).Returns(moviesMock.Object);
            mockFactory.Setup(x => x.CreateCategory(CategoryType.Literature)).Returns(literatureMock.Object);
            mockFactory.Setup(x => x.CreateCategory(CategoryType.Science)).Returns(scienceMock.Object);
            mockFactory.Setup(x => x.CreateCategory(CategoryType.Geography)).Returns(geographyMock.Object);

            mockFactory.Setup(x => x.CreateNormalQuestion(It.IsAny<string>(), It.IsAny<DifficultyLevel>(), It.IsAny<CategoryType>())).Returns(questionMock.Object);
            mockFactory.Setup(x => x.CreateAnswer(It.IsAny<string>(), It.IsAny<bool>())).Returns(answerMock.Object);

            var db = new Database(mockFactory.Object);

            var dbQuestions = db.GetRandomQuestions(mathMock.Object, 1);

            Assert.IsTrue(dbQuestions.Count > 0);
        }

        [TestMethod]
        public void DatabaseGetRandomQuestionsShouldReturnListThatContainsQuestionsWithDifferentDifficulties()
        {
            var mockFactory = new Mock<IFactory>();

            var mathMock = new Mock<ICategory>();
            var historyMock = new Mock<ICategory>();
            var randomMock = new Mock<ICategory>();
            var sciFiMock = new Mock<ICategory>();
            var moviesMock = new Mock<ICategory>();
            var literatureMock = new Mock<ICategory>();
            var scienceMock = new Mock<ICategory>();
            var geographyMock = new Mock<ICategory>();

            var answerMock = new Mock<IAnswer>();
            var easyQuestion = new Mock<IQuestion>();
            var normalQuestion = new Mock<IQuestion>();
            var hardQuestion = new Mock<IQuestion>();

            easyQuestion.SetupGet(x => x.DifficultyLevel).Returns(DifficultyLevel.Easy);
            normalQuestion.SetupGet(x => x.DifficultyLevel).Returns(DifficultyLevel.Normal);
            hardQuestion.SetupGet(x => x.DifficultyLevel).Returns(DifficultyLevel.Hard);

            mathMock.SetupGet(x => x.CategoryType).Returns(CategoryType.Math);
            mathMock.SetupGet(x => x.EasyQuestions).Returns(new List<IQuestion>() { easyQuestion.Object });
            mathMock.SetupGet(x => x.NormalQuestions).Returns(new List<IQuestion>() { normalQuestion.Object });
            mathMock.SetupGet(x => x.HardQuestions).Returns(new List<IQuestion>() { hardQuestion.Object });

            historyMock.SetupGet(x => x.CategoryType).Returns(CategoryType.History);
            randomMock.SetupGet(x => x.CategoryType).Returns(CategoryType.Random);
            sciFiMock.SetupGet(x => x.CategoryType).Returns(CategoryType.SciFi);
            moviesMock.SetupGet(x => x.CategoryType).Returns(CategoryType.Movies);
            literatureMock.SetupGet(x => x.CategoryType).Returns(CategoryType.Literature);
            scienceMock.SetupGet(x => x.CategoryType).Returns(CategoryType.Science);
            geographyMock.SetupGet(x => x.CategoryType).Returns(CategoryType.Geography);

            mockFactory.Setup(x => x.CreateCategory(CategoryType.Math)).Returns(mathMock.Object);
            mockFactory.Setup(x => x.CreateCategory(CategoryType.History)).Returns(historyMock.Object);
            mockFactory.Setup(x => x.CreateCategory(CategoryType.Random)).Returns(randomMock.Object);
            mockFactory.Setup(x => x.CreateCategory(CategoryType.SciFi)).Returns(sciFiMock.Object);
            mockFactory.Setup(x => x.CreateCategory(CategoryType.Movies)).Returns(moviesMock.Object);
            mockFactory.Setup(x => x.CreateCategory(CategoryType.Literature)).Returns(literatureMock.Object);
            mockFactory.Setup(x => x.CreateCategory(CategoryType.Science)).Returns(scienceMock.Object);
            mockFactory.Setup(x => x.CreateCategory(CategoryType.Geography)).Returns(geographyMock.Object);

            mockFactory.Setup(x => x.CreateNormalQuestion(It.IsAny<string>(), It.IsAny<DifficultyLevel>(), It.IsAny<CategoryType>())).Returns(normalQuestion.Object);
            mockFactory.Setup(x => x.CreateAnswer(It.IsAny<string>(), It.IsAny<bool>())).Returns(answerMock.Object);

            var db = new Database(mockFactory.Object);

            var dbQuestions = db.GetRandomQuestions(mathMock.Object, 1);
            bool areSame = false;

            for (int i = 0; i < dbQuestions.Count; i++)
            {
                for (int j = i+1; j < dbQuestions.Count; j++)
                {
                    if (dbQuestions[i].DifficultyLevel == dbQuestions[j].DifficultyLevel)
                    {
                        areSame = true;
                        break;
                    }
                }
            }

            Assert.IsFalse(areSame);
        }
    }
}
