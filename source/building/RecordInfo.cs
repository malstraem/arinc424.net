using System.Reflection;

using Arinc424.Diagnostics;
using Arinc424.Linking;

namespace Arinc424.Building;

#pragma warning disable CS8618
internal abstract class RecordInfo
#pragma warning restore CS8618
{
    protected Type type;

    protected Primary? primary;

    protected Relations relations;

    protected SectionAttribute section;

    protected int? continuationIndex;

    internal abstract IEnumerable<Build> Build(Queue<string> strings);

    internal bool IsMatch(string @string) => section.IsMatch(@string);

    internal bool IsContinuation(string @string) => continuationIndex is not null && @string[continuationIndex.Value] is not '0' and not '1';

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

    protected readonly ProcessAttribute<TRecord>? process;

    internal RecordInfo(Supplement supplement)
    {
        var type = typeof(TRecord);

        info = new(supplement);

        process = type.GetCustomAttribute<ProcessAttribute<TRecord>>();

        if (process is not null && supplement < process.Start && supplement > process.End)
            process = null;

        continuationIndex = type.GetCustomAttributes<ContinuousAttribute>().BySupplement(supplement)?.Index;

        (this.type, primary) = process is null
            ? (type, Primary.Create(type))
            : (process.NewType, Primary.Create(process.NewType));

        relations = process is null
            ? new Relations<TRecord>(supplement)
            : process.GetRelations(supplement);
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
        return process is not null ? process.Process(builds) : builds;
    }
}

internal sealed class RecordInfo<TSequence, TSub>(Supplement supplement, Range sequenceRange) : RecordInfo<TSequence>(supplement)
    where TSequence : Record424<TSub>, new()
    where TSub : Record424, new()
{
    private readonly BuildInfo<TSub> subInfo = new(supplement);

    private readonly Range sequenceRange = sequenceRange;

    [Obsolete("todo: sequence number try parsing")]
    internal override IEnumerable<Build> Build(Queue<string> strings)
    {
        Queue<string> sequence = [];
        Queue<Diagnostic> diagnostics = [];

        Queue<Build<TSequence>> builds = [];

        while (strings.TryDequeue(out string? @string))
        {
            sequence.Enqueue(@string);

            int number = int.Parse(@string[sequenceRange]);

            if (!strings.TryPeek(out @string) || int.Parse(@string[sequenceRange]) <= number)
            {
                var build = new Build<TSequence, TSub>(RecordBuilder<TSequence, TSub>.Build(sequence, info, subInfo, diagnostics));

                if (diagnostics.Count > 0)
                {
                    build.Diagnostics = diagnostics;
                    diagnostics = [];
                }
                builds.Enqueue(build);
            }
        }
        return process is not null ? process.Process(builds) : builds;
    }
}
