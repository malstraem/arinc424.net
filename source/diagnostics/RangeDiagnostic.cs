namespace Arinc424.Diagnostics;

public class RangeDiagnostic(string problem, Range range) : Diagnostic(problem, DiagnosticType.InvalidValue)
{
    public Range Range { get; } = range;
}
