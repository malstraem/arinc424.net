namespace Arinc424;

public record BadSection : BadLink
{
    public required Section Section { get; init; }

    public required int Index { get; init; }

    public required int SubIndex { get; init; }
}
