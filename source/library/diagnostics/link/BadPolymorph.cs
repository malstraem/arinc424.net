namespace Arinc424;

/**<summary>
Says that characters in <see cref="BadLink.Info"/> ranges
is invalid polymorph relation.
</summary>*/
public sealed record BadPolymorph : BadLink
{
    public required Section Section { get; init; }

    public required (int First, int Second) Indices { get; init; }

    public Type? Type { get; set; }

    public string? Key { get; init; }
}
