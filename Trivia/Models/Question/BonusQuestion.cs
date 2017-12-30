using Trivia.Common.Enums;

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
