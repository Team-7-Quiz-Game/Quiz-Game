using System.Collections.Generic;
using Trivia.Common.Enums;

namespace Trivia.Contracts
{
    public interface IQuestion
    {
        string QuestionText { get; }

        DifficultyLevel DifficultyLevel { get; }

        CategoryType CategoryType { get; }

        IList<IAnswer> Answers { get; }

        int Points { get; }

        int Id { get; }

        void AddAnswer(IAnswer answer);

        QuestionType QuestionType { get; }

        IQuestion AddAnswerFluent(IAnswer answer);

        void ShuffleAnswers();

        string ToString();
    }
}
