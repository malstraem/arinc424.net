using System.Reflection;
using System.Runtime.CompilerServices;

namespace Arinc424.Building;

using Linking;
using Processing;

/**<summary>
How an entity (primary record) should be created and processed.
</summary>*/
internal abstract class RecordType(
    Type[] composition,
    Relation[]? relations,
    SectionAttribute[] sections,
    IPipeline[]? pipes
)
    : BaseType(composition, sections, relations)
{
    private static RecordType Create(Type type, Supplement supplement)
    {
        var composition = type.Decompose(supplement, out var relations, out var pipes);

        var continuations = Continuations.Create(composition.First(), composition.Last(), supplement);

        // take only top level section attributes
        var sections = type.GetCustomAttributes<SectionAttribute>(false).ToArray();

        // take only low level composition type
        var constructor = typeof(RecordType<>).MakeGenericType(composition.First()).GetConstructor
        ([
            typeof(Supplement),
            typeof(Type[]),
            typeof(Relation[]),
            typeof(Continuations),
            typeof(SectionAttribute[]),
            typeof(IPipeline[])
        ])!;
        return (RecordType)constructor
            .Invoke([supplement, composition, relations, continuations, sections, pipes]);
    }

    internal static RecordType Create<R>(Supplement supplement)
        where R : Record424
            => Create(typeof(R), supplement);

    internal abstract Queue<Build> Build(Queue<string> strings);

    internal IPipeline[]? Pipes { get; } = pipes;
}

/// <inheritdoc cref="RecordType"/>
internal sealed class RecordType<R>(
    Supplement supplement,
    Type[] composition,
    Relation[]? relations,
    Continuations? continuations,
    SectionAttribute[] sections,
    IPipeline[]? pipes
)
    : RecordType(composition, relations, sections, pipes)
        where R : Record424
{
    private readonly BuildInfo<R> info = new(supplement);

    private readonly Continuations? continuations = continuations;

    internal override Queue<Build> Build(Queue<string> strings)
    {
        Build<R> build;

        Queue<Diagnostic> diagnostics = [];

        Queue<Build<R>> builds = new(strings.Count);

        if (!strings.TryDequeue(out string? @string))
            return Unsafe.As<Queue<Build>>(builds);

        Build();

        while (strings.TryDequeue(out @string))
        {
            if (continuations is not null)
            {
                if (continuations.TryHold(@string))
                    continue;

                continuations.Process(build.Record);
            }
            Build();
        }
        continuations?.Process(build.Record);

        return Unsafe.As<Queue<Build>>(builds);

        void Build()
        {
            build = RecordBuilder<R>.Build(@string, info, ref diagnostics);
            builds.Enqueue(build);
        }
    }
}
