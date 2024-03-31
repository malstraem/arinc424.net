using BenchmarkDotNet.Attributes;

namespace Arinc.Spec424.Bench;

public class LoadBench
{
    private readonly string[] ru = File.ReadAllLines("data/ru.txt");

    private readonly string[] world = File.ReadAllLines("data/world.txt");

    [Benchmark]

    public Data424 LoadRu() => Data424.Load(ru);

    [Benchmark]
    public Data424 LoadWorld() => Data424.Load(world);
}
