using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trivia.Contracts;

namespace Trivia.Core.Contracts
{
    public interface IEngine
    {
        void CreateCategory(IList<string> checkedCategories);
    }
}
