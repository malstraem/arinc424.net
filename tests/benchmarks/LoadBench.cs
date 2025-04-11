using BenchmarkDotNet.Attributes;

namespace Arinc424.Bench;

[InProcess]
public class LoadBench
{
    private readonly string[] strings = File.ReadAllLines("data/unknown");

    private readonly Meta424 meta = Meta424.Create(Supplement.V18);

    [Benchmark(Description = "Create (unknown data 100 mb)")]
    public Data424 Create() => Data424.Create(meta, strings, out var _, out var _);

    [Benchmark(Description = "Compile metadata")]
    public Meta424 CreateMeta() => Meta424.Create(Supplement.V23);
}
