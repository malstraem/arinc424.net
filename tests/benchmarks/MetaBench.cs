using System.Collections.Immutable;

using BenchmarkDotNet.Attributes;

namespace Arinc424.Bench;

[SimpleJob]
public class MetaBench
{
    [Benchmark]
    public ImmutableArray<Type> GrabTypesInfo() => new Meta424(Supplement.V23).TypeInfo.Keys;
}
