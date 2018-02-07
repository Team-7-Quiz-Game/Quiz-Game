using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trivia.Common.Enums;
using Trivia.Contracts;
using Trivia.Core;

namespace Trivia.Tests.Engine
{
    [TestClass]
    public class FactoryTests
    {
        // TODO: check if tests are correct
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
