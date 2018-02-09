using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trivia.Common.Enums;
using Trivia.Contracts;
using Trivia.Core;
using Trivia.Core.Contracts;
using Trivia.Models.Question;

namespace Trivia.Tests.CoreTests
{
    [TestClass]
    public class FactoryTests
    {
        [TestMethod]
        public void CreateAnswerMethodShouldCreateACorrectAnswerWithGivenText()
        {
            var answerText = "This is a correct answer";
            var factory = new Factory();
            IAnswer answer = factory.CreateAnswer(answerText, true);

            Assert.IsTrue(answer.IsCorrect);
        }

        [TestMethod]
        public void CreateAnswerMethodShouldCreateAnIncorrectAnswerWithGivenText()
        {
            var answerText = "This is an incorrect answer";
            var factory = new Factory();
            IAnswer answer = factory.CreateAnswer(answerText, false);

            Assert.IsFalse(answer.IsCorrect);
        }

        [TestMethod]
        public void CreateAnswerMethodShouldCreateAnAnswerWithGivenText()
        {
            var answerText = "This is a correct answer";
            var factory = new Factory();
            IAnswer answer = factory.CreateAnswer(answerText, true);

            Assert.AreSame(answer.AnswerText, answerText);
        }

        [TestMethod]
        public void CreateAnswerMethodShouldCreateAValidAnswer()
        {
            var answerText = "This is a correct answer";
            var factory = new Factory();
            IAnswer answer = factory.CreateAnswer(answerText, true);

            Assert.IsNotNull(answer);
        }

        [TestMethod]
        public void CreateAnswerMethodShouldCreateATypeOfAnswer()
        {
            var answerText = "This is a correct answer";
            var factory = new Factory();
            IAnswer answer = factory.CreateAnswer(answerText, true);

            Assert.IsInstanceOfType(answer, typeof(Answer));
        }

        [TestMethod]
        public void CreateABonusQuestionShouldReturnTheBonusQuestionWithTheProperText()
        {
            var questionText = "Who wrote \"The Great Gatsby\"?";
            var categoryType = CategoryType.Literature;
            var pointsMultiplier = 5;
            var factory = new Factory();
            IQuestion bonusQuestion = factory.CreateBonusQuestion(questionText, DifficultyLevel.Easy, categoryType, pointsMultiplier);

            Assert.AreEqual("Who wrote \"The Great Gatsby\"?", bonusQuestion.QuestionText);
        }

        [TestMethod]
        public void CreateABonusQuestionShouldReturnAQuestionInTheProperCategory()
        {
            var questionText = "Who wrote \"The Great Gatsby\"?";
            var categoryType = CategoryType.Literature;
            var pointsMultiplier = 5;
            var factory = new Factory();
            IQuestion bonusQuestion = factory.CreateBonusQuestion(questionText, DifficultyLevel.Hard, categoryType, pointsMultiplier);

            Assert.AreEqual(categoryType, bonusQuestion.CategoryType);
        }

        [TestMethod]
        public void CreateABonusQuestionShouldThrowAnExeptionWhenPointsMultiplierIsGreaterThanTheGivenMaxValue()
        {
            var questionText = "Who wrote \"The Great Gatsby\"?";
            var categoryType = CategoryType.Literature;
            var pointsMultiplier = 20;
            var factory = new Factory();          

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => factory.CreateBonusQuestion(questionText, DifficultyLevel.Easy, categoryType, pointsMultiplier));
        }

        [TestMethod]
        public void CreateABonusQuestionShouldThrowAnExeptionWhenPointsMultiplierIsLessThanTheGivenMaxValue()
        {
            var questionText = "Who wrote \"The Great Gatsby\"?";
            var categoryType = CategoryType.Literature;
            var pointsMultiplier = -1;
            var factory = new Factory();

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => factory.CreateBonusQuestion(questionText, DifficultyLevel.Easy, categoryType, pointsMultiplier));
        }

        [TestMethod]
        public void CreateABonusQuestionMethodShouldCreateATypeOfQuestion()
        {
            var questionText = "Who wrote \"The Great Gatsby\"?";
            var categoryType = CategoryType.Literature;
            var pointsMultiplier = 5;
            var factory = new Factory();
            IQuestion bonusQuestion = factory.CreateBonusQuestion(questionText, DifficultyLevel.Hard, categoryType, pointsMultiplier);

            Assert.IsInstanceOfType(bonusQuestion, typeof(Question));
        }

        [TestMethod]
        public void CreateANormalQuestionShouldReturnTheNormalQuestionWithTextDifficultyLevelAndCategory()
        {
            var questionText = "Which is the biggest country in the world by area?";
            var categoryType = CategoryType.Geography;
            var factory = new Factory();
            IQuestion normalQuestion = factory.CreateNormalQuestion(questionText, DifficultyLevel.Easy, CategoryType.Geography);

            Assert.AreEqual("Which is the biggest country in the world by area?", normalQuestion.QuestionText);
            Assert.AreEqual(categoryType, normalQuestion.CategoryType);
        }
    }
}
