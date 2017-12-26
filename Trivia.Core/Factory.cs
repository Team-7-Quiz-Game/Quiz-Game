using System.Collections.Generic;
using Trivia.Common;
using Trivia.Contracts;
using Trivia.Core.Contracts;
using Trivia.Models.Category;
using Trivia.Models.Player;
using Trivia.Models.Question;

namespace Trivia.Core
{
    public class Factory : IFactory
    {
        public IAnswer CreateAnswerstring (string answerText, bool isCorrect)
        {
            return new Answer(answerText, isCorrect);
        }

        public IQuestion CreateBonusQuestion(string questionText, DifficultyLevel difficultyLevel, CategoryType category, int pointsAmplifier)
        {
            return new BonusQuestion(questionText, difficultyLevel, category, pointsAmplifier);
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

        public IGame CreateGame(IPlayer firstPlayer, IList<ICategory> categories)
        {
            return new Game(firstPlayer, categories);
        }

        public ICategory CreateCategory(CategoryType categoryType)
        {
            return new Category(categoryType);
        }
    }
}
