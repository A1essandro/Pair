using System;

namespace Pair
{

    /// <summary>
    /// Readonly struct implements <see cref="IPair{T}"/>.
    /// Instances of <see cref="ValuePair{T}"/> are equal if have same pair of <see cref="T"/> instances in any order.
    /// </summary>
    /// <remarks>
    /// Equality of <see cref="T"/> instances are checking via <see cref="T.Equals(object)"/> method. <br/>
    /// Do not use <see cref="IPair{T}"/> mixing with <see cref="ValuePair{T}"/> to avoid boxing.
    /// </remarks>
    /// <typeparam name="T"></typeparam>
    public readonly struct ValuePair<T> : IPair<T>, IEquatable<ValuePair<T>>, IEquatable<IPair<T>>
    {

        public T Item1 { get; }

        public T Item2 { get; }

        public T[] Items => new[] { Item1, Item2 };

        public ValuePair(T item1, T item2)
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

        public bool Equals(ValuePair<T> other) => PairComparer.Compare(Item1, Item2, other.Item1, other.Item2);

        public bool Equals(IPair<T> other)
        {
            if (other == null)
                return false;

            return PairComparer.Compare(Item1, Item2, other.Item1, other.Item2);
        }

        public static bool operator ==(ValuePair<T> p1, ValuePair<T> p2)
        {
            return p1.Equals(p2);
        }

        public static bool operator !=(ValuePair<T> p1, ValuePair<T> p2)
        {
            return !p1.Equals(p2);
        }

        #endregion

    }

}
