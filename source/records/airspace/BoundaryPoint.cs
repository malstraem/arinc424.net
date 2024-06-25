namespace Arinc424.Airspace;

using Terms;

/// <summary>
/// Combination of boundary point properties used by <see cref="ControlledAirspace"/> and <see cref="RestrictiveAirspace"/> like subsequence.
/// </summary>
[DebuggerDisplay($"{{{nameof(Via)}}} - {{{nameof(Coordinates)}}}")]
public class BoundaryPoint : Geo
{
    /// <inheritdoc cref="BoundaryVia"/>
    [Character(31), Character<RegionPoint>(33)]
    public BoundaryVia Via { get; set; }

    [Field(52, 78), Field<RegionPoint>(54, 80)]
    public Arc? Arc { get; set; }
}
