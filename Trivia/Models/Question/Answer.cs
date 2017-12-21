using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trivia.Contracts;

namespace Trivia.Models.Question
{
    public class Answer : IAnswer
    {
        private readonly string answerText;
        private readonly bool isCorrect;

        public Answer(string answerText, bool isCorrect)
        {
            //guard
            this.answerText = answerText;
            this.isCorrect = isCorrect;
        }

        public string AnswerText => this.answerText;

        public bool IsCorrect => this.isCorrect;

        public override string ToString()
        {
            return $"{this.answerText}";
        }
    }
}
