namespace Arinc424.Building;

using Diagnostics;

internal static class RecordBuilder<TRecord> where TRecord : Record424, new()
{
    internal static Build<TRecord> Build(string @string, BuildInfo<TRecord> info, ref Queue<Diagnostic> diagnostics)
    {
        TRecord record = new() { Source = @string };

        Build<TRecord> build = new(record);

        Build(build, info, ref diagnostics);

        return build;
    }

    internal static void Build(Build<TRecord> build, BuildInfo<TRecord> info, ref Queue<Diagnostic> diagnostics)
    {
        foreach (var assignment in info.Assignments)
            assignment.Assign(build.Record, build.Record.Source, diagnostics);

        if (diagnostics.Count != 0)
        {
            build.Diagnostics = diagnostics;
            diagnostics = [];
        }
    }
}

internal static class RecordBuilder<TSequence, TSub> where TSequence : Record424<TSub>, new() where TSub : Record424
{
    internal static Build<TSequence, TSub> Build(Queue<Build<TSub>> subs, BuildInfo<TSequence> info, ref Queue<Diagnostic> diagnostics)
    {
        int i = 0;

        var sub = subs.First();

        TSequence record = new()
        {
            Source = sub.Record.Source!,
            Sequence = new TSub[subs.Count]
        };

        Build<TSequence, TSub> build = new(record);

        while (subs.TryDequeue(out sub))
        {
            record.Sequence[i] = sub.Record; i++;

            if (sub.Diagnostics is not null)
                diagnostics.Pump(sub.Diagnostics);
        }
        RecordBuilder<TSequence>.Build(build, info, ref diagnostics);

        return build;
    }
}
