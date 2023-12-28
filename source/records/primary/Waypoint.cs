using Arinc.Spec424.Attributes;

namespace Arinc.Spec424.Records;

/// <summary>
/// <c>Waypoint</c> primary record.
/// </summary>
/// <remarks>See paragraph 4.1.4.1</remarks>
[Record('E', 'A'), Continuation]
[Obsolete("Нужно добавить обработку Terminal Waypoints")]
public record Waypoint : Record424
{
    /// <summary>
    /// <c>Region Code (REGN CODE)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.41</remarks>
    [Field(7, 10)]
    public required string RegionCode { get; init; }

    /// <summary>
    /// <c>ICAO Code (ICAO CODE)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.14</remarks>
    [Field(11, 12)]
    public required string RegionIcaoCode { get; init; }

    /// <summary>
    /// <c>Fix Identifier (FIX IDENT)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.13</remarks>
    [Field(14, 18)]
    public required string Identifier { get; init; }

    /// <summary>
    /// <c>ICAO Code (ICAO CODE)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.14</remarks>
    [Field(20, 21)]
    public required string IcaoCode { get; init; }

    /// <summary>
    /// <c>Waypoint Type (TYPE)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.42</remarks>
    [Field(27, 29)]
    public required string Type { get; init; }

    /// <summary>
    /// <c>Waypoint Usage</c> character.
    /// </summary>
    /// <remarks>See paragraph 5.82</remarks>
    [Field(30, 31)]
    public required string Usage { get; init; }

    /// <summary>
    /// <c>Latitude (LATITUDE)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.36</remarks>
    [Field(33, 41)]
    public required string Latitude { get; init; }

    /// <summary>
    /// <c>Longitude (LONGITUDE)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.37</remarks>
    [Field(42, 51)]
    public required string Longitude { get; init; }

    /// <summary>
    /// <c>Magnetic Variation (MAG VAR, D MAG VAR)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.39</remarks>
    [Field(75, 79)]
    public required string? DynamicMagneticVariation { get; init; }

    /// <summary>
    /// <c>Datum Code (DATUM)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.197</remarks>
    [Field(85, 87)]
    public required string? DatumCode { get; init; }

    /// <summary>
    /// <c>Name Format Indicator (NAME IND)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.196</remarks>
    [Field(96, 98)]
    public required string? FormatNameIndicator { get; init; }

    /// <summary>
    /// <c>Waypoint Name (NAME)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.43</remarks>
    [Field(99, 123)]
    public required string Name { get; init; }
}
