using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trivia.Models.Hint
{
    public class RemoveTwoHint : Hint
    {
        public RemoveTwoHint(string name, string description, int quantity) 
            : base(name, description, quantity)
        {
        }
    }
}
