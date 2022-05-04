using System;

namespace Pair
{

    /// <summary>
    /// Class implements <see cref="IPair{T}"/>.
    /// Instances of <see cref="Pair{T}"/> are equal if have same pair of <see cref="T"/> instances in any order.
    /// </summary>
    /// <remarks>
    /// Equality of <see cref="T"/> instances are checking via <see cref="T.Equals(object)"/> method.
    /// </remarks>
    /// <typeparam name="T"></typeparam>
    public class Pair<T> : IPair<T>, IEquatable<Pair<T>>, IEquatable<IPair<T>>
    {

        public T Item1 { get; set; }

        public T Item2 { get; set; }

        public T[] Items => new[] { Item1, Item2 };

        public Pair(T item1, T item2)
        {
            Item1 = item1;
            Item2 = item2;
        }

        public override int GetHashCode()
        {
            var hashCode1 = Item1?.GetHashCode() ?? int.MinValue;
            var hashCode2 = Item2?.GetHashCode() ?? int.MinValue;

            return 17 ^ (29 * hashCode1 + 29 * hashCode2);
        }

        #region Equals

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is IPair<T>))
                return false;

            return Equals((IPair<T>)obj);
        }

        public bool Equals(Pair<T> other) => Equals(other as IPair<T>);

        public bool Equals(IPair<T> other)
        {
            if (other == null)
                return false;

            return PairComparer.Compare(Item1, Item2, other.Item1, other.Item2);
        }

        public static bool operator ==(Pair<T> p1, Pair<T> p2) => p1.Equals(p2);

        public static bool operator !=(Pair<T> p1, Pair<T> p2) => !p1.Equals(p2);

        public static bool operator ==(IPair<T> p1, Pair<T> p2) => p1.Equals(p2);

        public static bool operator !=(IPair<T> p1, Pair<T> p2) => !p1.Equals(p2);

        public static bool operator ==(Pair<T> p1, IPair<T> p2) => p1.Equals(p2);

        public static bool operator !=(Pair<T> p1, IPair<T> p2) => !p1.Equals(p2);

        #endregion

    }

}
