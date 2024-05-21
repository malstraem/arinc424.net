using BenchmarkDotNet.Attributes;

namespace Arinc424.Bench;

[SimpleJob]
public class MetaBench
{
    [Benchmark]
    public Dictionary<(char, char), Type> GrabTypesInfo()
    {
        var meta = new Meta424();

        return meta.Types;
    }
}
