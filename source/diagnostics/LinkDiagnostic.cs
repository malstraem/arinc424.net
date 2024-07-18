using Arinc424.Linking;

namespace Arinc424.Diagnostics;

public class LinkDiagnostic(Record424 record, string problem, KeyRanges ranges, (int, int)? section = null) : Diagnostic(record, problem, DiagnosticType.InvalidLink)
{
    public KeyRanges Ranges { get; } = ranges;

    public (int Index, int SubIndex)? Section { get; } = section;
}
