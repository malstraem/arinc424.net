using BenchmarkDotNet.Attributes;

namespace Arinc.Spec424.Bench;

public class LoadBench
{
    private readonly string[] strings = File.ReadAllLines("data/world.txt");

    [Benchmark]
    public Data424 Load() => Data424.Load(strings);
}
