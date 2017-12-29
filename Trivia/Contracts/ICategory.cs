using System.Collections.Generic;
using Trivia.Common;

namespace Trivia.Contracts
{
    public interface ICategory
    {
        CategoryType CategoryType { get; }

        IList<IQuestion> EasyQuestions { get; }

        IList<IQuestion> NormalQuestions { get; }

        IList<IQuestion> HardQuestions { get; }

        void AddQuestion(IQuestion question);
    }
}
