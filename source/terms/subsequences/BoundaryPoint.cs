using System.Diagnostics;

using Arinc.Spec424.Attributes;
using Arinc.Spec424.Records;
using Arinc.Spec424.Terms.Converters;

namespace Arinc.Spec424.Terms.Subsequences;

/// <summary>
/// Combination of boundary point properties used by <see cref="FlightInfoRegion"/>, <see cref="ControlledAirspace"/> and <see cref="RestrictiveAirspace"/>.
/// </summary>
[DebuggerDisplay("{BoundaryVia} - {Latitude}, {Longitude}")]
public record BoundaryPoint : Record424
{
    [Transform<BoundaryViaConverter>]
    [Character(31), Character<FlightInfoRegion>(33)]
    public BoundaryVia BoundaryVia { get; init; }

    [Field(33, 41), Field<FlightInfoRegion>(35, 43)]
    public required string Latitude { get; init; }

    [Field(42, 51), Field<FlightInfoRegion>(44, 53)]
    public required string Longitude { get; init; }

    [Field(52, 60), Field<FlightInfoRegion>(54, 62)]
    public string? ArcOriginLatitude { get; init; }

    [Field(61, 70), Field<FlightInfoRegion>(63, 72)]
    public string? ArcOriginLongitude { get; init; }

    [Field(71, 74), Field<FlightInfoRegion>(73, 76)]
    public string? ArcDistance { get; init; }

    [Field(75, 78), Field<FlightInfoRegion>(77, 80)]
    public string? ArcBearing { get; init; }
}
