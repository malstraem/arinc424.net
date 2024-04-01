using System.Diagnostics;

using Arinc.Spec424.Attributes;
using Arinc.Spec424.Terms;
using Arinc.Spec424.Converters;

namespace Arinc.Spec424.Records;

/// <summary>
/// Combination of boundary point properties used by
/// <see cref="FlightInfoRegion"/>, <see cref="ControlledAirspace"/> and <see cref="RestrictiveAirspace"/> like subsequence.
/// </summary>
[DebuggerDisplay($"{{{nameof(BoundaryVia)}}} - {{{nameof(Latitude)}}}, {{{nameof(Longitude)}}}")]
public class BoundaryPoint : Geo
{
    [Transform<BoundaryViaConverter>]
    [Character(31), Character<FlightInfoRegion>(33)]
    public BoundaryVia BoundaryVia { get; init; }

    [Decode<ArcConverter>]
    [Field(52, 78), Field<FlightInfoRegion>(54, 80)]
    public Arc? Arc { get; init; }
}
