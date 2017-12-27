using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trivia.Core.Contracts
{
    public interface IEngine
    {
        // TEST
        //void Start();
        void CreateCategory(IList<string> checkedCategories);
    }
}
