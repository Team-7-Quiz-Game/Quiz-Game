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

            var qA1 = new Answer("Yesterday", false);
            var qA2 = new Answer("Never", false);
            var qA3 = new Answer("No one knows", false);
            var qA4 = new Answer("The day before tomorrow", true);

            var historyQ1 = this.factory.CreateNormalQuestion(qText, DifficultyLevel.Easy, CategoryType.History);

            historyQ1.AddAnswer(qA1);
            historyQ1.AddAnswer(qA2);
            historyQ1.AddAnswer(qA3);
            historyQ1.AddAnswer(qA4);

            this.categories.Single(x => x.CategoryType == historyQ1.CategoryType).AddQuestion(historyQ1);
        }

    }
}
