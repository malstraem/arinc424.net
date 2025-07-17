namespace Arinc424.Diagnostics;

public record BadLink : PropertyDiagnostic
{
    public required KeyInfo Info { get; init; }

    public required LinkError Error { get; init; }

    public required Type Type { get; set; }

    public string? Key { get; init; }
}
