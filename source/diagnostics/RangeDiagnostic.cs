namespace Arinc424.Diagnostics;

public abstract class RangeDiagnostic(Record424 record, string problem, Range range, DiagnosticType diagnosticType)
    : Diagnostic(record, problem, diagnosticType)
{
    public Range Range { get; } = range;
}
