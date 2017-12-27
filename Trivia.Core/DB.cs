using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trivia.Contracts;
using Trivia.Core.Contracts;
using Trivia.Common;
using Trivia.Models.Question;

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

        public IList<ICategory> Categories { get => this.categories; }

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

            var a1 = new Answer("Yesterday", false);
            var a2 = new Answer("Never", false);
            var a3 = new Answer("No one knows", false);
            var a4 = new Answer("The day before tomorrow", true);

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
