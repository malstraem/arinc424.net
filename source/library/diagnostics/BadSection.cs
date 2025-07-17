namespace Arinc424.Diagnostics;

public record BadSection : PropertyDiagnostic
{
    public required Section Section { get; init; }

    public required int Index { get; init; }

    public required int SubIndex { get; init; }
}
