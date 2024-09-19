namespace Arinc424.Diagnostics;

public abstract class Diagnostic(DiagnosticType type, Record424 record)
{
    public Record424 Record { get; } = record;

    public DiagnosticType DiagnosticType { get; } = type;
}
