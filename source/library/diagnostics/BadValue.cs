using System.Collections.Immutable;

namespace Arinc424;

public record BadValue : RangeDiagnostic
{
    public required ImmutableArray<char> Value { get; init; }
}
