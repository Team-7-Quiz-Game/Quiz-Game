using Trivia.Common.Enums;
using Trivia.Common.Utils;

namespace Trivia.Models.Question
{
    public class TimedQuestion : NormalQuestion
    {
        private readonly int timeForAnswer;

        public TimedQuestion(string questionText, DifficultyLevel difficultyLevel, CategoryType category, int timeForAnswer) 
            : base(questionText, difficultyLevel, category, QuestionType.Timed)
        {
            Validator.CheckIntRange(timeForAnswer, GlobalConstants.MinTimeForAnswer, GlobalConstants.MaxTimeForAnswer, string.Format(GlobalConstants.NumberMustBeBetweenMinAndMax, "Time for answer", GlobalConstants.MinTimeForAnswer, GlobalConstants.MaxTimeForAnswer));
            this.timeForAnswer = timeForAnswer;
        }
    }
}
