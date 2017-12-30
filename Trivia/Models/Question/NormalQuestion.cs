using Trivia.Common.Enums;

namespace Trivia.Models.Question
{
    public class NormalQuestion : Question
    {
        public NormalQuestion(string questionText, DifficultyLevel difficultyLevel, CategoryType category) 
            : base(questionText, difficultyLevel, category, QuestionType.Normal)
        {
            this.Points = (int)DifficultyLevel * 100;
        }
    }
}
