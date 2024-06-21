using System.Reflection;

using Arinc424.Building;
using Arinc424.Diagnostics;

namespace Arinc424.Attributes;

internal sealed class SequenceAttribute<TSequence, TSub>() : RecordAttribute<TSequence>
    where TSequence : Record424<TSub>, new()
    where TSub : Record424, new()
{
    private readonly BuildInfo<TSub> subInfo = new(typeof(TSub).GetProperties());

    private readonly Range range = typeof(TSequence).GetCustomAttribute<SequencedAttribute>()!.Range;

    [Obsolete("todo: sequence number try parsing")]
    internal override IEnumerable<Build> Build(Queue<string> strings)
    {
        Queue<string> sequence = [];
        Queue<Diagnostic> diagnostics = [];

        Queue<Build<TSequence>> builds = [];

        while (strings.TryDequeue(out string? @string))
        {
            sequence.Enqueue(@string);

            int number = int.Parse(@string[range]);

            if (!strings.TryPeek(out @string) || int.Parse(@string[range]) <= number)
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

    internal LinksAttribute SubLinks { get; } = new LinksAttribute(typeof(TSub));
}
