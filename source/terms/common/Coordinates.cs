namespace Arinc424;

/// <summary>
/// Latitude and longitude according to the specification.
/// </summary>
[Decode<CoordinatesConverter>]
[DebuggerDisplay($"{{{nameof(Latitude)}}}, {{{nameof(Longitude)}}}")]
public readonly struct Coordinates(double latitude, double longitude)
{
    /// <summary>
    /// <c>Latitude (LATITUDE)</c> field.
    /// </summary>
    /// <remarks>See section 5.36.</remarks>
    public double Latitude { get; } = latitude;

    /// <summary>
    /// <c>Longitude (LONGITUDE)</c> field.
    /// </summary>
    /// <remarks>See section 5.37.</remarks>
    public double Longitude { get; } = longitude;
}
