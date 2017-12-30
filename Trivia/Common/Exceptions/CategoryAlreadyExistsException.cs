using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trivia.Common.Exceptions
{
    public class CategoryAlreadyExistsException : Exception
    {
        public CategoryAlreadyExistsException()
        {
        }

        public CategoryAlreadyExistsException(string message) : base(message)
        {
        }

        public CategoryAlreadyExistsException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
