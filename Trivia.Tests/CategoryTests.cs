using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Trivia.Tests
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