namespace Arinc424.Airspace;

using Terms;

/// <summary>
/// Fields of <c>Controlled Airspace</c> and <c>Restrictive Airspace</c>.
/// </summary>
/// <remarks>Used by <see cref="ControlledVolume"/> and <see cref="RestrictiveVolume"/> like subsequence.</remarks>
[DebuggerDisplay($"{{{nameof(Via)}}} - {{{nameof(Coordinates)}}}")]
public class BoundaryPoint : Geo, ISequenced
{
    [Integer]
    [Field(21, 24), Field<RegionPoint>(16, 19)]
    public int SeqNumber { get; set; }

    /// <inheritdoc cref="BoundaryVia"/>
    [Character(31), Character<RegionPoint>(33)]
    public BoundaryVia Via { get; set; }

    [Field(52, 78), Field<RegionPoint>(54, 80)]
    public Arc? Arc { get; set; }
}
