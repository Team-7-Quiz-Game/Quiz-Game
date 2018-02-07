using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using Trivia.Contracts;
using Trivia.Core.Contracts;
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
    }
}