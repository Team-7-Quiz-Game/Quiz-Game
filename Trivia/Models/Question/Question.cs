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

        public Question(string questionText, IList<IAnswer> answers, int points, DifficultyLevel difficultyLevel, CategoryType category)
        {
            //Guard
            this.questionText = questionText;
            this.answers = new List<IAnswer>();
            this.difficultyLevel = difficultyLevel;
        }

        public string QuizQuestion => questionText;

        public DifficultyLevel DifficultyLevel => difficultyLevel;

        public int Points
        {
            get => this.points;
            protected set => points = value;
        }

        public void AddAnswer(string text)
        {
            //Guard
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"{this.questionText}";
        }
    }
}
