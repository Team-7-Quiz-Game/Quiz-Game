using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using Trivia.Common.Enums;
using Trivia.Contracts;
using Trivia.Models.Question;

namespace Trivia.Tests.Models
{
    [TestClass]
    public class QuestionTests
    {
        [TestCategory("BonusQuestionTests")]
        [TestMethod]

        public void ConstructorShouldReturnSameTextForQuestionWhenGivenValidParameters()
        {
            var nameQuestion = "Bonus";
            var bonusQuestion = new BonusQuestion(nameQuestion, DifficultyLevel.Hard, CategoryType.Geography, 5);
            Assert.AreEqual("Bonus", bonusQuestion.QuestionText);
        }

        [TestCategory("BonusQuestionTests")]
        [TestMethod]

        public void ConstructorShouldReturnProperlyCalculatedPointsBasedOnFormula()
        {
            var pointsMultiplier = 5;
            var bonusQuestion = new BonusQuestion("Bonus", DifficultyLevel.Normal, CategoryType.Geography, pointsMultiplier);
            var pointsAccordingToFormula = (int)DifficultyLevel.Normal * 100 * pointsMultiplier;

            Assert.AreEqual(pointsAccordingToFormula, bonusQuestion.Points);
        }

        [TestCategory("NormalQuestionTests")]
        [TestMethod]

        public void ConstructorShouldReturnProperlyCalculatedPointsForNormalQuestionBasedOnFormula()
        {
            var normalQuestion = new NormalQuestion("Normal", DifficultyLevel.Hard, CategoryType.Movies, QuestionType.Normal);
            var pointsCalculatedByFormula = (int)DifficultyLevel.Hard * 100;

            Assert.AreEqual(pointsCalculatedByFormula, normalQuestion.Points);
        }

        [TestCategory("QuestionTests")]
        [TestMethod]

        public void AddAnswerFluentShouldAddToTheAnswerList()
        {
            var answer = new Answer("This is an answer", false);
            var listAnswersFake = new Mock<IList<IAnswer>>();
            listAnswersFake.Setup(x => x.Add(answer)).Verifiable();
        }
    }
}
