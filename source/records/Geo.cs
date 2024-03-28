using Arinc.Spec424.Attributes;
using Arinc.Spec424.Converters;

namespace Arinc.Spec424.Records;

public abstract class Geo : Record424
{
    /// <summary>
    /// <c>Latitude (LATITUDE)</c> field.
    /// </summary>
    /// <remarks>See section 5.36</remarks>
    [Decode<LatitudeConverter>]
    [Field(33, 41), Field<FlightInfoRegion>(35, 43)]
    public double Latitude { get; init; }

    /// <summary>
    /// <c>Longitude (LONGITUDE)</c> field.
    /// </summary>
    /// <remarks>See section 5.37</remarks>
    [Decode<LongitudeConverter>]
    [Field(42, 51), Field<FlightInfoRegion>(44, 53)]
    public double Longitude { get; init; }
}
