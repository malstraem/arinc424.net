using BenchmarkDotNet.Attributes;

namespace Arinc424.Bench;

[SimpleJob]
public class LoadBench
{
    private readonly string[] strings = File.ReadAllLines("data/unknown");

    private readonly Meta424 meta = Meta424.Create(Supplement.V18);

    [Benchmark]
    public Data424 LoadWorld() => Data424.Create(meta, strings, out var _, out var _);
}
