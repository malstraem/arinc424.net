namespace Arinc424;

/**<summary>
Says that characters in <see cref="BadLink.Info"/> ranges
is invalid strong type relation.
</summary>*/
public record BadKnown : BadLink
{
    public required Type Type { get; set; }

    public string? Key { get; init; }
}
