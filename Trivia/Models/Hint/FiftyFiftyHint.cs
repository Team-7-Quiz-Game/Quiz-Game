using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trivia.Common.Enums;

namespace Trivia.Models.Hint
{
    public class FiftyFiftyHint : Hint
    {
        public FiftyFiftyHint(int quantity) 
            : base(quantity, HintType.FiftyFifty)
        {
            this.Description = "Removes two wrong answers.";
        }
    }
}
