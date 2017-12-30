using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trivia.Common.Enums;

namespace Trivia.Models.Hint
{
    public class SkipQuestionHint : Hint
    {
        public SkipQuestionHint(int quantity) 
            : base(quantity, HintType.SkipQuestion)
        {
            this.Description = "Skips the question but gets the points.";
        }
    }
}
