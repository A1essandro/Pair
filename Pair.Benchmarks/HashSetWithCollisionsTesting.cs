using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pair.Benchmarks
{
    [MarkdownExporterAttribute.GitHub]
    [MemoryDiagnoser]
    public class HashSetWithCollisionsTesting
    {

        [Params(1000, 1000_000)]
        public int N;

        [Benchmark(Description = "Pair<int> with collisions")]
        public HashSet<Pair<int>> ReferenceHashSetWithCollisions()
        {
            var hashSet = new HashSet<Pair<int>>();
            foreach (var i in Enumerable.Range(0, N))
            {
                hashSet.Add(new Pair<int>(i % 10, i * i % 10));
            }

            return hashSet;
        }

        [Benchmark(Description = "ValuePair<int> with collisions")]
        public HashSet<ValuePair<int>> ValueHashSetWithCollisions()
        {
            var hashSet = new HashSet<ValuePair<int>>();
            foreach (var i in Enumerable.Range(0, N))
            {
                hashSet.Add(new ValuePair<int>(i % 10, i * i % 10));
            }

            return hashSet;
        }

        [Benchmark(Description = "ValuePair<int> via IPair<int> with collisions")]
        public HashSet<IPair<int>> ValueViaInterfaceHashSetWithCollisions()
        {
            var hashSet = new HashSet<IPair<int>>();
            foreach (var i in Enumerable.Range(0, N))
            {
                hashSet.Add(new ValuePair<int>(i, i * i % 10));
            }

            return hashSet;
        }

        [Benchmark(Description = "ValueTuple<int> with collisions", Baseline = true)]
        public HashSet<ValueTuple<int, int>> DoubleHashSetWithCollision()
        {
            var hashSet = new HashSet<ValueTuple<int, int>>();
            foreach (var i in Enumerable.Range(0, N))
            {
                hashSet.Add(new ValueTuple<int, int>(i, i * i % 10));
            }

            return hashSet;
        }

    }

}
