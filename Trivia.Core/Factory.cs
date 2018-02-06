using Trivia.Common.Enums;
using Trivia.Contracts;
using Trivia.Core.Contracts;
using Trivia.Models.Category;
using Trivia.Models.Hint;
using Trivia.Models.Player;
using Trivia.Models.Question;

namespace Trivia.Core
{
    public class Factory : IFactory
    {
        public Factory()
        {
        }

        public IAnswer CreateAnswer (string answerText, bool isCorrect)
        {
            return new Answer(answerText, isCorrect);
        }

        public IQuestion CreateBonusQuestion(string questionText, DifficultyLevel difficultyLevel, CategoryType category, int pointsMultiplier)
        {
            return new BonusQuestion(questionText, difficultyLevel, category, pointsMultiplier);
        }

        public IQuestion CreateTimedQuestion(string questionText, DifficultyLevel difficultyLevel, CategoryType category, int timeForAnswer)
        {
            return new TimedQuestion(questionText, difficultyLevel, category, timeForAnswer);
        }

        public IQuestion CreateNormalQuestion(string questionText, DifficultyLevel difficultyLevel, CategoryType category)
        {
            return new NormalQuestion(questionText, difficultyLevel, category);
        }

        public IPlayer CreateNormalPlayer(string name)
        {
            return new NormalPlayer(name);
        }

        public IPlayer CreateQuizzardPlayer(string name)
        {
            return new QuizzardPlayer(name);
        }

        public ICategory CreateCategory(CategoryType categoryType)
        {
            return new Category(categoryType);
        }

        public Hint CreateSkipQuestionHint(int quantity)
        {
            return new SkipQuestionHint(quantity);
        }

        public Hint CreateFiftyFiftyHint(int quantity)
        {
            return new FiftyFiftyHint(quantity);
        }
    }
}
