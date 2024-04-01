using Arinc.Spec424.Attributes;
using Arinc.Spec424.Converters;
using Arinc.Spec424.Terms;

namespace Arinc.Spec424.Records;

public abstract class Volume : Record424<BoundaryPoint>
{
    /// <include file='Comments.xml' path="doc/member[@name='Limit']/*"/>
    [Field(82, 86), Decode<AltitudeConverter>]
    public (int Altitude, AltitudeUnit Unit) Low { get; set; }

    /// <inheritdoc cref="LimitUnit"/>
    [Character(87), Transform<LimitUnitConverter>]
    public LimitUnit LowUnit { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='Limit']/*"/>>
    [Field(88, 92), Decode<AltitudeConverter>]
    public (int Altitude, AltitudeUnit Unit) Up { get; set; }

    /// <inheritdoc cref="LimitUnit"/>s>
    [Character(93), Transform<LimitUnitConverter>]
    public LimitUnit UpUnit { get; set; }
}
