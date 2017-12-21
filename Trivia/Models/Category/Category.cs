using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trivia.Common;
using Trivia.Contracts;

namespace Trivia.Models.Category
{
    public class Category : ICategory
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

        public void AddEasyQuestion(IQuestion question)
        {
            this.easyQuestions.Add(question);
        }

        public void AddNormalQuestion(IQuestion question)
        {
            this.normalQuestions.Add(question);
        }

        public void AddHardQuestion(IQuestion question)
        {
            this.hardQuestions.Add(question);
        }
    }
}
