namespace Arinc424.Airspace;

using Terms;

/// <summary>
/// Space volume with low and up limits.
/// </summary>
public abstract class Volume : Record424<BoundaryPoint>
{
    /// <include file='Comments.xml' path="doc/member[@name='Limit']/*"/>
    [Field(82, 86), Decode<AltitudeConverter>]
    public Altitude Low { get; set; }

    /// <inheritdoc cref="LimitUnit"/>
    [Character(87), Transform<LimitUnitConverter>]
    public LimitUnit LowUnit { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='Limit']/*"/>>
    [Field(88, 92), Decode<AltitudeConverter>]
    public Altitude Up { get; set; }

    /// <inheritdoc cref="LimitUnit"/>s>
    [Character(93), Transform<LimitUnitConverter>]
    public LimitUnit UpUnit { get; set; }
}
