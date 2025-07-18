namespace Arinc424.Diagnostics;

/**<summary>
Says that the <see cref="Diagnostic.Record"/> have primary key that are same as <see cref="Collision"/>.
</summary>
<remarks>Any record that has such a diagnostic loses all its potential relationships, which go to the 'copy'.</remarks>*/
public record Duplicate : Diagnostic
{
    public required KeyInfo Info { get; init; }

    public required Type Type { get; init; }

    public required string Key { get; init; }

    public required Record424 Collision { get; init; }
}
