namespace Arinc424.Diagnostics;

public abstract record RangeDiagnostic : PropertyDiagnostic
{
    public required Range Range { get; init; }
}
