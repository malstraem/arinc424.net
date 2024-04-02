using System.Diagnostics;

using Arinc424.Attributes;

namespace Arinc424.Navigation;

#pragma warning disable CS8618

/// <summary>
/// <c>NDB Navaid</c> primary record.
/// </summary>
/// <remarks>See section 4.1.3.1.</remarks>
[Record('D', 'B'), Continuous]
[DebuggerDisplay($"{{{nameof(Identifier)}}}")]
public class NonDirectionalBeacon : Geo, IIcao, IIdentity
{
    /// <summary>
    /// <c>NDB Identifier (NDB IDENT)</c> field.
    /// </summary>
    /// <remarks>See section 5.33.</remarks>
    [Field(14, 17), Primary]
    public string Identifier { get; set; }

    /// <summary>
    /// <c>ICAO Code (ICAO CODE)</c> field.
    /// </summary>
    /// <remarks>See section 5.14.</remarks>
    [Field(20, 21), Primary]
    public string IcaoCode { get; set; }

    /// <summary>
    /// <c>NDB Frequency (NDB FREQ)</c> field.
    /// </summary>
    /// <remarks>See section 5.34.</remarks>
    [Field(23, 27)]
    public string Frequency { get; set; }

    /// <summary>
    /// <c>NAVAID Class (CLASS)</c> field.
    /// </summary>
    /// <remarks>See section 5.35.</remarks>
    [Field(28, 32)]
    public string Class { get; set; }

    /// <summary>
    /// <c>Magnetic Variation (MAG VAR, D MAG VAR)</c> field.
    /// </summary>
    /// <remarks>See section 5.39.</remarks>
    [Field(75, 79)]
    public string MagneticVariation { get; set; }

    /// <summary>
    /// <c>Datum Code (DATUM)</c> field.
    /// </summary>
    /// <remarks>See section 5.197.</remarks>
    [Field(91, 93)]
    public string DatumCode { get; set; }

    /// <summary>
    /// <c>Name Field</c> field.
    /// </summary>
    /// <remarks>See section 5.71.</remarks>
    [Field(94, 123)]
    public string Name { get; set; }
}
