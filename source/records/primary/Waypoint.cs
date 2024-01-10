using System.Diagnostics;

using Arinc.Spec424.Attributes;

namespace Arinc.Spec424.Records;

#pragma warning disable CS8618

/// <summary>
/// <c>Waypoint</c> primary record.
/// </summary>
/// <remarks>See paragraph 4.1.4.1</remarks>
[Record('E', 'A'), Continuation, DebuggerDisplay("{Identifier}")]
[Obsolete("TODO Terminal Waypoints")]
public class Waypoint : Geo
{
    /// <summary>
    /// <c>Region Code (REGN CODE)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.41</remarks>
    [Field(7, 10)]
    public string RegionCode { get; init; }

    /// <summary>
    /// <c>ICAO Code (ICAO CODE)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.14</remarks>
    [Field(11, 12)]
    public string RegionIcaoCode { get; init; }

    /// <summary>
    /// <c>Fix Identifier (FIX IDENT)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.13</remarks>
    [Field(14, 18)]
    public string Identifier { get; init; }

    /// <summary>
    /// <c>ICAO Code (ICAO CODE)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.14</remarks>
    [Field(20, 21)]
    public string IcaoCode { get; init; }

    /// <summary>
    /// <c>Waypoint Type (TYPE)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.42</remarks>
    [Field(27, 29)]
    public string Type { get; init; }

    /// <summary>
    /// <c>Waypoint Usage</c> character.
    /// </summary>
    /// <remarks>See paragraph 5.82</remarks>
    [Field(30, 31)]
    public string Usage { get; init; }

    /// <summary>
    /// <c>Magnetic Variation (MAG VAR, D MAG VAR)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.39</remarks>
    [Field(75, 79)]
    public string? DynamicMagneticVariation { get; init; }

    /// <summary>
    /// <c>Datum Code (DATUM)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.197</remarks>
    [Field(85, 87)]
    public string? DatumCode { get; init; }

    /// <summary>
    /// <c>Name Format Indicator (NAME IND)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.196</remarks>
    [Field(96, 98)]
    public string? FormatNameIndicator { get; init; }

    /// <summary>
    /// <c>Waypoint Name (NAME)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.43</remarks>
    [Field(99, 123)]
    public string Name { get; init; }
}
