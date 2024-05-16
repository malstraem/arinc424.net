namespace Arinc424;

[DebuggerDisplay($"{{{nameof(Latitude)}}}, {{{nameof(Longitude)}}}")]
public struct Coordinates(double latitude, double longitude)
{
    /// <summary>
    /// <c>Latitude (LATITUDE)</c> field.
    /// </summary>
    /// <remarks>See section 5.36.</remarks>
    public double Latitude = latitude;

    /// <summary>
    /// <c>Longitude (LONGITUDE)</c> field.
    /// </summary>
    /// <remarks>See section 5.37.</remarks>
    public double Longitude = longitude;
}
