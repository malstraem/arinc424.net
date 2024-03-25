using System.Diagnostics;

using Arinc.Spec424.Attributes;

namespace Arinc.Spec424.Records;

#pragma warning disable CS8618

/// <summary>
/// <c>VHF NAVAID</c> primary record.
/// </summary>
/// <remarks>See paragraph 4.1.2.1.</remarks>
[Record('D'), Continious]
[DebuggerDisplay($"{{{nameof(Identifier)}}}")]
public class OmnidirectionalStation : Geo, IIcao, IIdentity
{
    [Foreign(7, 12)]
    public Airport? Airport { get; init; }

    /// <summary>
    /// <c>VOR Identifier (VOR IDENT)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.33.</remarks>
    [Field(14, 17), Primary]
    public string Identifier { get; init; }

    /// <summary>
    /// <c>ICAO Code (ICAO CODE)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.14.</remarks>
    [Field(20, 21), Primary]
    public string IcaoCode { get; init; }

    /// <summary>
    /// <c>VOR Frequency (VOR FREQ)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.34.</remarks>
    [Field(23, 27)]
    public string Frequency { get; init; }

    /// <summary>
    /// <c>NAVAID Class (CLASS)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.35.</remarks>
    [Field(28, 32)]
    public string NavaidClass { get; init; }

    /// <summary>
    /// <c>DME Identifier (DME IDENT)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.38.</remarks>
    [Field(52, 55)]
    public string DmeIdentifier { get; init; }

    /// <summary>
    /// <c>Latitude (LATITUDE)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.36.</remarks>
    [Field(56, 64)]
    public string DmeLatitude { get; init; }

    /// <summary>
    /// <c>Longitude (LONGITUDE)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.37.</remarks>
    [Field(65, 74)]
    public string DmeLongitude { get; init; }

    /// <summary>
    /// <c>Station Declination (STN DEC)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.66.</remarks>
    [Field(75, 79)]
    public string StationDeclination { get; init; }

    /// <summary>
    /// <c>DME Elevation (DME ELEV)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.40.</remarks>
    [Field(80, 84)]
    public string DmeElevation { get; init; }

    /// <summary>
    /// <c>Figure of Merit (MERIT)</c> character.
    /// </summary>
    /// <remarks>See paragraph 5.149.</remarks>
    [Character(85)]
    public char MeritFigure { get; init; }

    /// <summary>
    /// <c>ILS/DME Bias</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.90.</remarks>
    [Field(86, 87)]
    public string IlsDmeBias { get; init; }

    /// <summary>
    /// <c>Frequency Protection Distance (FREQ PRD)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.150.</remarks>
    [Field(88, 90)]
    public string FrequencyProtectionDistance { get; init; }

    /// <summary>
    /// <c>Datum Code (DATUM)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.197.</remarks>
    [Field(91, 93)]
    public string DatumCode { get; init; }

    /// <summary>
    /// <c>Name</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.71.</remarks>
    [Field(94, 118)]
    public string VorName { get; init; }

    /// <summary>
    /// <c>Route Inappropriate Navaid Indicator</c> character.
    /// </summary>
    /// <remarks>See paragraph 5.297.</remarks>
    [Character(122)]
    public char RouteInappropriateDme { get; init; }

    /// <summary>
    /// <c>DME Operational Service Volume (D-OSV)</c> character.
    /// </summary>
    /// <remarks>See paragraph 5.277.</remarks>
    [Character(123)]
    public char DmeOperationalServiceVolume { get; init; }
}
