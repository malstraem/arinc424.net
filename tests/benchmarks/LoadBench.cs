using BenchmarkDotNet.Attributes;

namespace Arinc424.Bench;

[SimpleJob]
public class LoadBench
{
    private readonly string[] world = File.ReadAllLines("data/unknown");

    [Benchmark]
    public Data424 LoadWorld() => Data424.Create(world);
}
