using System.Reflection;

using Arinc424.Building;
using Arinc424.Diagnostics;

namespace Arinc424.Attributes;

internal sealed class SequenceAttribute<TRecord, TSub>() : RecordAttribute<TRecord>
    where TRecord : Record424<TSub>, new()
    where TSub : Record424, new()
{
    internal Range range = typeof(TRecord).GetCustomAttribute<SequencedAttribute>()!.Range;

    private readonly BuildInfo<TSub> subInfo = new(typeof(TSub).GetProperties());

    [Obsolete("todo: try parse sequence number")]
    internal override Queue<Build> Build(Queue<string> strings)
    {
        Queue<Build> builds = [];
        Queue<string> sequence = [];
        Queue<Diagnostic> diagnostics = [];

        while (strings.TryDequeue(out string? @string))
        {
            sequence.Enqueue(@string);

            int number = int.Parse(@string[range]);

            if (!strings.TryPeek(out @string) || int.Parse(@string[range]) <= number)
            {
                var build = new Build<TRecord, TSub>(RecordBuilder<TRecord, TSub>.Build(sequence, info, subInfo, diagnostics));

                if (diagnostics.Count > 0)
                {
                    build.Diagnostics = diagnostics;
                    diagnostics = [];
                }
                builds.Enqueue(build);
            }
        }
        return builds;
    }

    internal LinksAttribute SubLinks { get; } = new LinksAttribute(typeof(TSub));
}
