namespace Arinc424.Waypoints.Terms;

/// <summary>
/// <c>Name Format Indicator (NAME IND)</c> field.
/// </summary>
/// <remarks>See section 5.196.</remarks>
[String, Flags]
public enum WaypointNameFormats : ushort
{
    Unknown = 0,
    /// <summary>
    /// Abeam Fix.
    /// </summary>
    [Map('A')] Abeam = 1,
    /// <summary>
    /// Bearing and Distance Fix.
    /// </summary>
    [Map('B')] BearingDistance = 1 << 1,
    /// <summary>
    /// Airport Name as Fix.
    /// </summary>
    [Map('D')] AirportName = 1 << 2,
    /// <summary>
    /// FIR Fix.
    /// </summary>
    [Map('F')] FlightInfoRegion = 1 << 3,
    /// <summary>
    /// Phonetic Letter Name Fix.
    /// </summary>
    [Map('H')] PhoneticLetterName = 1 << 4,
    /// <summary>
    /// Airport Ident as Fix.
    /// </summary>
    [Map('I')] AirportIdentifier = 1 << 5,
    /// <summary>
    /// Latitude/Longitude Fix.
    /// </summary>
    [Map('L')] LatitudeLongitude = 1 << 6,
    /// <summary>
    /// Multiple Word Name Fix.
    /// </summary>
    [Map('M')] MultipleWordName = 1 << 7,
    /// <summary>
    /// Navaid Ident as Fix.
    /// </summary>
    [Map('N')] NavaidIdentifier = 1 << 8,
    /// <summary>
    /// Published Five - Letter - Name - Fix.
    /// </summary>
    [Map('P')] FiveLetterName = 1 << 9,
    /// <summary>
    /// Published Name Fix, less than five letters.
    /// </summary>
    [Map('Q')] LessFiveLetterName = 1 << 10,
    /// <summary>
    /// Published Name Fix, more than five letters.
    /// </summary>
    [Map('R')] MoreFiveLetterName = 1 << 11,
    /// <summary>
    /// Airport/Runway Related Fix.
    /// </summary>
    [Map('T')] AirportRunway = 1 << 12,
    /// <summary>
    /// UIR Fix.
    /// </summary>
    [Map('U')] UpperInfoRegion = 1 << 13,

    [Offset]
    /// <summary>
    /// Localizer Marker with officially published five - letter identifier.
    /// </summary>
    [Map('O')] LocalizerOfficialFive = 1 << 14,
    /// <summary>
    /// Localizer Marker without officially published five - letter identifier.
    /// </summary>
    [Map('M')] LocalizerUnofficialFive = 1 << 15
}
