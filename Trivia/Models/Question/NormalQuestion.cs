using Trivia.Common.Enums;

namespace Trivia.Models.Question
{
    public class NormalQuestion : Question
    {
        public NormalQuestion(string questionText, DifficultyLevel difficultyLevel, CategoryType category, QuestionType type = QuestionType.Normal) 
            : base(questionText, difficultyLevel, category, type)
        {
            this.Points = (int)DifficultyLevel * 100;
        }
    }
}
