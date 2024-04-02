using Arinc424.Attributes;

namespace Arinc424.Routing;

/// <summary>
/// <c>Special Activity Area</c> primary record.
/// </summary>
/// <remarks>See section 4.1.33.1.</remarks>
[Record('E', 'S'), Continuous]
public class SpecialActivityArea : Record424
{
    /// <summary>
    /// <c>Activity Type</c> character.
    /// </summary>
    /// <remarks>See section 5.278.</remarks>
    [Character(7)]
    public required char Type { get; set; }

    /// <summary>
    /// <c>Activity Identifier</c> field.
    /// </summary>
    /// <remarks>See section 5.279.</remarks>
    [Field(8, 13)]
    public required string Identifier { get; set; }

    /// <summary>
    /// <c>ICAO Code (ICAO CODE)</c> field.
    /// </summary>
    /// <remarks>See section 5.14.</remarks>
    [Field(14, 15)]
    public required string IcaoName { get; set; }

    /// <summary>
    /// <c>Airport Identifier (ARPT)</c> field.
    /// </summary>
    /// <remarks>See section 5.6.</remarks>
    [Field(16, 19)]
    public required string AirportIdentifier { get; set; }

    /// <summary>
    /// <c>ICAO Code (ICAO CODE)</c> field.
    /// </summary>
    /// <remarks>See section 5.14.</remarks>
    [Field(20, 21)]
    public required string AirportIcaoCode { get; set; }

    /// <summary>
    /// <c>Latitude (LATITUDE)</c> field.
    /// </summary>
    /// <remarks>See section 5.36.</remarks>
    [Field(24, 32)]
    public required string Latitude { get; set; }

    /// <summary>
    /// <c>Longitude (LONGITUDE)</c> field.
    /// </summary>
    /// <remarks>See section 5.37.</remarks>
    [Field(33, 43)]
    public required string Longitude { get; set; }

    /// <summary>
    /// <c>name</c> field.
    /// </summary>
    /// <remarks>See section 5.280.</remarks>
    [Field(43, 45)]
    public required string Size { get; set; }

    /// <summary>
    /// <c>Upper Limit</c> field.
    /// </summary>
    /// <remarks>See section 5.121.</remarks>
    [Field(46, 51)]
    public required string UpperLimit { get; set; }

    /// <summary>
    /// <c>Unit Indicator (UNIT IND)</c> character.
    /// </summary>
    /// <remarks>See section 5.133.</remarks>
    [Character(52)]
    public required char UnitIndicator { get; set; }

    /// <summary>
    /// <c>Special Activity Area Volume</c> character.
    /// </summary>
    /// <remarks>See section 5.281.</remarks>
    [Character(53)]
    public required char Volume { get; set; }

    /// <summary>
    /// <c>Communications Class (Comm Class)</c> field.
    /// </summary>
    /// <remarks>See section 5.282.</remarks>
    [Field(54, 56)]
    public required string OperatingTimes { get; set; }

    /// <summary>
    /// <c> Public/Military Indicator (PUB/MIL)</c> character.
    /// </summary>
    /// <remarks>See section 5.177.</remarks>
    [Character(57)]
    public required char PublicMilitaryIndicator { get; set; }

    /// <summary>
    /// <c>Controlling Agency</c> field.
    /// </summary>
    /// <remarks>See section 5.140.</remarks>
    [Field(59, 83)]
    public required string ControllingAgency { get; set; }

    /// <summary>
    /// <c>Communications Type (COMM TYPE)</c> field.
    /// </summary>
    /// <remarks>See section 5.101.</remarks>
    [Field(84, 86)]
    public required string CommunicationType { get; set; }

    /// <summary>
    /// <c>Communications Frequency (COMM FREQ)</c> field.
    /// </summary>
    /// <remarks>See section 5.103.</remarks>
    [Field(87, 93)]
    public required string CommunicationFrequency { get; set; }

    /// <summary>
    /// <c>Restrictive Airspace Name</c> field.
    /// </summary>
    /// <remarks>See section 5.126.</remarks>
    [Field(94, 123)]
    public required string Name { get; set; }
}
