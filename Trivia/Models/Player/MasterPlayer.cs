using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trivia.Contracts;
using Trivia.Common;

namespace Trivia.Models.Player
{
    public class MasterPlayer : Player
    {
        public MasterPlayer(string name)
            : base(name, PlayerType.QuizzMaster)
        {
        }

        public void CreateQuestion(IQuestion question)
        {

        }

        public void RemoveQuestion(IQuestion question)
        {

        }
    }
}
