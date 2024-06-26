using Arinc424.Diagnostics;

namespace Arinc424.Building;

[DebuggerDisplay($"{{{nameof(Record)}}}")]
internal abstract class Build(Record424 record)
{
    internal Record424 Record { get; } = record;

    internal Queue<Diagnostic>? Diagnostics { get; set; }
}
