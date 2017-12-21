using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trivia.Common;
using Trivia.Contracts;

namespace Trivia.Models.Question
{
    public class TimedQuestion : Question
    {
        private readonly int timeForAnswer;

        public TimedQuestion(string questionText, DifficultyLevel difficultyLevel, CategoryType category, int timeForAnswer) 
            : base(questionText, difficultyLevel, category, QuestionType.Timed)
        {
            this.timeForAnswer = timeForAnswer;
            this.Points = (int)DifficultyLevel * 100;
        }
    }
}
