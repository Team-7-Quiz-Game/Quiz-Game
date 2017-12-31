using System;
using System.Collections.Generic;
using Trivia.Common.Enums;
using Trivia.Common.Utils;
using Trivia.Contracts;

namespace Trivia.Models.Category
{
    public class Category : ICategory
    {
        private const int MaxQuestionsCount = 10;
        private readonly CategoryType categoryType;
        private IList<IQuestion> easyQuestions;
        private IList<IQuestion> normalQuestions;
        private IList<IQuestion> hardQuestions;
        
        public Category(CategoryType categoryType)
        {
            Validator.CheckIfNull(categoryType, string.Format(GlobalConstants.ObjectCannotBeNull, "Category type"));

            this.categoryType = categoryType;
            this.easyQuestions = new List<IQuestion>();
            this.normalQuestions = new List<IQuestion>();
            this.hardQuestions = new List<IQuestion>();
        }
        
        public CategoryType CategoryType => this.categoryType;

        public IList<IQuestion> EasyQuestions => this.easyQuestions.Clone();

        public IList<IQuestion> NormalQuestions => this.normalQuestions.Clone();

        public IList<IQuestion> HardQuestions => this.hardQuestions.Clone();

        private void AddEasyQuestion(IQuestion question)
        {
            Validator.CheckIfNull(question, string.Format(GlobalConstants.ObjectCannotBeNull, "Easy question"));

            if (this.easyQuestions.Count > MaxQuestionsCount)
            {
                throw new ArgumentException($"Easy questions per category must be {MaxQuestionsCount}!");
            }

            this.easyQuestions.Add(question);
        }

        private void AddNormalQuestion(IQuestion question)
        {
            Validator.CheckIfNull(question, string.Format(GlobalConstants.ObjectCannotBeNull, "Normal question"));

            if (this.normalQuestions.Count > MaxQuestionsCount)
            {
                throw new ArgumentException($"Normal questions per category must be {MaxQuestionsCount}!");
            }

            this.normalQuestions.Add(question);
        }

        private void AddHardQuestion(IQuestion question)
        {
            Validator.CheckIfNull(question, string.Format(GlobalConstants.ObjectCannotBeNull, "Hard question"));

            if (this.hardQuestions.Count > MaxQuestionsCount)
            {
                throw new ArgumentException($"Hard questions per category must be {MaxQuestionsCount}!");
            }

            this.hardQuestions.Add(question);
        }

        public void AddQuestion(IQuestion question)
        {
            Validator.CheckIfNull(question, string.Format(GlobalConstants.ObjectCannotBeNull, "Question"));

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
                default: throw new ArgumentException("Difficulty level not valid!");
            }
        }
    }
}
