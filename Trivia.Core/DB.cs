using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trivia.Contracts;

namespace Trivia.Core
{
    public class DB
    {
        private IList<ICategory> categories;

        public DB()
        {
            this.categories = new List<ICategory>();
        }

        public IList<ICategory> Categories { get => this.categories; }
    }
}
