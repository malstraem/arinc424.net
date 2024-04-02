using System.Diagnostics;

using Arinc424.Attributes;
using Arinc424.Converters;

namespace Arinc424.Airspace;

/// <summary>
/// Combination of boundary point properties used by <see cref="ControlledAirspace"/> and <see cref="RestrictiveAirspace"/> like subsequence.
/// </summary>
[DebuggerDisplay($"{{{nameof(BoundaryVia)}}} - {{{nameof(Latitude)}}}, {{{nameof(Longitude)}}}")]
public class BoundaryPoint : Geo
{
    [Transform<BoundaryViaConverter>]
    [Character(31), Character<FlightInfoRegion>(33)]
    public Terms.BoundaryVia BoundaryVia { get; set; }

    [Decode<ArcConverter>]
    [Field(52, 78), Field<FlightInfoRegion>(54, 80)]
    public Arc? Arc { get; set; }
}
