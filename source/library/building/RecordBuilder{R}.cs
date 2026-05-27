namespace Arinc424.Building;

internal static class RecordBuilder<R>
    where R : Record424
{
    internal static Build<R> Build
    (
        string @string,
        BuildInfo<R> info,
        ref Queue<Diagnostic> diagnostics)
    {
        var record = Activator.CreateInstance<R>();
        record.Source = @string;

        Build<R> build = new(record);
        Build(build, info, ref diagnostics);
        return build;
    }

    internal static void Build
    (
        Build<R> build,
        BuildInfo<R> info,
        ref Queue<Diagnostic> diagnostics)
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

internal static class RecordBuilder<R, S>
    where R : Record424<S>
    where S : Record424
{
    internal static Build<R, S> Build
    (
        Queue<Build<S>> subs,
        BuildInfo<R> info,
        ref Queue<Diagnostic> diagnostics)
    {
        var sub = subs.First();

        var builds = new Build<S>[subs.Count];

        var record = Activator.CreateInstance<R>();
        record.Source = sub.Record.Source!;
        record.Sequence = new S[subs.Count];

        int i = 0;
        while (subs.TryDequeue(out sub))
        {
            record.Sequence[i] = sub.Record;
            builds[i] = sub;
            i++;

            if (sub.Diagnostics is not null)
                diagnostics.Pump(sub.Diagnostics);
        }
        Build<R, S> build = new(record, builds);
        RecordBuilder<R>.Build(build, info, ref diagnostics);
        return build;
    }
}
