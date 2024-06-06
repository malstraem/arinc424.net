namespace Arinc424.Diagnostics;

public abstract class Diagnostic(Record424 record, string problem, DiagnosticType diagnosticType)
{
    public string Problem { get; } = problem;

    [Obsolete("the need is in question")]
    public Record424 Record { get; } = record;

    public DiagnosticType DiagnosticType { get; } = diagnosticType;
}
