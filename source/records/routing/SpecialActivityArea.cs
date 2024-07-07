namespace Arinc424.Routing;

using Arinc424.Ports;

using Terms;

/// <summary>
/// <c>Special Activity Area</c> primary record.
/// </summary>
/// <remarks>See section 4.1.33.1.</remarks>
[Section('E', 'S'), Continuous]
public class SpecialActivityArea : Geo, IIdentity, IIcao, INamed
{
    [Identifier(16, 19), Icao(20, 21)]
    public Airport Airport { get; set; }

    /// <inheritdoc cref="ActivityType"/>
    [Character(7)]
    public ActivityType Type { get; set; }

    /// <summary>
    /// <c>Activity Identifier</c> field.
    /// </summary>
    /// <remarks>See section 5.279.</remarks>
    [Field(8, 13)]
    public string Identifier { get; set; }

    [Field(14, 15)]
    public string IcaoCode { get; set; }

    /// <summary>
    /// <c>Special Activity Area Size</c> field.
    /// </summary>
    /// <value>Nautical miles and tenths of mile.</value>
    /// <remarks>See section 5.280.</remarks>
    [Field(43, 45), Float(10)]
    public float Size { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='Limit']/*"/>
    [Field(46, 51)]
    public Altitude Up { get; set; }

    /// <inheritdoc cref="LimitUnit"/>
    [Character(52)]
    public LimitUnit UpUnit { get; set; }

    /// <summary>
    /// <c>Special Activity Area Volume</c> character.
    /// </summary>
    /// <remarks>See section 5.281.</remarks>
    [Character(53)]
    public char Volume { get; set; }

    /// <inheritdoc cref="OperatingTimes"/>
    [Field(54, 56)]
    public OperatingTimes Times { get; set; }

    /// <inheritdoc cref="Arinc424.Privacy"/>
    [Character(57)]
    public Privacy Privacy { get; set; }

    /// <summary>
    /// <c>Controlling Agency</c> field.
    /// </summary>
    /// <remarks>See section 5.140.</remarks>
    [Field(59, 83)]
    public string? ControllingAgency { get; set; }

    /// <inheritdoc cref="Arinc424.CommType"/>
    [Field(84, 86)]
    public CommType CommType { get; set; }

    /// <inheritdoc cref="Arinc424.Frequency"/>
    [Field(87, 93)]
    public Frequency Frequency { get; set; }

    /// <summary>
    /// <c>Restrictive Airspace Name</c> field.
    /// </summary>
    /// <remarks>See section 5.126.</remarks>
    [Field(94, 123)]
    public string? Name { get; set; }
}
