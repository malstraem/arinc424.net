using System.Collections.Immutable;

using BenchmarkDotNet.Attributes;

namespace Arinc424.Bench;

[SimpleJob]
public class MetaBench
{
    [Benchmark]
    public ImmutableArray<Type> GrabTypesInfo()
    {
        var meta = new Meta424();

        return meta.Types.Values;
    }
}
