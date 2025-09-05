using System.Collections.Immutable;

namespace Arinc424;

/**<summary>
Says that <see cref="RangeDiagnostic.Range"/>
characters could not been parsed.
</summary>*/
public record BadValue : RangeDiagnostic
{
    public required ImmutableArray<char> Value { get; init; }
}
