using System.Reflection;
using System.Runtime.CompilerServices;

namespace Arinc424.Building;

using Linking;
using Diagnostics;
using Processing;

/**<summary>
How an entity (primary record) should be created and processed.
</summary>*/
internal abstract class RecordInfo
(
    Type[] composition,
    Relation[]? relations,
    SectionAttribute[] sections,
    IPipeline[]? pipes
)
    : BaseInfo(composition, sections, relations)
{
    private static RecordInfo Create(Type type, Supplement supplement)
    {
        var composition = type.Decompose(supplement, out var relations, out var pipes);

        var continuations = Continuations.Create(composition.First(), composition.Last(), supplement);

        // take only top level section attributes
        var sections = type.GetCustomAttributes<SectionAttribute>(false).ToArray();

        // take only low level composition type
        var constructor = typeof(RecordInfo<>).MakeGenericType(composition.First()).GetConstructor
        ([
            typeof(Supplement),
            typeof(Type[]),
            typeof(Relation[]),
            typeof(Continuations),
            typeof(SectionAttribute[]),
            typeof(IPipeline[])
        ])!;
        return (RecordInfo)constructor.Invoke([supplement, composition, relations, continuations, sections, pipes]);
    }

    internal static RecordInfo Create<TRecord>(Supplement supplement) where TRecord : Record424, new()
        => Create(typeof(TRecord), supplement);

    internal abstract Queue<Build> Build(Queue<string> strings);

    internal IPipeline[]? Pipes { get; } = pipes;
}

internal sealed class RecordInfo<TRecord>
(
    Supplement supplement,
    Type[] composition,
    Relation[]? relations,
    Continuations? continuations,
    SectionAttribute[] sections,
    IPipeline[]? pipes
)
    : RecordInfo(composition, relations, sections, pipes)
        where TRecord : Record424, new()
{
    private readonly BuildInfo<TRecord> info = new(supplement);

    private readonly Continuations? continuations = continuations;

    internal override Queue<Build> Build(Queue<string> strings)
    {
        Build<TRecord> build;

        Queue<Diagnostic> diagnostics = [];

        Queue<Build<TRecord>> builds = new(strings.Count);

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
