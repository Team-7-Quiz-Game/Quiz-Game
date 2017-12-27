using System.Collections.Generic;
using Trivia.Common;
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
        private static IFactory instanceHolder = new Factory();

        private Factory()
        {
        }

        public static IFactory Instance
        {
            get
            {
                return instanceHolder;
            }
        }

        public IAnswer CreateAnswer (string answerText, bool isCorrect)
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

        public ICategory CreateCategory(CategoryType categoryType)
        {
            return new Category(categoryType);
        }

        public Hint CreateSkipQuestionHint(int quantity)
        {
            return new SkipQuestionHint(quantity);
        }

        public Hint CreateRemoveTwoHint(int quantity)
        {
            return new RemoveTwoHint(quantity);
        }
    }
}
