using System.Collections.Generic;
using Trivia.Common.Enums;
using Trivia.Common.Utils;
using Trivia.Contracts;

namespace Trivia.Models.Question
{
    public abstract class Question : IQuestion
    {
        private readonly string questionText;
        private readonly IList<IAnswer> answers;
        private int points;
        private readonly DifficultyLevel difficultyLevel;
        private readonly QuestionType questionType;
        private readonly CategoryType categoryType;
        private readonly int id;

        public Question(string questionText, DifficultyLevel difficultyLevel, CategoryType categoryType, QuestionType questionType)
        {
            Validator.CheckIfStringIsNullOrEmpty(questionText, string.Format(GlobalConstants.StringCannotBeNullOrEmpty, "Question text"));
            Validator.CheckIfNull(difficultyLevel, string.Format(GlobalConstants.ObjectCannotBeNull, "Difficulty level"));
            Validator.CheckIfNull(categoryType, string.Format(GlobalConstants.ObjectCannotBeNull, "Category type"));
            Validator.CheckIfNull(questionType, string.Format(GlobalConstants.ObjectCannotBeNull, "Question type"));

            this.questionText = questionText;
            this.answers = new List<IAnswer>();
            this.difficultyLevel = difficultyLevel;
            this.categoryType = categoryType;
            this.questionType = questionType;
            this.id = IdGenerator.GetId;
        }

        public string QuestionText => this.questionText;

        public IList<IAnswer> Answers => this.answers.Clone();

        public DifficultyLevel DifficultyLevel => this.difficultyLevel;

        public int Points
        {
            get => this.points;
            protected set => points = value;
        }

        public QuestionType QuestionType => this.questionType;

        public CategoryType CategoryType => this.categoryType;

        public int Id => this.id;

        public void AddAnswer(IAnswer answer)
        {
            Validator.CheckIfNull(answer, string.Format(GlobalConstants.ObjectCannotBeNull, "Answer"));
            Validator.CheckIntAboveMax(this.answers.Count, GlobalConstants.MaxAnswersPerQuestion, string.Format(GlobalConstants.MaxAnswersPerQuestionErrorMessage, GlobalConstants.MaxAnswersPerQuestion));

            this.answers.Add(answer);
        }

        public IQuestion AddAnswerFluent(IAnswer answer)
        {
            Validator.CheckIfNull(answer, string.Format(GlobalConstants.ObjectCannotBeNull, "Answer"));

            this.answers.Add(answer);

            return this;
        }

        public void ShuffleAnswers()
        {
            this.answers.Shuffle();
        }

        public override string ToString()
        {
            return $"{this.questionText}";
        }
    }
}
