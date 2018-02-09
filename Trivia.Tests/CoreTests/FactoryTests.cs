using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Trivia.Common.Enums;
using Trivia.Contracts;
using Trivia.Core;
using Trivia.Models.Category;
using Trivia.Models.Hint;
using Trivia.Models.Player;
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
        public void CreateABonusQuestionShouldThrowAnExeptionWhenPointsMultiplierIsLessThanTheGivenMinValue()
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
        public void CreateABonusQuestionShouldThrowAnExeptionWhenTheQuestionTextIsNull()
        {
            string questionText = null;
            var pointsMultiplier = 2;
            var categoryType = CategoryType.Literature;
            var factory = new Factory();

            Assert.ThrowsException<NullReferenceException>(() => factory.CreateBonusQuestion(questionText, DifficultyLevel.Easy, categoryType, pointsMultiplier));
        }

        [TestMethod]
        public void CreateATimedQuestionShouldReturnTheTimedQuestionWithTheProperText()
        {
            var questionText = "Are we testing the timed question now?";
            var categoryType = CategoryType.Random;
            var timeForAnswer = 10;
            var factory = new Factory();
            IQuestion timedQuestion = factory.CreateTimedQuestion(questionText, DifficultyLevel.Easy, categoryType, timeForAnswer);

            Assert.AreEqual("Are we testing the timed question now?", timedQuestion.QuestionText);
        }

        [TestMethod]
        public void CreateATimedQuestionShouldReturnAQuestionInTheProperCategory()
        {
            var questionText = "So now we are testing the category, right?";
            var categoryType = CategoryType.Movies;
            var timeForAnswer = 12;
            var factory = new Factory();
            IQuestion timedQuestion = factory.CreateTimedQuestion(questionText, DifficultyLevel.Easy, categoryType, timeForAnswer);

            Assert.AreEqual(categoryType, timedQuestion.CategoryType);
        }

        [TestMethod]
        public void CreateATimedQuestionShouldThrowAnExeptionWhenTheTimeForAnswerIsGreaterThanTheGivenMaxValue()
        {
            var questionText = "We are testing now the max value?";
            var categoryType = CategoryType.Literature;
            var timeForAnswer = 50;
            var factory = new Factory();

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => factory.CreateTimedQuestion(questionText, DifficultyLevel.Easy, categoryType, timeForAnswer));
        }

        [TestMethod]
        public void CreateATimedQuestionShouldThrowAnExeptionWhenTheTimeForAnswerIsLessThanTheGivenMinValue()
        {
            var questionText = "We are testing now a value lower than the min one?";
            var categoryType = CategoryType.Literature;
            var timeForAnswer = -1;
            var factory = new Factory();

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => factory.CreateTimedQuestion(questionText, DifficultyLevel.Easy, categoryType, timeForAnswer));
        }

        [TestMethod]
        public void CreateATimedQuestionMethodShouldCreateATypeOfQuestion()
        {
            var questionText = "Are we testing now the type of the created object?";
            var categoryType = CategoryType.Movies;
            var timeForAnswer = 10;
            var factory = new Factory();
            IQuestion timedQuestion = factory.CreateTimedQuestion(questionText, DifficultyLevel.Hard, categoryType, timeForAnswer);

            Assert.IsInstanceOfType(timedQuestion, typeof(Question));
        }

        [TestMethod]
        public void CreateATimedQuestionShouldThrowAnExeptionWhenTheQuestionTextIsNull()
        {
            string questionText = null;
            var timeForAnswer = 10;
            var categoryType = CategoryType.Literature;
            var factory = new Factory();

            Assert.ThrowsException<NullReferenceException>(() => factory.CreateTimedQuestion(questionText, DifficultyLevel.Easy, categoryType, timeForAnswer));
        }

        [TestMethod]
        public void CreateANormalQuestionShouldReturnTheNormalQuestionWithTheProperText()
        {
            var questionText = "4 x 4?";
            var categoryType = CategoryType.Math;
            var factory = new Factory();
            IQuestion timedQuestion = factory.CreateNormalQuestion(questionText, DifficultyLevel.Easy, categoryType);

            Assert.AreEqual("4 x 4?", timedQuestion.QuestionText);
        }

        [TestMethod]
        public void CreateANormalQuestionShouldReturnAQuestionInTheProperCategory()
        {
            var questionText = "2 + 2?";
            var categoryType = CategoryType.Math;
            var factory = new Factory();
            IQuestion timedQuestion = factory.CreateNormalQuestion(questionText, DifficultyLevel.Easy, categoryType);

            Assert.AreEqual(categoryType, timedQuestion.CategoryType);
        }

        [TestMethod]
        public void CreateANormalQuestionShouldThrowAnExeptionWhenTheQuestionTextIsNull()
        {
            string questionText = null;
            var categoryType = CategoryType.Literature;
            var factory = new Factory();

            Assert.ThrowsException<NullReferenceException>(() => factory.CreateNormalQuestion(questionText, DifficultyLevel.Easy, categoryType));
        }

        [TestMethod]
        public void CreateANormalQuestionMethodShouldCreateATypeOfQuestion()
        {
            var questionText = "Are we testing now the type of the created object?";
            var categoryType = CategoryType.Science;
            var factory = new Factory();
            IQuestion timedQuestion = factory.CreateNormalQuestion(questionText, DifficultyLevel.Hard, categoryType);

            Assert.IsInstanceOfType(timedQuestion, typeof(Question));
        }

        [TestMethod]
        public void FactoryShouldReturnANormalPlayerWhenGivenAName()
        {
            var namePlayer = "Fluffy";
            var factory = new Factory();
            var normalPlayer = factory.CreateNormalPlayer(namePlayer);

            Assert.IsInstanceOfType(normalPlayer, typeof(NormalPlayer));
        }

        [TestMethod]
        public void FactoryShouldThrowAnExeptionWhenANormalPlayerGivenNameIsNull()
        {
            string namePlayer = null;
            var factory = new Factory();

            Assert.ThrowsException<NullReferenceException>(() => factory.CreateNormalPlayer(namePlayer));
        }

        [TestMethod]
        public void FactoryShouldReturnAQuizzardPlayerWhenGivenAName()
        {
            var namePlayer = "Quizzard Master";
            var factory = new Factory();
            var quizzardPlayer = factory.CreateQuizzardPlayer(namePlayer);

            Assert.IsInstanceOfType(quizzardPlayer, typeof(QuizzardPlayer));
        }

        [TestMethod]
        public void FactoryShouldThrowAnExeptionWhenAQuizzardPlayerGivenNameIsNull()
        {
            string namePlayer = null;
            var factory = new Factory();

            Assert.ThrowsException<NullReferenceException>(() => factory.CreateQuizzardPlayer(namePlayer));
        }

        [TestMethod]
        public void FactoryShouldReturnANewCategoryWhenGivenATypeOfCategory()
        {
            var category = CategoryType.History;
            var factory = new Factory();
            var categoryNew = factory.CreateCategory(category);

            Assert.IsInstanceOfType(categoryNew, typeof(Category));
        }

        [TestMethod]
        public void FactoryShouldReturnANewSkipQuestionHintWhenGivenAQuantity()
        {
            var quantity = 2;
            var factory = new Factory();
            var skipQuestionHint = factory.CreateSkipQuestionHint(quantity);

            Assert.IsInstanceOfType(skipQuestionHint, typeof(Hint));
        }

        [TestMethod]
        public void FactoryShouldThrowAnExeptionForANewSkipQuestionHintWhenGivenAnInvalidQuantity()
        {
            var quantity = -10;
            var factory = new Factory();

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => factory.CreateSkipQuestionHint(quantity));
        }

        [TestMethod]
        public void FactoryShouldReturnANewFiftyFiftyHintWhenGivenAQuantity()
        {
            var quantity = 2;
            var factory = new Factory();
            var fiftyFiftyHint = factory.CreateSkipQuestionHint(quantity);

            Assert.IsInstanceOfType(fiftyFiftyHint, typeof(Hint));
        }

        [TestMethod]
        public void FactoryShouldThrowAnExeptionForANewFiftyFiftyHintWhenGivenAnInvalidQuantity()
        {
            var quantity = -10;
            var factory = new Factory();

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => factory.CreateFiftyFiftyHint(quantity));
        }
    }
}