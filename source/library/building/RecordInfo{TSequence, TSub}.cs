using Arinc424.Diagnostics;

namespace Arinc424.Building;

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
        return pipeline is not null ? pipeline.Process(builds) : builds;
    }
}
