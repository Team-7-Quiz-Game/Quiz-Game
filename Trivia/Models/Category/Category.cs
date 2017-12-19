using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trivia.Common;
using Trivia.Contracts;

namespace Trivia.Models.Category
{
    public class Category
    {
        private readonly CategoryType categoryType;
        private IList<IQuestion> easyQuestions;
        private IList<IQuestion> normalQuestions;
        private IList<IQuestion> hardQuestions;
        
        public Category(CategoryType categoryType)
        {
            //Guard
            this.categoryType = categoryType;
            this.easyQuestions = new List<IQuestion>();
            this.normalQuestions = new List<IQuestion>();
            this.hardQuestions = new List<IQuestion>();
        }
        
        public CategoryType CategoryType => this.categoryType;
    }
}
