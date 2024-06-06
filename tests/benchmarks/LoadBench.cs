using BenchmarkDotNet.Attributes;

namespace Arinc424.Bench;

[SimpleJob]
public class LoadBench
{
    private readonly string[] world = File.ReadAllLines("data/case-1");

    [Benchmark]
    public Data424 LoadWorld() => Data424.Create(world);
}
