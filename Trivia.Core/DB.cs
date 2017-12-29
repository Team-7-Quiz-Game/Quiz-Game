using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trivia.Contracts;
using Trivia.Core.Contracts;
using Trivia.Common;
using Trivia.Models.Question;
using Trivia.Models.Category;

namespace Trivia.Core
{
    public class DB
    {
        private IList<ICategory> categories;
        private readonly IFactory factory;

        public DB(IFactory factory)
        {
            this.categories = new List<ICategory>();
            this.factory = factory;
            this.PopulateCategories();
            this.PopulateQuestions();
        }

        public IList<ICategory> Categories => this.categories;

        public IList<IQuestion> GetRandomQuestions(ICategory category, int numOfQuestions)
        {
            var uniqueQuestionsList = new List<IQuestion>();
            var selectedCategory = this.Categories.Single(c => c.CategoryType == category.CategoryType);

            var easyQuestionIndices = GetRandomIndices(selectedCategory.EasyQuestions.Count, numOfQuestions);

            foreach (var index in easyQuestionIndices)
            {
                uniqueQuestionsList.Add(selectedCategory.EasyQuestions[index]);
            }

            var normalQuestionIndices = GetRandomIndices(selectedCategory.NormalQuestions.Count, numOfQuestions);

            foreach (var index in normalQuestionIndices)
            {
                uniqueQuestionsList.Add(selectedCategory.NormalQuestions[index]);
            }

            var hardQuestionIndices = GetRandomIndices(selectedCategory.HardQuestions.Count, numOfQuestions);

            foreach (var index in hardQuestionIndices)
            {
                uniqueQuestionsList.Add(selectedCategory.HardQuestions[index]);
            }

            return uniqueQuestionsList;
        }

        private IList<int> GetRandomIndices(int listCount, int numOfQuestions)
        {
            var listOfUniqueIndices = new List<int>();

            Random rnd = new Random();
            int r;

            while (true)
            {
                r = rnd.Next(listCount);

                if (!listOfUniqueIndices.Contains(r))
                {
                    listOfUniqueIndices.Add(r);
                }

                if (listOfUniqueIndices.Count == numOfQuestions)
                {
                    break;
                }
            }

            return listOfUniqueIndices;
        }

        private void PopulateCategories()
        {
            var history = factory.CreateCategory(CategoryType.History);
            this.categories.Add(history);

            var geography = factory.CreateCategory(CategoryType.Geography);
            this.categories.Add(geography);

            //TODO - add other categories
        }

        private void PopulateQuestions()
        {
            var qText = "When did it happen?";
            var historyQ1 = this.factory.CreateNormalQuestion(qText, DifficultyLevel.Easy, CategoryType.History);

            var a1 = this.factory.CreateAnswer("Yesterday", false);
            var a2 = this.factory.CreateAnswer("Never", false);
            var a3 = this.factory.CreateAnswer("No one knows", false);
            var a4 = this.factory.CreateAnswer("The day before tomorrow", true);

            AddQuestion(historyQ1, a1, a2, a3, a4);
            // ===TODO - REPEAT above template for all questions==
        }

        private void AddQuestion(IQuestion question, IAnswer answer1, IAnswer answer2, IAnswer answer3, IAnswer answer4)
        {
            question.AddAnswer(answer1);
            question.AddAnswer(answer2);
            question.AddAnswer(answer3);
            question.AddAnswer(answer4);

            this.categories.Single(x => x.CategoryType == question.CategoryType).AddQuestion(question);
        }

    }
}
