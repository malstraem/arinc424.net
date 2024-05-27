namespace Arinc424.Diagnostics;

public abstract class Diagnostic(Record424 record, string message)
{
    protected DiagnosticType diagnosticType;

    public string Problem { get; } = message;

    public Record424 Record { get; } = record;

    public DiagnosticType DiagnosticType => diagnosticType;
}
