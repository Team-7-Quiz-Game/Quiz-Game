using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trivia.Common;
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

        public Question(string questionText, DifficultyLevel difficultyLevel, CategoryType category, QuestionType questionType)
        {
            //Guard
            this.questionText = questionText;
            this.answers = new List<IAnswer>();
            this.difficultyLevel = difficultyLevel;
            this.questionType = questionType;
        }

        public string QuestionText => questionText;

        public IList<IAnswer> Answers => this.answers;

        public DifficultyLevel DifficultyLevel => difficultyLevel;

        public int Points
        {
            get => this.points;
            protected set => points = value;
        }
        public QuestionType QuestionType => this.questionType;

        public void AddAnswer(IAnswer answer)
        {
            //Guard
            this.answers.Add(answer);
        }

        public override string ToString()
        {
            return $"{this.questionText}";
        }
    }
}
