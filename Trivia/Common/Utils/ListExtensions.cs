using System.Collections.Generic;

namespace Trivia.Common.Utils
{
    public static class ListExtensions
    {
        public static IList<T> Clone<T>(this IList<T> listToClone)
        {
            Validator.CheckIfNull(listToClone, string.Format(GlobalConstants.ObjectCannotBeNull, "List"));

            var cloned = new List<T>();

            foreach (var item in listToClone)
            {
                cloned.Add(item);
            }

            return cloned;
        }
    }
}
