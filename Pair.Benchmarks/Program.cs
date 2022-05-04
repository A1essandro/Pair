using BenchmarkDotNet.Running;

namespace Pair.Benchmarks
{
    internal class Program
    {
        static void Main()
        {
            BenchmarkRunner.Run<HashSetWithCollisionsTesting>();
            BenchmarkRunner.Run<HashSetTesting>();
        }
    }

}
