namespace Arinc424.Airspace;

/// <summary>
/// Space volume with low and up limits.
/// </summary>
[Icao(7, 8)]
public abstract class Volume : Record424<BoundaryPoint>, INamed, IMultiple
{
    [Character(20)]
    public char Multiplier { get; set; }

    /// <inheritdoc cref="Arinc424.LevelType"/>
    [Character(26)]
    public LevelType LevelType { get; set; }

    /// <inheritdoc cref="Arinc424.TimeCode"/>
    [Character(27)]
    public TimeCode TimeCode { get; set; }

    /// <summary>
    /// <c>NOTAM</c> character.
    /// </summary>
    /// <remarks>See section 5.132.</remarks>
    [Character(28)]
    public char Notam { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='Limit']/*"/>
    [Field(82, 86)]
    public Altitude Low { get; set; }

    /// <inheritdoc cref="LimitUnit"/>
    [Character(87)]
    public LimitUnit LowUnit { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='Limit']/*"/>>
    [Field(88, 92)]
    public Altitude Up { get; set; }

    /// <inheritdoc cref="LimitUnit"/>s>
    [Character(93)]
    public LimitUnit UpUnit { get; set; }

    /// <summary>
    /// <c>Controlled Airspace Name (ARSP NAME)</c> for <see cref="ControlledVolume"/> or
    /// <c>Restrictive Airspace Name</c> for <see cref="RestrictiveVolume"/> field.
    /// </summary>
    /// <remarks>See section 5.216 and 5.126.</remarks>
    [Field(94, 123)]
    public string? Name { get; set; }
}
