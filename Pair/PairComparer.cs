using System;

namespace Pair
{

    /// <summary>
    /// Encapsulates logic for checking if argument equals by pairs
    /// </summary>
    internal static class PairComparer
    {
    
        public static bool Compare<T>(T pair1item1, T pair1item2, T pair2item1, T pair2item2)
        {
            var pair1nulls = CountNull(pair1item1, pair1item2);
            var pair2nulls = CountNull(pair2item1, pair2item2);

            if (pair1nulls != pair2nulls)
                return false;

            if (pair1nulls == 2)
                return true;

            if (pair1nulls == 1)
                return CheckNotNullValues(pair1item1, pair1item2, pair2item1, pair2item2);

            if (pair1item1.Equals(pair2item1) && pair1item2.Equals(pair2item2))
                return true;

            if (pair1item2.Equals(pair2item1) && pair1item1.Equals(pair2item2))
                return true;

            return false;
        }

        private static bool CheckNotNullValues<T>(T pair1item1, T pair1item2, T pair2item1, T pair2item2)
        {
            var pair1notNullItem = GetNotNullValue(pair1item1, pair1item2);
            var pair2notNullItem = GetNotNullValue(pair2item1, pair2item2);

            return pair1notNullItem.Equals(pair2notNullItem);
        }

        /// <summary>
        /// How meny null contain arguments
        /// </summary>
        /// <returns>0 if both arguments are not null, 1 if one of arguments is null, 2 if both arguments are null</returns>
        private static int CountNull<T>(T item1, T item2)
        {
            var result = item1 == null ? 1 : 0;
            return item2 == null ? ++result : result;
        }

        /// <summary>
        /// Get value from not null value (<paramref name="item1"/> has priority)
        /// </summary>
        /// <returns><see cref="T"/></returns>
        /// <exception cref="ArgumentException">In case if both parameters are null</exception>
        private static T GetNotNullValue<T>(T item1, T item2)
        {
            if (item1 == null && item2 == null)
                throw new ArgumentException("At least one of arguments should not be null");
            return item1 == null ? item2 : item1;
        }

    }

}
