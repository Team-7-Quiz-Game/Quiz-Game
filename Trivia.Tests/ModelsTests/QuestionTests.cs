using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
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
        public void AddAnswerFluentShouldAddToTheNormalQuestionAnswerFluently()
        {
            var answerMock = new Mock<IAnswer>();
            var text = "NormalQuestionText";

            var question = new NormalQuestion(text, DifficultyLevel.Easy, CategoryType.Geography, QuestionType.Normal);

            question.AddAnswerFluent(answerMock.Object)
                .AddAnswerFluent(answerMock.Object)
                .AddAnswerFluent(answerMock.Object)
                .AddAnswerFluent(answerMock.Object);

            Assert.IsTrue(question.Answers.Count == 4);
        }

        [TestCategory("QuestionTests")]
        [TestMethod]
        public void ShuffleAnswersShouldShuffleTheAnswers()
        {
            var answerMock = new Mock<IAnswer>();
            var answerMock2 = new Mock<IAnswer>();
            var answerMock3 = new Mock<IAnswer>();
            var answerMock4 = new Mock<IAnswer>();
            var text = "NormalQuestionText";

            var question = new NormalQuestion(text, DifficultyLevel.Easy, CategoryType.Geography, QuestionType.Normal);

            question.AddAnswerFluent(answerMock.Object)
                .AddAnswerFluent(answerMock2.Object)
                .AddAnswerFluent(answerMock3.Object)
                .AddAnswerFluent(answerMock4.Object);

            question.ShuffleAnswers();

            Assert.IsTrue(question.Answers[0] != answerMock.Object ||
                question.Answers[1] != answerMock2.Object ||
                question.Answers[2] != answerMock3.Object ||
                question.Answers[3] != answerMock4.Object);
        }

        [TestCategory("TimedQuestionTests")]
        [TestMethod]
        public void ConstructorShouldCreateValidTimedQuestionWhenValidParametersAreProvided()
        {
            var text = "QuestionText";
            var question = new TimedQuestion(text, DifficultyLevel.Easy, CategoryType.Geography, 10);

            Assert.IsInstanceOfType(question, typeof(IQuestion));
        }

        [TestCategory("TimedQuestionTests")]
        [TestMethod]
        public void TimedQuestionConstructorShouldThorwArgumentOutOfRangeExceptionWhenTimeBelowTheLimitIsProvided()
        {
            var text = "QuestionText";

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new TimedQuestion(text, DifficultyLevel.Easy, CategoryType.Geography, -10));
        }


        [TestCategory("TimedQuestionTests")]
        [TestMethod]
        public void TimedQuestionConstructorShouldThorwArgumentOutOfRangeExceptionWhenTimeAboveTheLimitIsProvided()
        {
            var text = "QuestionText";

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new TimedQuestion(text, DifficultyLevel.Easy, CategoryType.Geography, 30));
        }

        [TestCategory("TimedQuestionTests")]
        [TestMethod]
        public void TimedQuestionTimeGetterShouldCorrectTimeWhenValidParametersAreProvidedToTheConstructor()
        {
            var text = "QuestionText";
            var time = 10;

            var question = new TimedQuestion(text, DifficultyLevel.Easy, CategoryType.Geography, time);

            Assert.AreEqual(time, question.Time);
        }
    }
}
