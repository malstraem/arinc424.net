using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace Arinc424.Bench;

[SimpleJob(RuntimeMoniker.Net90)]
[SimpleJob(RuntimeMoniker.Net80, baseline: true)]
public class LoadBench
{
    private readonly string[] strings = File.ReadAllLines("data/unknown");

    private readonly Meta424 meta = Meta424.Create(Supplement.V18);

    [Benchmark]
    public Data424 LoadWorld() => Data424.Create(meta, strings, out var _, out var _);

    [Benchmark]
    public Meta424 GrabTypesInfo() => Meta424.Create(Supplement.V23);
}
