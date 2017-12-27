using Trivia.Common;

namespace Trivia.Contracts
{
    public interface ICategory
    {
        CategoryType CategoryType { get; }

        void AddQuestion(IQuestion question);
    }
}
