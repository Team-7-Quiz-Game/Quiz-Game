using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trivia.Common.Enums;
using Trivia.Contracts;
using Trivia.Models.Hint;

namespace Trivia.Core.Contracts
{
    public interface IEngine
    {
        IPlayer Player { get; set; }

        IList<IQuestion> EasyQuestions { get; }

        IList<IQuestion> NormalQuestions { get; }

        IList<IQuestion> HardQuestions { get; }

        IList<IQuestion> QuizzardQuestions { get; }

        Hint FiftyFiftyHint { get; }

        Hint SkipQuestionHint { get; }

        void CreateCategory(IList<string> checkedCategories);

        IPlayer CreateNormalPlayer(string name);

        IPlayer CreateQuizzardPlayer(string name);

        Hint CreateFiftyFiftyHint(int quantity);

        Hint CreateSkipQuestionHint(int quantity);

        IAnswer CreateAnswer(string answerText, bool isCorrect);

        IQuestion CreateNormalQuestion(string questionText, DifficultyLevel difficultyLevel, CategoryType category);

        IQuestion CreateBonusQuestion(string questionText, DifficultyLevel difficultyLevel, CategoryType category, int pointsAmplifier);

        IQuestion CreateTimedQuestion(string questionText, DifficultyLevel difficultyLevel, CategoryType category, int timeForAnswer);

        IList<IQuestion> GetEasyQuestions();

        IList<IQuestion> GetNormalQuestions();

        IList<IQuestion> GetHardQuestions();
    }
}
