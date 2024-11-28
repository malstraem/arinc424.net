using System.Reflection;
using System.Runtime.CompilerServices;

using Arinc424.Diagnostics;
using Arinc424.Linking;

namespace Arinc424.Building;

/// <summary>
/// How an entity should be created and processed.
/// </summary>
internal abstract class RecordInfo(Composition composition, SectionAttribute[] sections)
{
    internal static RecordInfo Create<TRecord>(Supplement supplement) where TRecord : Record424, new()
    {
        var type = typeof(TRecord);

        var composition = type.GetComposition(supplement);

        var constructor = typeof(RecordInfo<>)
            .MakeGenericType(composition.Low)
                .GetConstructor([typeof(Supplement), typeof(Composition), typeof(SectionAttribute[])]);

        var secitons = type.GetCustomAttributes<SectionAttribute>(false).ToArray(); // take only top level attributes

        var info = (RecordInfo)constructor!.Invoke([supplement, composition, secitons]);

        return info;
    }

    internal abstract Queue<Build> Build(Queue<string> strings);

    internal Primary? Primary { get; } = Primary.Create(composition.Top);

    internal Composition Composition { get; } = composition;

    internal Relationships? Relations { get; } = composition.Relations.FirstOrDefault(x => x.Type == composition.Top);

    internal SectionAttribute[] Sections { get; } = sections;
}

internal sealed class RecordInfo<TRecord>(Supplement supplement, Composition composition, SectionAttribute[] sections)
    : RecordInfo(composition, sections) where TRecord : Record424, new()
{
    private readonly int? continuationIndex = composition.Top.GetCustomAttributes<ContinuousAttribute>().BySupplement(supplement)?.Index;

    private readonly BuildInfo<TRecord> info = new(supplement);

    internal override Queue<Build> Build(Queue<string> strings)
    {
        Queue<Diagnostic> diagnostics = [];

        Queue<Build<TRecord>> builds = new(strings.Count);

        while (strings.TryDequeue(out string? @string))
        {
            if (continuationIndex is not null && @string[continuationIndex.Value] is not '0' and not '1')
                continue;

            builds.Enqueue(RecordBuilder<TRecord>.Build(@string, info, ref diagnostics));
        }
        return Unsafe.As<Queue<Build>>(builds);
    }
}
