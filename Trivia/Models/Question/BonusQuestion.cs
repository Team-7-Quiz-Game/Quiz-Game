using Trivia.Common.Enums;
using Trivia.Common.Utils;

namespace Trivia.Models.Question
{
    public class BonusQuestion : Question
    {
        private readonly int pointsMultiplier;

        public BonusQuestion(string questionText, DifficultyLevel difficultyLevel, CategoryType category, int pointsMultiplier)
            : base(questionText, difficultyLevel, category, QuestionType.Bonus)
        {
            Validator.CheckIntRange(pointsMultiplier, GlobalConstants.MinPointsMultiplier, GlobalConstants.MaxPointsMultiplier, string.Format(GlobalConstants.NumberMustBeBetweenMinAndMax, "Points' amplifier", GlobalConstants.MinPointsMultiplier, GlobalConstants.MaxPointsMultiplier));

            this.pointsMultiplier = pointsMultiplier;
            this.Points = (int)difficultyLevel * 100 * this.pointsMultiplier;
        }

        public int PointsMultiplier => this.pointsMultiplier;
    }
}
