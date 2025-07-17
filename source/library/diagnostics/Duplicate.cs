namespace Arinc424.Diagnostics;

public record Duplicate : Diagnostic
{
    public required KeyInfo Info { get; init; }

    public required Type Type { get; init; }

    public required string Key { get; init; }
}
