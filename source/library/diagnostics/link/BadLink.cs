namespace Arinc424;

public abstract record BadLink : PropertyDiagnostic
{
    public required KeyInfo Info { get; init; }

    public required LinkError Error { get; init; }
}
