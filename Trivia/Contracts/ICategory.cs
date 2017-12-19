using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trivia.Contracts
{
    public interface ICategory
    {
        void AddQuestion(IQuestion question);

        void RemoveQuestion(IQuestion question);
    }
}
