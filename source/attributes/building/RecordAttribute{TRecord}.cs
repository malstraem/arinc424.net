using Arinc424.Building;
using Arinc424.Diagnostics;

namespace Arinc424.Attributes;

[AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
internal class RecordAttribute<TRecord>() : BuildAttribute(typeof(TRecord)) where TRecord : Record424, new()
{
    protected readonly BuildInfo<TRecord> info = new(typeof(TRecord).GetProperties());

    internal override Queue<Build> Build(Queue<string> strings)
    {
        Queue<Diagnostic> diagnostics = [];

        Queue<Build> builds = new(strings.Count);

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
        return builds;
    }
}
