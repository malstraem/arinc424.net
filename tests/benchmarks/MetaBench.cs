using System.Collections.Immutable;

using BenchmarkDotNet.Attributes;

namespace Arinc424.Bench;

[SimpleJob]
public class MetaBench
{
    [Benchmark]
    public ImmutableArray<Type> GrabTypesInfo() => Meta424.Create(Supplement.V23).TypeInfo.Keys;
}
