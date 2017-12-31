using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trivia.Common.Enums;
using Trivia.Contracts;

namespace Trivia.Core.Contracts
{
    public interface IEngine
    {
        IPlayer Player { get ; set; }
        IList<IQuestion> EasyQuestions { get; }
        // TEST
        IList<IQuestion> NormalQuestions { get; }

        void CreateCategory(IList<string> checkedCategories);

        IPlayer CreateNormalPlayer(string name);

        IPlayer CreateQuizzardPlayer(string name);

        IAnswer CreateAnswer(string answerText, bool isCorrect);

        IQuestion CreateNormalQuestion(string questionText, DifficultyLevel difficultyLevel, CategoryType category);

        IQuestion CreateBonusQuestion(string questionText, DifficultyLevel difficultyLevel, CategoryType category, int pointsAmplifier);

        IQuestion CreateTimedQuestion(string questionText, DifficultyLevel difficultyLevel, CategoryType category, int timeForAnswer);
        IList<IQuestion> GetEasyQuestions(IDictionary<string, ICategory> categories);
        // TEST
        IList<IQuestion> GetNormalQuestions(IDictionary<string, ICategory> categories);
    }
}
