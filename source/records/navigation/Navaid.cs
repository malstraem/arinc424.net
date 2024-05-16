namespace Arinc424.Navigation;

using Terms;

#pragma warning disable CS8618

[DebuggerDisplay($"{{{nameof(Identifier)}}}")]
public abstract class Navaid : Geo, IIcao, IIdentity, INamed
{
    /// <include file='Comments.xml' path="doc/member[@name='Navaid']/*"/>
    [Field(14, 17), Primary]
    public string Identifier { get; set; }

    [Field(20, 21), Primary]
    public string IcaoCode { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='Frequency']/*"/>
    [Field(23, 27), Decode<TenthsConverter>]
    public float Frequency { get; set; }

    /// <inheritdoc cref="NavaidType"/>
    [Obsolete("todo type target converter")]
    [Field(28, 29), Decode<NondirectionalTypeConverter>]
    public NavaidType Type { get; set; }

    /// <inheritdoc cref="NavaidCoverage"/>
    [Obsolete("todo type target converter")]
    [Character(30), Transform<NondirectionalCoverageConverter>]
    public NavaidCoverage Coverage { get; set; }

    /// <inheritdoc cref="NavaidInfo"/>
    [Character(31), Transform<NavaidInfoConverter>]
    public NavaidInfo Info { get; set; }

    /// <inheritdoc cref="NavaidCollocation"/>
    [Character(32), Transform<NavaidCollocationConverter>]
    public NavaidCollocation Collocation { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='Datum']/*"/>
    [Field(91, 93)]
    public string? Datum { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='Name']/*"/>
    [Field(94, 118), Field<NondirectionalBeacon>(94, 123)]
    public string? Name { get; set; }
}
