using System.Reflection;

using Arinc424.Diagnostics;
using Arinc424.Linking;
using Arinc424.Processing;

namespace Arinc424.Building;

#pragma warning disable CS8618
internal abstract class RecordInfo
{
    protected Type type;

    protected Primary? primary;

    [Obsolete("todo nullable")]
    protected Relations relations;

    protected SectionAttribute section;
#pragma warning restore CS8618
    protected int? continuationIndex;

    internal abstract IEnumerable<Build> Build(Queue<string> strings);

    internal bool IsMatch(string @string) => section.IsMatch(@string);

    internal bool IsContinuation(string @string) => continuationIndex is not null
                                                 && @string[continuationIndex.Value] is not '0' and not '1';

    internal void Link(IEnumerable<Build> builds, Unique unique, Meta424 meta) => relations.Link(builds, unique, meta);

    internal IEnumerable<RecordInfo> DuplicateBySection()
    {
        List<RecordInfo> duplicates = [];

        foreach (var section in type.GetCustomAttributes<SectionAttribute>(false))
        {
            var duplicate = (RecordInfo)MemberwiseClone();

            duplicate.section = section;

            duplicates.Add(duplicate);
        }
        return duplicates;
    }

    internal Type Type => type;

    internal Primary? Primary => primary;

    internal Relations Relations => relations;

    internal Section Section => section.Section;
}

internal class RecordInfo<TRecord> : RecordInfo where TRecord : Record424, new()
{
    protected readonly BuildInfo<TRecord> info;

    protected readonly IPipeline<TRecord>? pipeline;

    internal RecordInfo(Supplement supplement)
    {
        info = new(supplement);

        var type = typeof(TRecord);

        var pipelineAttribute = type.GetCustomAttribute<PipelineAttribute<TRecord>>();

        if (pipelineAttribute is not null && supplement >= pipelineAttribute.Start && supplement <= pipelineAttribute.End)
            pipeline = pipelineAttribute.GetPipeline(supplement);

        continuationIndex = type.GetCustomAttributes<ContinuousAttribute>().BySupplement(supplement)?.Index;

        this.type = pipelineAttribute is null ? type : pipelineAttribute.NewType;

        primary = Primary.Create(this.type);

        relations = pipelineAttribute is null ? new Relations<TRecord>(supplement) : pipelineAttribute.GetRelations(supplement);
    }

    internal override IEnumerable<Build> Build(Queue<string> strings)
    {
        Queue<Diagnostic> diagnostics = [];

        Queue<Build<TRecord>> builds = new(strings.Count);

        while (strings.TryDequeue(out string? @string))
        {
            var build = new Build<TRecord>(RecordBuilder<TRecord>.Build(@string, info, diagnostics));

            if (diagnostics.Count > 0)
            {
                build.Diagnostics = diagnostics;
                diagnostics = [];
            }
            builds.Enqueue(build);
        }
        return pipeline is not null ? pipeline.Process(builds) : builds;
    }
}
