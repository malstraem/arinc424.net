using System.Reflection;

using Arinc424.Attributes;

using BenchmarkDotNet.Attributes;

namespace Arinc424.Bench;

[SimpleJob]
public class MetaBench
{
    [Benchmark]
    public Dictionary<(char, char), Type> Grab()
    {
        Dictionary<(char, char), Type> types = [];
        Dictionary<Type, InfoAttribute> infos = [];

        var records = Assembly.GetAssembly(typeof(Meta424))!.GetCustomAttributes<RecordAttribute>();
        var sequences = Assembly.GetAssembly(typeof(Meta424))!.GetCustomAttributes<SequenceAttribute>();

        foreach (var info in records.Cast<InfoAttribute>().Concat(sequences))
        {
            infos.Add(info.Type, info);
            types.Add((info.Section.SectionChar, info.Section.SubsectionChar), info.Type);
        }
        return types;
    }
}
