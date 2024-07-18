using Arinc424.Processing;

namespace Arinc424.Airspace;

/// <summary>
/// <c>Restrictive Airspace</c> primary record sequence.
/// </summary>
/// <remarks>See section 4.1.18.1.</remarks>
[Process<RestrictiveSpace, RestrictiveVolume, RestrictiveSpaceConcatenater>]
[DebuggerDisplay($"{{{nameof(IcaoCode)},nq}}, {{{nameof(Designation)},nq}}")]
public class RestrictiveVolume : Volume
{
    /// <inheritdoc cref="Terms.RestrictiveType"/>
    [Character(9)]
    public Terms.RestrictiveType Type { get; set; }

    /// <summary>
    /// <c>Restrictive Airspace Designation</c> field.
    /// </summary>
    /// <remarks>See section 5.129.</remarks>
    [Field(10, 19)]
    public string Designation { get; set; }
}
