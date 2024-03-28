namespace Arinc.Spec424.Terms;

/// <summary>
/// <c>Name Format Indicator (NAME IND)</c>.
/// </summary>
/// <remarks>See section 5.196.</remarks>
public enum WaypointNameFormats : uint
{
    Unknown = 0u,
    /// <summary>
    /// Abeam Fix.
    /// </summary>
    Abeam = 1u,
    /// <summary>
    /// Bearing and Distance Fix.
    /// </summary>
    BearingDistance = 1u << 1,
    /// <summary>
    /// Airport Name as Fix.
    /// </summary>
    AirportName = 1u << 2,
    /// <summary>
    /// FIR Fix.
    /// </summary>
    FlightInfoRegion = 1u << 3,
    /// <summary>
    /// Phonetic Letter Name Fix.
    /// </summary>
    PhoneticLetterName = 1u << 4,
    /// <summary>
    /// Airport Ident as Fix.
    /// </summary>
    AirportIdentifier = 1u << 5,
    /// <summary>
    /// Latitude/Longitude Fix.
    /// </summary>
    LatitudeLongitude = 1u << 6,
    /// <summary>
    /// Multiple Word Name Fix.
    /// </summary>
    MultipleWordName = 1u << 7,
    /// <summary>
    /// Navaid Ident as Fix.
    /// </summary>
    NavaidIdentifier = 1u << 8,
    /// <summary>
    /// Published Five - Letter - Name - Fix.
    /// </summary>
    FiveLetterName = 1u << 9,
    /// <summary>
    /// Published Name Fix, less than five letters.
    /// </summary>
    LessFiveLetterName = 1u << 10,
    /// <summary>
    /// Published Name Fix, more than five letters.
    /// </summary>
    MoreFiveLetterName = 1u << 11,
    /// <summary>
    /// Airport/Runway Related Fix.
    /// </summary>
    AirportRunway = 1u << 12,
    /// <summary>
    /// UIR Fix.
    /// </summary>
    UpperInfoRegion = 1u << 13,
    /// <summary>
    /// Localizer Marker with officially published five - letter identifier.
    /// </summary>
    LocalizerOfficialFive = 1u << 14,
    /// <summary>
    /// Localizer Marker without officially published five - letter identifier.
    /// </summary>
    LocalizerUnofficialFive = 1u << 15
}
