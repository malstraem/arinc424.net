namespace Arinc424.Navigation;

/// <summary>
/// <c>NDB Navaid</c> primary record.
/// </summary>
/// <remarks>See section 4.1.3.1.</remarks>
[Section('D', 'B'), Continuous]
public class NondirectionalBeacon : Navaid
{
    /// <include file='Comments.xml' path="doc/member[@name='MagneticVariation']/*"/>
    [Field(75, 79), Decode<MagneticVariationConverter>]
    public float Variation { get; set; }
}
