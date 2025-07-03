using System.Reflection;
using System.Runtime.CompilerServices;

using Arinc424.Diagnostics;
using Arinc424.Linking;

namespace Arinc424.Building;

/**<summary>
How an entity (primary record) should be created and processed.
</summary>*/
internal abstract class RecordInfo(Composition composition, SectionAttribute[] sections)
{
    internal static RecordInfo Create(Type type, Supplement supplement)
    {
        var composition = type.GetComposition(supplement);

        var continuations = Continuations.Create(composition, supplement);

        // take only low level composition type
        var constructor = typeof(RecordInfo<>)
            .MakeGenericType(composition.Low)
                .GetConstructor([typeof(Supplement), typeof(Composition), typeof(Continuations), typeof(SectionAttribute[])])!;

        var sections = type.GetCustomAttributes<SectionAttribute>(false).ToArray(); // take only top level attributes

        return (RecordInfo)constructor.Invoke([supplement, composition, continuations, sections]);
    }

    internal static RecordInfo Create<TRecord>(Supplement supplement) where TRecord : Record424, new() => Create(typeof(TRecord), supplement);

    internal abstract Queue<Build> Build(Queue<string> strings);

    internal Primary? Primary { get; } = Primary.Create(composition.Top);

    internal Composition Composition { get; } = composition;

    internal Relationships? Relations { get; } = composition.Relations.FirstOrDefault(x => x.Type == composition.Top);

    internal SectionAttribute[] Sections { get; } = sections;
}

internal sealed class RecordInfo<TRecord>(Supplement supplement, Composition composition, Continuations? continuations, SectionAttribute[] sections)
    : RecordInfo(composition, sections) where TRecord : Record424, new()
{
    private readonly BuildInfo<TRecord> info = new(supplement);

    private readonly Continuations? continuations = continuations;

    internal override Queue<Build> Build(Queue<string> strings)
    {
        Queue<Diagnostic> diagnostics = [];

        Queue<Build<TRecord>> builds = new(strings.Count);

        Build<TRecord> build;

        if (strings.TryDequeue(out string? @string))
        {
            Build(@string);
        }
        else
        {
            return Unsafe.As<Queue<Build>>(builds);
        }

        while (strings.TryDequeue(out @string))
        {
            if (continuations is null || !continuations.TryHold(@string))
            {
                Build(@string);
                continue;
            }
            continuations.Process(build.Record);
        }
        return Unsafe.As<Queue<Build>>(builds);

        void Build(string @string)
        {
            build = RecordBuilder<TRecord>.Build(@string, info, ref diagnostics);
            builds.Enqueue(build);
        }
    }
}
