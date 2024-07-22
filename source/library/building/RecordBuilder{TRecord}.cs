using Arinc424.Diagnostics;

namespace Arinc424.Building;

internal static class RecordBuilder<TRecord> where TRecord : Record424, new()
{
    internal static TRecord Build(string @string, BuildInfo<TRecord> info, Queue<Diagnostic> diagnostics)
    {
        TRecord record = new() { Source = @string };

        foreach (var assignment in info.Assignments)
            assignment.Assign(record, @string, diagnostics);

        return record;
    }
}
