namespace Arinc424.Airspace;

/// <summary>
/// <c>Restrictive Airspace</c> primary record sequence.
/// </summary>
/// <remarks>See section 4.1.18.1.</remarks>
[DebuggerDisplay($"{{{nameof(Type)},nq}}")]
public class RestrictiveVolume : Volume
{
    /// <inheritdoc cref="Terms.RestrictiveType"/>
    [Character(9)]
    public Terms.RestrictiveType Type { get; set; }
}
