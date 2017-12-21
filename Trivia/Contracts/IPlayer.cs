using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trivia.Common;

namespace Trivia.Contracts
{
    public interface IPlayer
    {
        string Name { get; }

        PlayerType PlayerType { get; }

        //int Points { get; set; }

        //int WrongAnswers { get; }

        //int CorrectAnswers { get; }

        string ToString();
    }
}
