using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trivia.Common;

namespace Trivia.Models.Hint
{
    public class RemoveTwoHint : Hint
    {
        public RemoveTwoHint(int quantity) 
            : base(quantity, HintType.RemoveTwo)
        {
            this.Description = "Removes two wrong answers.";
        }
    }
}
