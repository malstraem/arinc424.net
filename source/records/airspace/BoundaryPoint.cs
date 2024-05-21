namespace Arinc424.Airspace;

using Terms;

/// <summary>
/// Combination of boundary point properties used by <see cref="ControlledAirspace"/> and <see cref="RestrictiveAirspace"/> like subsequence.
/// </summary>
[DebuggerDisplay($"{{{nameof(BoundaryVia)}}} - {{{nameof(Coordinates)}}}")]
public class BoundaryPoint : Geo
{
    /// <inheritdoc cref="BoundaryVia"/>
    [Transform<BoundaryViaConverter>]
    [Character(31), Character<FlightRegionPoint>(33)]
    public BoundaryVia Via { get; set; }

    [Decode<ArcConverter>]
    [Field(52, 78), Field<FlightRegionPoint>(54, 80)]
    public Arc? Arc { get; set; }
}
