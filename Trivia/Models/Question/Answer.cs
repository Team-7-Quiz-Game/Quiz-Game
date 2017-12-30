using Trivia.Common.Utils;
using Trivia.Contracts;

namespace Trivia.Models.Question
{
    public class Answer : IAnswer
    {
        private readonly string answerText;
        private readonly bool isCorrect;

        public Answer(string answerText, bool isCorrect)
        {
            Validator.CheckIfStringIsNullOrEmpty(answerText, string.Format(GlobalConstants.StringCannotBeNullOrEmpty, "Answer text"));

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
