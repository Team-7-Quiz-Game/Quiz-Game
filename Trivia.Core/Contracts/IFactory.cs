using Trivia.Common.Enums;
using Trivia.Contracts;
using Trivia.Models.Hint;

namespace Trivia.Core.Contracts
{
    public interface IFactory
    {
        IAnswer CreateAnswer(string answerText, bool isCorrect);

        IQuestion CreateBonusQuestion(string questionText, DifficultyLevel difficultyLevel, CategoryType category, int pointsAmplifier);

        IQuestion CreateTimedQuestion(string questionText, DifficultyLevel difficultyLevel, CategoryType category, int timeForAnswer);

        IQuestion CreateNormalQuestion(string questionText, DifficultyLevel difficultyLevel, CategoryType category);

        IPlayer CreateNormalPlayer(string name);

        IPlayer CreateQuizzardPlayer(string name);

        ICategory CreateCategory(CategoryType categoryType);

        Hint CreateSkipQuestionHint(int quantity);

        Hint CreateFiftyFiftyHint(int quantity);
    }
}
