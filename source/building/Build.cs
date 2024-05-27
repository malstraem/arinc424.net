using Arinc424.Diagnostics;

namespace Arinc424.Building;

internal class Build(Record424 record, Queue<Diagnostic>? diagnostics)
{
    internal Record424 Record { get; } = record;

    internal Queue<Diagnostic>? Diagnostics { get; set; } = diagnostics;
}
