using System;
using System.Linq.Expressions;

namespace Trivia.Common.Utils
{
    public static class Validator
    {
        public static void CheckIfNull(object obj, string message = null)
        {
            if (obj == null)
            {
                throw new NullReferenceException(message);
            }
        }

        public static void CheckIfStringIsNullOrEmpty(string text, string message = null)
        {
            if (string.IsNullOrEmpty(text))
            {
                throw new NullReferenceException(message);
            }
        }

        // This way we cannot know which element of the array throws = Bad. (works for now, fix later)
        public static void CheckIfStringCollectionHasNullOrEmpty(string[] array, string message = null)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (string.IsNullOrEmpty(array[i]))
                {
                    throw new NullReferenceException(message);
                }
            }
        }

        public static void CheckIfStringLengthIsValid(string text, int max, int min = 0, string message = null)
        {
            if (text.Length < min || max < text.Length)
            {
                throw new IndexOutOfRangeException(message);
            }
        }

        public static void CheckIntRange(int value, int min, int max, string message = null)
        {
            if (value < min || value > max)
            {
                throw new IndexOutOfRangeException(message);
            }
        }

        public static void CheckIntAboveMax(int value, int max, string message = null)
        {
            if (value > max)
            {
                throw new IndexOutOfRangeException(message);
            }
        }

        public static void CheckIfIntNegative(int value, string message = null)
        {
            if (value < 0)
            {
                throw new IndexOutOfRangeException(message);
            }
        }

        private static string GetMemberName<T>(Expression<Func<T>> memberExpression)
        {
            MemberExpression expressionBody = (MemberExpression)memberExpression.Body;
            return expressionBody.Member.Name;
        }
    }
}
