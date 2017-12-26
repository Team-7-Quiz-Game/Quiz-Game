using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trivia.Common;
using Trivia.Contracts;

namespace Trivia.Core.Contracts
{
    public interface IFactory
    {
        IAnswer CreateAnswerstring(string answerText, bool isCorrect);

        IQuestion CreateBonusQuestion(string questionText, DifficultyLevel difficultyLevel, CategoryType category, int pointsAmplifier);

        IQuestion CreateTimedQuestion(string questionText, DifficultyLevel difficultyLevel, CategoryType category, int timeForAnswer);

        IQuestion CreateNormalQuestion(string questionText, DifficultyLevel difficultyLevel, CategoryType category);

        IPlayer CreateNormalPlayer(string name);

        IPlayer CreateQuizzardPlayer(string name);

        ICategory CreateCategory(CategoryType categoryType);
    }
}
