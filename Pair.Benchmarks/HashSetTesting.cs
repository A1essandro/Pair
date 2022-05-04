using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pair.Benchmarks
{

    [MarkdownExporterAttribute.GitHub]
    [MemoryDiagnoser]
    public class HashSetTesting
    {

        [Params(1000, 1000_000)]
        public int N;

        [Benchmark(Description = "Pair<int>")]
        public HashSet<Pair<int>> ReferenceHashSet()
        {
            var hashSet = new HashSet<Pair<int>>();
            foreach (var i in Enumerable.Range(0, N))
            {
                hashSet.Add(new Pair<int>(i, i * i));
            }

            return hashSet;
        }

        [Benchmark(Description = "ValuePair<int>")]
        public HashSet<ValuePair<int>> ValueHashSet()
        {
            var hashSet = new HashSet<ValuePair<int>>();
            foreach (var i in Enumerable.Range(0, N))
            {
                hashSet.Add(new ValuePair<int>(i, i * i));
            }

            return hashSet;
        }

        [Benchmark(Description = "ValuePair<int> via IPair<int>")]
        public HashSet<IPair<int>> ValueViaInterfaceHashSet()
        {
            var hashSet = new HashSet<IPair<int>>();
            foreach (var i in Enumerable.Range(0, N))
            {
                hashSet.Add(new ValuePair<int>(i, i * i));
            }

            return hashSet;
        }

        [Benchmark(Description = "ValueTuple<int>", Baseline = true)]
        public HashSet<ValueTuple<int, int>> DoubleHashSet()
        {
            var hashSet = new HashSet<ValueTuple<int, int>>();
            foreach (var i in Enumerable.Range(0, N))
            {
                hashSet.Add(new ValueTuple<int, int>(i * i, i));
            }

            return hashSet;
        }

    }

}
