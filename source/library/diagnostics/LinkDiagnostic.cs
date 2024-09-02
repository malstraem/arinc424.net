using Arinc424.Linking;

namespace Arinc424.Diagnostics;

public class LinkDiagnostic(Record424 record, string problem, KeyInfo ranges, (int, int)? section = null) : Diagnostic(record, problem, DiagnosticType.InvalidLink)
{
    public KeyInfo Ranges { get; } = ranges;

    public (int Index, int SubIndex)? Section { get; } = section;
}
