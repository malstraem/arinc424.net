using Arinc424.Ports;

namespace Arinc424;

/// <summary>
/// Various latitudes and longitudes according to the specification.
/// </summary>
/// <remarks>See section 5.36, 5.37, 5.267, 5.268.</remarks>
[Decode<CoordinatesConverter, Coordinates>]
[Decode<HighPrecisionCoordinatesConverter, Coordinates, AirportSatellitePoint>]
[DebuggerDisplay($"{{{nameof(Latitude)}}}, {{{nameof(Longitude)}}}")]
public readonly struct Coordinates(double latitude, double longitude)
{
    /// <summary>
    /// <c>Latitude (LATITUDE)</c> or <c>High Precision Latitude (HPLAT)</c> field.
    /// </summary>
    /// <remarks>See section 5.36 or 5.267.</remarks>
    public double Latitude { get; } = latitude;

    /// <summary>
    /// <c>Longitude (LONGITUDE)</c> or <c>High Precision Longitude (HPLONG)</c> field.
    /// </summary>
    /// <remarks>See section 5.37 or 5.268.</remarks>
    public double Longitude { get; } = longitude;
}
