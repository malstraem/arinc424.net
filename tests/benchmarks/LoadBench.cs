using BenchmarkDotNet.Attributes;

namespace Arinc424.Bench;

[SimpleJob]
public class LoadBench
{
    private readonly string[] data = File.ReadAllLines("data/unknown");

    [Benchmark]
    public Data424 LoadWorld() => Data424.Create(data, Supplement.V18);
}
