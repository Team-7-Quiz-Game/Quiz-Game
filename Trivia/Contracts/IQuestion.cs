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

        void AddAnswer(IAnswer answer);

        string ToString();
    }
}
