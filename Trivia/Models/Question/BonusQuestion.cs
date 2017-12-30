using Trivia.Common.Enums;
using Trivia.Common.Utils;

namespace Trivia.Models.Question
{
    public class BonusQuestion : Question
    {
        private readonly int pointsAmplifier;

        public BonusQuestion(string questionText, DifficultyLevel difficultyLevel, CategoryType category, int pointsAmplifier)
            : base(questionText, difficultyLevel, category, QuestionType.Bonus)
        {
            Validator.CheckIntRange(pointsAmplifier, GlobalConstants.MinPointsAmplifier, GlobalConstants.MaxPointsAmplifier, string.Format(GlobalConstants.NumberMustBeBetweenMinAndMax, "Points' amplifier", GlobalConstants.MinPointsAmplifier, GlobalConstants.MaxPointsAmplifier));

            this.pointsAmplifier = pointsAmplifier;
            this.Points = (int)difficultyLevel * 100 * this.pointsAmplifier;
        }

        public int PointsAmplifier => this.pointsAmplifier;
    }
}
