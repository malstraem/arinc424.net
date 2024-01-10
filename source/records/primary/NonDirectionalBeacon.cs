using Arinc.Spec424.Attributes;

namespace Arinc.Spec424.Records;

/// <summary>
/// <c>NDB Navaid</c> primary record.
/// </summary>
/// <remarks>See paragraph 4.1.3.1.</remarks>
[Record('D', 'B'), Continuation]
public class NonDirectionalBeacon : Record424
{
    /// <summary>
    /// <c>Airport Identifier (IDENT)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.6.</remarks>
    [Field(7, 10), Link<NonDirectionalBeacon, Airport>]
    public required string? AirportIdentifier { get; init; }

    /// <summary>
    /// <c>ICAO Code (ICAO CODE)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.14.</remarks>
    [Field(11, 12)]
    public required string? AirportIcaoCode { get; init; }

    /// <summary>
    /// <c>NDB Identifier (NDB IDENT)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.33.</remarks>
    [Field(14, 17)]
    public required string Identifier { get; init; }

    /// <summary>
    /// <c>ICAO Code (ICAO CODE)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.14.</remarks>
    [Field(20, 21)]
    public required string IcaoCode { get; init; }

    /// <summary>
    /// <c>NDB Frequency (NDB FREQ)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.34.</remarks>
    [Field(23, 27)]
    public required string Frequency { get; init; }

    /// <summary>
    /// <c>NAVAID Class (CLASS)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.35.</remarks>
    [Field(28, 32)]
    public required string Class { get; init; }

    /// <summary>
    /// <c>Latitude (LATITUDE)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.36.</remarks>
    [Field(33, 41)]
    public required string Latitude { get; init; }

    /// <summary>
    /// <c>Longitude (LONGITUDE)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.37.</remarks>
    [Field(42, 51)]
    public required string Longitude { get; init; }

    /// <summary>
    /// <c>Magnetic Variation (MAG VAR, D MAG VAR)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.39.</remarks>
    [Field(75, 79)]
    public required string MagneticVariation { get; init; }

    /// <summary>
    /// <c>Datum Code (DATUM)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.197.</remarks>
    [Field(91, 93)]
    public required string DatumCode { get; init; }

    /// <summary>
    /// <c>Name Field</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.71.</remarks>
    [Field(94, 123)]
    public required string Name { get; init; }
}
