using System.Diagnostics;

using Arinc.Spec424.Attributes;
using Arinc.Spec424.Terms;
using Arinc.Spec424.Converters;

namespace Arinc.Spec424.Records.Sub;

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

    [Decode<LatitudeConverter>]
    [Field(52, 60), Field<FlightInfoRegion>(54, 62)]
    public double? ArcOriginLatitude { get; init; }

    [Decode<LongitudeConverter>]
    [Field(61, 70), Field<FlightInfoRegion>(63, 72)]
    public double? ArcOriginLongitude { get; init; }

    [Field(71, 74), Field<FlightInfoRegion>(73, 76)]
    public string? ArcDistance { get; init; }

    [Field(75, 78), Field<FlightInfoRegion>(77, 80)]
    public string? ArcBearing { get; init; }
}
