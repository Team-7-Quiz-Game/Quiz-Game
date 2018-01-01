using System;
using System.Collections.Generic;
using Trivia.Common.Enums;
using Trivia.Common.Exceptions;
using Trivia.Common.Utils;
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
            Validator.CheckIntAboveMax(this.easyQuestions.Count, GlobalConstants.MaxQuestionsInCategory, string.Format(GlobalConstants.MaxQuestionsInCategoryErrorMessage, "Easy questions", GlobalConstants.MaxQuestionsInCategory));
            
            this.easyQuestions.Add(question);
        }

        private void AddNormalQuestion(IQuestion question)
        {
            Validator.CheckIfNull(question, string.Format(GlobalConstants.ObjectCannotBeNull, "Normal question"));
            Validator.CheckIntAboveMax(this.easyQuestions.Count, GlobalConstants.MaxQuestionsInCategory, string.Format(GlobalConstants.MaxQuestionsInCategoryErrorMessage, "Normal questions", GlobalConstants.MaxQuestionsInCategory));

            this.normalQuestions.Add(question);
        }

        private void AddHardQuestion(IQuestion question)
        {
            Validator.CheckIfNull(question, string.Format(GlobalConstants.ObjectCannotBeNull, "Hard question"));
            Validator.CheckIntAboveMax(this.easyQuestions.Count, GlobalConstants.MaxQuestionsInCategory, string.Format(GlobalConstants.MaxQuestionsInCategoryErrorMessage, "Hard questions", GlobalConstants.MaxQuestionsInCategory));
            
            this.hardQuestions.Add(question);
        }

        public void AddQuestion(IQuestion question)
        {
            Validator.CheckIfNull(question, string.Format(GlobalConstants.ObjectCannotBeNull, "Question"));

            switch (question.DifficultyLevel)
            {
                case DifficultyLevel.Easy:
                    if (this.easyQuestions.Contains(question))
                    {
                        throw new QuestionAlreadyAddedException(string.Format(GlobalConstants.QuestionAlreadyAddedMessage, question.QuestionText));
                    }

                    this.AddEasyQuestion(question);
                    break;
                case DifficultyLevel.Normal:
                    if (this.normalQuestions.Contains(question))
                    {
                        throw new QuestionAlreadyAddedException(string.Format(GlobalConstants.QuestionAlreadyAddedMessage, question.QuestionText));
                    }

                    this.AddNormalQuestion(question);
                    break;
                case DifficultyLevel.Hard:
                    if (this.hardQuestions.Contains(question))
                    {
                        throw new QuestionAlreadyAddedException(string.Format(GlobalConstants.QuestionAlreadyAddedMessage, question.QuestionText));
                    }

                    this.AddHardQuestion(question);
                    break;
                default: throw new ArgumentException("Difficulty level not valid!");
            }
        }
    }
}
