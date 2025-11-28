using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace Arinc424.Bench;

[SimpleJob(RuntimeMoniker.Net10_0)]
public class CreateBench
{
    private readonly string[] strings = File.ReadAllLines($"{Cases}worldwide");

    private readonly Meta424 meta = Meta424.Create(Supplement.V18);

    [Benchmark(Description = "Create (worldwide data 100 mb)")]
    public Data424 Create() => Data424.Create(meta, strings, out string[] _, out var _);

    [Benchmark(Description = "Compile metadata")]
    public Meta424 CreateMeta() => Meta424.Create(Supplement.V23);
}
