using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trivia.Common;
using Trivia.Contracts;

namespace Trivia.Models.Question
{
    public class BonusQuestion : Question
    {
        private readonly int pointsAmplifier;

        public BonusQuestion(string questionText, DifficultyLevel difficultyLevel, CategoryType category, int pointsAmplifier)
            : base(questionText, difficultyLevel, category, QuestionType.Bonus)
        {
            //guard
            this.pointsAmplifier = pointsAmplifier;
            this.Points = (int)difficultyLevel * 100 * this.pointsAmplifier;
        }
    }
}
