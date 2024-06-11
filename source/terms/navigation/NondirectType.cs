namespace Arinc424.Navigation.Terms;

/// <summary>
/// First two characters of <c>NAVAID Class (CLASS)</c> field, specific to <see cref="Nondirectional"/>.
/// </summary>
/// <remarks>See section 5.35.</remarks>
[String, Flags, Decode<NondirectTypeConverter, NondirectType>]
public enum NondirectType : byte
{
    Unknown = 0,
    /// <summary>
    /// NDB.
    /// </summary>
    [Map('H')] Nondirect = 1,
    /// <summary>
    /// H-SAB, providing automatic transcribed weather service.
    /// </summary>
    [Map('S')] WithWeather = 1 << 1,
    /// <summary>
    /// Marine Beacon.
    /// </summary>
    [Map('M')] Marine = 1 << 2,

    [Offset]
    /// <summary>
    /// Inner Marker.
    /// </summary>
    [Map('I')] Inner = 1 << 3,
    /// <summary>
    /// Middle Marker.
    /// </summary>
    [Map('M')] Middle = 1 << 4,
    /// <summary>
    /// Outer Marker.
    /// </summary>
    [Map('O')] Outer = 1 << 5,
    /// <summary>
    /// Back Marker.
    /// </summary>
    [Map('C')] Back = 1 << 6
}
