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

    protected Relationships? relations;

    protected SectionAttribute section;
#pragma warning restore CS8618
    protected int? continuationIndex;

    internal abstract IEnumerable<Build> Build(Queue<string> strings);

    internal bool IsMatch(string @string) => section.IsMatch(@string);

    internal bool IsContinuation(string @string) => continuationIndex is not null
                                                 && @string[continuationIndex.Value] is not '0' and not '1';

    internal void Link(IEnumerable<Build> builds, Unique unique, Meta424 meta) => relations?.Link(builds, unique, meta);

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

    internal Relationships? Relations => relations;

    internal Section Section => section.Section;
}

internal class RecordInfo<TRecord> : RecordInfo where TRecord : Record424, new()
{
    protected readonly BuildInfo<TRecord> info;

    protected readonly IPipeline<TRecord>? pipeline;

    internal RecordInfo(Supplement supplement)
    {
        info = new(supplement);

        type = typeof(TRecord);

        var pipe = type.GetCustomAttribute<PipelineAttribute<TRecord>>();

        if (pipe is not null && supplement >= pipe.Start && supplement <= pipe.End)
            pipeline = pipe.GetPipeline(supplement);

        continuationIndex = type.GetCustomAttributes<ContinuousAttribute>().BySupplement(supplement)?.Index;

        type = pipe is null ? type : pipe.OutType;

        primary = Primary.Create(type);

        relations = pipe is null ? Relationships<TRecord>.Create(supplement) : Relationships.Create(pipe.OutType, supplement);
    }

    internal override IEnumerable<Build> Build(Queue<string> strings)
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
        return pipeline is not null ? pipeline.Process(builds) : builds;
    }
}
