using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trivia.Common;

namespace Trivia.Contracts
{
    public interface ICategory
    {
        CategoryType CategoryType { get; }

        void AddQuestion(IQuestion question);
    }
}
