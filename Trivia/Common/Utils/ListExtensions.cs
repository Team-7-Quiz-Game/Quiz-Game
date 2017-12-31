using System;
using System.Collections.Generic;

namespace Trivia.Common.Utils
{
    public static class ListExtensions
    {
        private static Random rng = new Random();

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

        // Fisher-Yates shuffle
        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
