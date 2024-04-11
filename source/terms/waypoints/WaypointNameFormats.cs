namespace Arinc424.Waypoints.Terms;

/// <summary>
/// <c>Name Format Indicator (NAME IND)</c> field.
/// </summary>
/// <remarks>See section 5.196.</remarks>
[Flags]
public enum WaypointNameFormats : ushort
{
    Unknown = 0,
    /// <summary>
    /// Abeam Fix.
    /// </summary>
    Abeam = 1,
    /// <summary>
    /// Bearing and Distance Fix.
    /// </summary>
    BearingDistance = 1 << 1,
    /// <summary>
    /// Airport Name as Fix.
    /// </summary>
    AirportName = 1 << 2,
    /// <summary>
    /// FIR Fix.
    /// </summary>
    FlightInfoRegion = 1 << 3,
    /// <summary>
    /// Phonetic Letter Name Fix.
    /// </summary>
    PhoneticLetterName = 1 << 4,
    /// <summary>
    /// Airport Ident as Fix.
    /// </summary>
    AirportIdentifier = 1 << 5,
    /// <summary>
    /// Latitude/Longitude Fix.
    /// </summary>
    LatitudeLongitude = 1 << 6,
    /// <summary>
    /// Multiple Word Name Fix.
    /// </summary>
    MultipleWordName = 1 << 7,
    /// <summary>
    /// Navaid Ident as Fix.
    /// </summary>
    NavaidIdentifier = 1 << 8,
    /// <summary>
    /// Published Five - Letter - Name - Fix.
    /// </summary>
    FiveLetterName = 1 << 9,
    /// <summary>
    /// Published Name Fix, less than five letters.
    /// </summary>
    LessFiveLetterName = 1 << 10,
    /// <summary>
    /// Published Name Fix, more than five letters.
    /// </summary>
    MoreFiveLetterName = 1 << 11,
    /// <summary>
    /// Airport/Runway Related Fix.
    /// </summary>
    AirportRunway = 1 << 12,
    /// <summary>
    /// UIR Fix.
    /// </summary>
    UpperInfoRegion = 1 << 13,
    /// <summary>
    /// Localizer Marker with officially published five - letter identifier.
    /// </summary>
    LocalizerOfficialFive = 1 << 14,
    /// <summary>
    /// Localizer Marker without officially published five - letter identifier.
    /// </summary>
    LocalizerUnofficialFive = 1 << 15
}
