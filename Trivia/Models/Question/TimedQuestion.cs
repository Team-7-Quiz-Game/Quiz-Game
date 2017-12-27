using Trivia.Common;

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
