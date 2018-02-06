using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trivia.Contracts;

namespace Trivia.Core.Contracts
{
    public interface IDatabase
    {
        IList<ICategory> Categories { get; }

        IList<IQuestion> GetRandomQuestions(ICategory category, int numOfQuestions);
    }
}
