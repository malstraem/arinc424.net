namespace Arinc424;

public abstract record RangeDiagnostic : PropertyDiagnostic
{
    public required Range Range { get; init; }
}
