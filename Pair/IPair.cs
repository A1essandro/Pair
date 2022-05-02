namespace Pair
{

    /// <summary>
    /// Contract for pairs objects.
    /// </summary>
    /// <remarks>
    /// Do not use this interface mixing with <see cref="ValuePair{T}"/> to avoid boxing.
    /// </remarks>
    /// <typeparam name="T"></typeparam>
    public interface IPair<T>
    {

        T Item1 { get; }

        T Item2 { get; }

        T[] Items { get; }

    }

}
