using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trivia.Common;
using Trivia.Contracts;

namespace Trivia.Models.Category
{
    public class Category : ICategory
    {
        private readonly CategoryType categoryType;
        private IList<IQuestion> easyQuestions;
        private IList<IQuestion> normalQuestions;
        private IList<IQuestion> hardQuestions;
        
        public Category(CategoryType categoryType)
        {
            //Guard
            this.categoryType = categoryType;
            this.easyQuestions = new List<IQuestion>();
            this.normalQuestions = new List<IQuestion>();
            this.hardQuestions = new List<IQuestion>();
        }
        
        public CategoryType CategoryType => this.categoryType;

        private void AddEasyQuestion(IQuestion question)
        {
            if (this.easyQuestions.Count > 5)
            {
                throw new ArgumentException("Easy questions per category must be 5!");
            }

            this.easyQuestions.Add(question);
        }

        private void AddNormalQuestion(IQuestion question)
        {
            if (this.normalQuestions.Count > 5)
            {
                throw new ArgumentException("Normal questions per category must be 5!");
            }

            this.normalQuestions.Add(question);
        }

        private void AddHardQuestion(IQuestion question)
        {
            if (this.hardQuestions.Count > 5)
            {
                throw new ArgumentException("Hard questions per category must be 5!");
            }

            this.hardQuestions.Add(question);
        }

        public void AddQuestion(IQuestion question)
        {
            //guard
            switch (question.DifficultyLevel)
            {
                case DifficultyLevel.Easy:
                    this.AddEasyQuestion(question);
                    break;
                case DifficultyLevel.Normal:
                    this.AddNormalQuestion(question);
                    break;
                case DifficultyLevel.Hard:
                    this.AddHardQuestion(question);
                    break;
                default:
                    break;
            }
        }
    }
}
