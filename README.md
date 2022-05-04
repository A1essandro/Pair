# Pair

## Usage

### Types

You can use `ValuePair<T>` which is value type (struct), Pair<T> which is reference type (class). These types implement interface `IPair<T>` but it is better to not mix value type with interface to avoid boxing/unboxing (see benchmarks). `ValuePair<T>` is immutable.

### Examples

```cs

var pair = new ValuePair<int>(1, int.MaxValue);
var item1 = pair.Item1; //1
var item2 = pair.Item2 //22147483647
var items = pair.Items; //array [1, 2147483647]

new ValuePair<int>(1, 1) == new ValuePair<int>(1, 1); //true
new ValuePair<int>(1, 2) == new ValuePair<int>(2, 1); //true
new ValuePair<int?>(1, null) == new ValuePair<int>(null, 1); //true
new ValuePair<object>(null, null) == new ValuePair<int>(null, null); //true
new Pair<int?>(1, 2) == new ValuePair<int?>(2, 1); //true

new ValuePair<int>(1, 1) == new ValuePair<int>(1, 2); //false
```

## Benchmarks

Adding to `HashSet<THashSetTypeParameter>`:

|                          THashSetTypeParameter |       N |          Mean |        Error |        StdDev |        Median | Ratio | RatioSD |     Gen 0 |     Gen 1 |    Gen 2 | Allocated |
|-------------------------------- |-------- |--------------:|-------------:|--------------:|--------------:|------:|--------:|----------:|----------:|---------:|----------:|
|                       **Pair&lt;int&gt;** |    **1000** |      **66.75 μs** |     **1.319 μs** |      **2.542 μs** |      **66.42 μs** |  **1.20** |    **0.06** |   **23.0713** |    **0.4883** |        **-** |     **95 KB** |
|                  ValuePair&lt;int&gt; |    1000 |      59.70 μs |     1.124 μs |      1.294 μs |      60.09 μs |  1.07 |    0.03 |   17.3950 |    0.0610 |        - |     71 KB |
| ValuePair&lt;int&gt; as IPair&lt;int&gt; |    1000 |      65.36 μs |     1.297 μs |      2.649 μs |      65.32 μs |  1.15 |    0.05 |   23.0713 |    0.4883 |        - |     95 KB |
|                 ValueTuple&lt;int&gt; |    1000 |      55.78 μs |     1.094 μs |      1.075 μs |      55.74 μs |  1.00 |    0.00 |   17.3950 |    0.0610 |        - |     71 KB |
|                                 |         |               |              |               |               |       |         |           |           |          |           |
|                       **Pair&lt;int&gt;** | **1000000** | **233,637.37 μs** | **5,579.670 μs** | **16,364.205 μs** | **231,855.60 μs** |  **1.45** |    **0.10** | **4000.0000** | **1000.0000** |        **-** | **76,063 KB** |
|                  ValuePair&lt;int&gt; | 1000000 | 163,021.92 μs | 2,209.812 μs |  1,845.293 μs | 163,181.20 μs |  1.01 |    0.04 |  500.0000 |  500.0000 | 500.0000 | 52,626 KB |
| ValuePair&lt;int&gt; as IPair&lt;int&gt; | 1000000 | 239,149.82 μs | 5,708.578 μs | 16,742.270 μs | 234,666.10 μs |  1.50 |    0.08 | 4000.0000 | 1000.0000 |        - | 76,063 KB |
|                 ValueTuple&lt;int&gt; | 1000000 | 161,224.74 μs | 3,169.921 μs |  4,840.805 μs | 160,725.38 μs |  1.00 |    0.00 |  500.0000 |  500.0000 | 500.0000 | 52,626 KB |


Adding to `HashSet<THashSetTypeParameter>` with collisions:


|                                          THashSetTypeParameter |       N |          Mean |        Error |        StdDev | Ratio | RatioSD |      Gen 0 |     Gen 1 |    Gen 2 |  Allocated |
|------------------------------------------------ |-------- |--------------:|-------------:|--------------:|------:|--------:|-----------:|----------:|---------:|-----------:|
|                     **Pair&lt;int&gt;** |    **1000** |      **86.82 μs** |     **1.709 μs** |      **3.530 μs** |  **1.48** |    **0.07** |    **24.1699** |         **-** |        **-** |      **99 KB** |
|                ValuePair&lt;int&gt; |    1000 |      68.82 μs |     1.314 μs |      1.461 μs |  1.18 |    0.03 |    18.4326 |         - |        - |      75 KB |
| ValuePair&lt;int&gt; as IPair&lt;int&gt; |    1000 |     128.16 μs |     2.554 μs |      7.286 μs |  2.13 |    0.12 |    37.8418 |   12.4512 |        - |     156 KB |
|               ValueTuple&lt;int&gt; |    1000 |      58.37 μs |     1.153 μs |      1.133 μs |  1.00 |    0.00 |    17.3950 |    0.0610 |        - |      71 KB |
|                                                 |         |               |              |               |       |         |            |           |          |            |
|                     **Pair&lt;int&gt;** | **1000000** | **161,600.93 μs** | **3,159.193 μs** |  **5,933.731 μs** |  **1.36** |    **0.07** | **48000.0000** |         **-** |        **-** | **196,608 KB** |
|                ValuePair&lt;int&gt; | 1000000 | 121,828.83 μs | 2,419.528 μs |  4,775.912 μs |  1.03 |    0.06 | 42250.0000 |         - |        - | 173,170 KB |
| ValuePair&lt;int&gt; as IPair&lt;int&gt; | 1000000 | 427,630.99 μs | 8,536.971 μs | 23,225.458 μs |  3.64 |    0.22 | 14000.0000 | 4000.0000 |        - | 137,041 KB |
|               ValueTuple&lt;int&gt; | 1000000 | 118,349.27 μs | 2,342.051 μs |  3,976.980 μs |  1.00 |    0.00 |   800.0000 |  800.0000 | 800.0000 |  52,626 KB |
