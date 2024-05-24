namespace Arinc424.Diagnostics;

public abstract class Diagnostic(string message, DiagnosticType type)
{
    public string Problem { get; } = message;

    public DiagnosticType Type { get; } = type;
}
