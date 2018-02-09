using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Trivia.Common.Enums;
using Trivia.Models.Category;
using Trivia.Models.Question;

namespace Trivia.Tests.Models
{
    [TestClass]
    public class CategoryTests
    {
        [TestMethod]
        public void CheckedCategoriesListShouldCountainTwoCategories()
        {
            var checkedCategories = new List<string>();
            checkedCategories.Add("Science");
            checkedCategories.Add("Math");
            Assert.AreEqual(2, checkedCategories.Count);
        }

        [TestMethod]
        public void CategoryShouldNotBeNull()
        {
            var categoryType = CategoryType.SciFi;
            var category = new Category(categoryType);
            Assert.IsNotNull(category);
        }

        [TestMethod]
        public void CategoryConstructorShouldCreateEmptyListForEasyQuestions()
        {
            var categoryType = CategoryType.SciFi;
            var category = new Category(categoryType);

            Assert.AreEqual(0, category.EasyQuestions.Count);
        }

        [TestMethod]
        public void CategoryConstructorShouldCreateEmptyListForNormalQuestions()
        {
            var categoryType = CategoryType.SciFi;
            var category = new Category(categoryType);

            Assert.AreEqual(0, category.NormalQuestions.Count);
        }

        [TestMethod]
        public void CategoryConstructorShouldCreateEmptyListForHardQuestions()
        {
            var categoryType = CategoryType.SciFi;
            var category = new Category(categoryType);

            Assert.AreEqual(0, category.HardQuestions.Count);
        }

        [TestMethod]
        public void AddQuestionMethodShouldAddAQuestionOnlyToEasyQuestionsList()
        {
            var categoryType = CategoryType.SciFi;
            var category = new Category(categoryType);
            var question = new NormalQuestion("Text question?", DifficultyLevel.Easy, categoryType, QuestionType.Normal);

            category.AddQuestion(question);
            Assert.AreEqual(1, category.EasyQuestions.Count);
            Assert.AreEqual(0, category.NormalQuestions.Count);
            Assert.AreEqual(0, category.HardQuestions.Count);
        }

        [TestMethod]
        public void AddQuestionMethodShouldAddAQuestionOnlyToNormalQuestionsList()
        {
            var categoryType = CategoryType.SciFi;
            var category = new Category(categoryType);
            var question = new NormalQuestion("Text question?", DifficultyLevel.Normal, categoryType, QuestionType.Normal);

            category.AddQuestion(question);
            Assert.AreEqual(1, category.NormalQuestions.Count);
            Assert.AreEqual(0, category.EasyQuestions.Count);
            Assert.AreEqual(0, category.HardQuestions.Count);
        }

        [TestMethod]
        public void AddQuestionMethodShouldAddAQuestionOnlyToHardQuestionsList()
        {
            var categoryType = CategoryType.SciFi;
            var category = new Category(categoryType);
            var question = new NormalQuestion("Text question?", DifficultyLevel.Hard, categoryType, QuestionType.Normal);

            category.AddQuestion(question);
            Assert.AreEqual(1, category.HardQuestions.Count);
            Assert.AreEqual(0, category.NormalQuestions.Count);
            Assert.AreEqual(0, category.EasyQuestions.Count);
        }
    }
}