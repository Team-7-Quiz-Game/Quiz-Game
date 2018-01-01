using System;

namespace Trivia.Common.Exceptions
{
    public class QuestionAlreadyAddedException : Exception
    {
        public QuestionAlreadyAddedException()
        {
        }

        public QuestionAlreadyAddedException(string message) : base(message)
        {
        }

        public QuestionAlreadyAddedException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
