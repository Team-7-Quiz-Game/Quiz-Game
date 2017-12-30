using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trivia.Common.Exceptions
{
    public class CategoryDoesNotExistException : Exception
    {
        public CategoryDoesNotExistException()
        {
        }

        public CategoryDoesNotExistException(string message) : base(message)
        {
        }

        public CategoryDoesNotExistException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
