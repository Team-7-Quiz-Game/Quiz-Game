using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trivia.Contracts
{
    public interface IAnswer
    {
        string AnswerText { get; }

        bool IsCorrect { get; }

        string ToString();
    }
}
