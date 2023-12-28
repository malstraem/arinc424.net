using Arinc.Spec424.Attributes;

namespace Arinc.Spec424.Records;

/// <summary>
/// <c>VHF NAVAID</c> primary record.
/// </summary>
/// <remarks>See paragraph 4.1.2.1.</remarks>
[Record('D'), Continuation]
public record NavigationalAid : Record424
{
    /// <summary>
    /// <c>Airport Identifier (ARPT)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.6.</remarks>
    [Field(7, 10)]
    public required string AirportIcaoIdentifier { get; init; }

    /// <summary>
    /// <c>ICAO Code (ICAO CODE)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.14.</remarks>
    [Field(11, 12)]
    public required string AirportIcaoCode { get; init; }

    /// <summary>
    /// <c>VOR Identifier (VOR IDENT)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.33.</remarks>
    [Field(14, 17)]
    public required string VorIdentifier { get; init; }

    /// <summary>
    /// <c>ICAO Code (ICAO CODE)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.14.</remarks>
    [Field(20, 21)]
    public required string VorIcaoCode { get; init; }

    /// <summary>
    /// <c>VOR Frequency (VOR FREQ)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.34.</remarks>
    [Field(23, 27)]
    public required string VorFrequency { get; init; }

    /// <summary>
    /// <c>NAVAID Class (CLASS)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.35.</remarks>
    [Field(28, 32)]
    public required string NavaidClass { get; init; }

    /// <summary>
    /// <c>Latitude (LATITUDE)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.36.</remarks>
    [Field(33, 41)]
    public required string VorLatitude { get; init; }

    /// <summary>
    /// <c>Longitude (LONGITUDE)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.37.</remarks>
    [Field(42, 51)]
    public required string VorLongitude { get; init; }

    /// <summary>
    /// <c>DME Identifier (DME IDENT)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.38.</remarks>
    [Field(52, 55)]
    public required string DmeIdentifier { get; init; }

    /// <summary>
    /// <c>Latitude (LATITUDE)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.36.</remarks>
    [Field(56, 64)]
    public required string DmeLatitude { get; init; }

    /// <summary>
    /// <c>Longitude (LONGITUDE)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.37.</remarks>
    [Field(65, 74)]
    public required string DmeLongitude { get; init; }

    /// <summary>
    /// <c>Station Declination (STN DEC)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.66.</remarks>
    [Field(75, 79)]
    public required string StationDeclination { get; init; }

    /// <summary>
    /// <c>DME Elevation (DME ELEV)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.40.</remarks>
    [Field(80, 84)]
    public required string DmeElevation { get; init; }

    /// <summary>
    /// <c>Figure of Merit (MERIT)</c> character.
    /// </summary>
    /// <remarks>See paragraph 5.149.</remarks>
    [Character(85)]
    public required char MeritFigure { get; init; }

    /// <summary>
    /// <c>ILS/DME Bias</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.90.</remarks>
    [Field(86, 87)]
    public required string IlsDmeBias { get; init; }

    /// <summary>
    /// <c>Frequency Protection Distance (FREQ PRD)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.150.</remarks>
    [Field(88, 90)]
    public required string FrequencyProtectionDistance { get; init; }

    /// <summary>
    /// <c>Datum Code (DATUM)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.197.</remarks>
    [Field(91, 93)]
    public required string DatumCode { get; init; }

    /// <summary>
    /// <c>Name</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.71.</remarks>
    [Field(94, 118)]
    public required string VorName { get; init; }

    /// <summary>
    /// <c>Route Inappropriate Navaid Indicator</c> character.
    /// </summary>
    /// <remarks>See paragraph 5.297.</remarks>
    [Character(122)]
    public required char RouteInappropriateDme { get; init; }

    /// <summary>
    /// <c>DME Operational Service Volume (D-OSV)</c> character.
    /// </summary>
    /// <remarks>See paragraph 5.277.</remarks>
    [Character(123)]
    public required char DmeOperationalServiceVolume { get; init; }
}
