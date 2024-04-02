using Arinc424.Attributes;
using Arinc424.Converters;

namespace Arinc424.Airspace;

/// <summary>
/// Space volume with low and up limits.
/// </summary>
public abstract class Volume : Record424<BoundaryPoint>
{
    /// <include file='Comments.xml' path="doc/member[@name='Limit']/*"/>
    [Field(82, 86), Decode<AltitudeConverter>]
    public (int Altitude, AltitudeUnit Unit) Low { get; set; }

    /// <inheritdoc cref="LimitUnit"/>
    [Character(87), Transform<LimitUnitConverter>]
    public Terms.LimitUnit LowUnit { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='Limit']/*"/>>
    [Field(88, 92), Decode<AltitudeConverter>]
    public (int Altitude, AltitudeUnit Unit) Up { get; set; }

    /// <inheritdoc cref="LimitUnit"/>s>
    [Character(93), Transform<LimitUnitConverter>]
    public Terms.LimitUnit UpUnit { get; set; }
}
