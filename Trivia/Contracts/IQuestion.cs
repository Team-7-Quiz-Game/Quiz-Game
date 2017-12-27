using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trivia.Common;

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
