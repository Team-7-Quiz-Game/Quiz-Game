using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trivia.Common;
using Trivia.Contracts;

namespace Trivia.Models.Question
{
    class BonusQuestion : Question
    {
        public BonusQuestion(string questionText, IList<IAnswer> answers, DifficultyLevel difficultyLevel, CategoryType category, int timeForAnswer)
            : base(questionText, answers, difficultyLevel, category)
        {
        }
    }
}
