using System.Reflection;
using System.Runtime.CompilerServices;

using Arinc424.Diagnostics;
using Arinc424.Linking;
using Arinc424.Processing;

namespace Arinc424.Building;

/// <summary>
/// Info about how an entity should be created and processed.
/// </summary>
internal abstract class RecordInfo
{
#pragma warning disable CS8618
    protected Type type;

    protected Primary? primary;

    protected Relationships? relations;

    protected SectionAttribute section;

    protected IPipeline[] pipelines;

    protected int? continuationIndex;
#pragma warning restore CS8618
    [Obsolete("todo")]
    internal static RecordInfo Create<TRecord>(Supplement supplement) where TRecord : Record424, new()
    {
        var type = typeof(TRecord).Untie();

        var constructor = typeof(RecordInfo<>)
            .MakeGenericType(type)
                .GetConstructor([typeof(Supplement)]);

        var info = (RecordInfo)constructor!.Invoke([supplement]);

        info.type = typeof(TRecord);

        List<IPipeline> pipes = [];

        foreach (var pipe in info.type.GetCustomAttributes<PipelineAttribute>())
        {
            if (supplement >= pipe.Start && supplement <= pipe.End)
                pipes.Add(pipe.GetPipeline(supplement));
        }
        info.pipelines = [.. pipes];
        info.continuationIndex = info.type.GetCustomAttributes<ContinuousAttribute>().BySupplement(supplement)?.Index;

        info.primary = Primary.Create(info.type);

        info.relations = Relationships<TRecord>.Create(supplement);

        return info;
    }

    internal abstract Queue<Build> Build(Queue<string> strings);

    internal bool IsMatch(string @string) => section.IsMatch(@string);

    internal bool IsContinuation(string @string) => continuationIndex is not null
                                                 && @string[continuationIndex.Value] is not '0' and not '1';

    internal void Link(IEnumerable<Build> builds, Unique unique, Meta424 meta) => relations?.Link(builds, unique, meta);

    internal IEnumerable<RecordInfo> DuplicateBySection()
    {
        List<RecordInfo> duplicates = [];

        foreach (var section in type.GetCustomAttributes<SectionAttribute>(false)) // take only top level attributes
        {
            var duplicate = (RecordInfo)MemberwiseClone();

            duplicate.section = section;

            duplicates.Add(duplicate);
        }
        return duplicates;
    }

    internal Type Type => type;

    internal Primary? Primary => primary;

    internal Relationships? Relations => relations;

    internal IPipeline[] Pipelines => pipelines;

    internal Section Section => section.Section;
}

internal sealed class RecordInfo<TRecord>(Supplement supplement) : RecordInfo where TRecord : Record424, new()
{
    private readonly BuildInfo<TRecord> info = new(supplement);

    internal override Queue<Build> Build(Queue<string> strings)
    {
        Queue<Diagnostic> diagnostics = [];

        Queue<Build<TRecord>> builds = new(strings.Count);

        while (strings.TryDequeue(out string? @string))
        {
            var build = new Build<TRecord>(RecordBuilder<TRecord>.Build(@string, info, diagnostics));

            if (diagnostics.Count != 0)
            {
                build.Diagnostics = diagnostics;
                diagnostics = [];
            }
            builds.Enqueue(build);
        }
        return Unsafe.As<Queue<Build>>(builds);
    }
}
