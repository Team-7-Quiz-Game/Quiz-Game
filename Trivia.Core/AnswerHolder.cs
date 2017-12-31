using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trivia.Common.Utils;

namespace Trivia.Core
{
    public struct AnswerHolder
    {
        public string text;
        public bool isCorrect;

        public AnswerHolder(string text, bool isCorrect)
        {
            this.text = text;
            this.isCorrect = isCorrect;
        }
    }
}
