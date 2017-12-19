using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trivia.Common;

namespace Trivia.Models.Player
{
    public class NormalPlayer : Player
    {
        public NormalPlayer(string name) 
            : base(name, PlayerType.Normal)
        {
        }
    }
}
