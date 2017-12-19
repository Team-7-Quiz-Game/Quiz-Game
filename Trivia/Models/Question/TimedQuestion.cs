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
        public TimedQuestion(string questionText, IList<IAnswer> answers, int points, DifficultyLevel difficultyLevel, CategoryType category, int timeForAnswer) 
            : base(questionText, answers, points, difficultyLevel, category)
        {
        }
    }
}
