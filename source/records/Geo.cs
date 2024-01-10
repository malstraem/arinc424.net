using Arinc.Spec424.Attributes;
using Arinc.Spec424.Terms.Converters;

namespace Arinc.Spec424.Records;

public class Geo : Record424
{
    /// <summary>
    /// <c>Latitude (LATITUDE)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.36</remarks>
    [DecodeAttribute<LatitudeConverter>]
    [Field(33, 41), Field<FlightInfoRegion>(35, 43), Field<Waypoint>(33, 41)]
    public required double Latitude { get; init; }

    /// <summary>
    /// <c>Longitude (LONGITUDE)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.37</remarks>
    [DecodeAttribute<LongitudeConverter>]
    [Field(42, 51), Field<FlightInfoRegion>(44, 53), Field<Waypoint>(42, 51)]
    public required double Longitude { get; init; }
}
