namespace Arinc424;

public record BadLink : PropertyDiagnostic
{
    public required KeyInfo Info { get; init; }

    public required LinkError Error { get; init; }

    public Type? Type { get; set; }

    public string? Key { get; init; }
}
