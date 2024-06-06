namespace Arinc424.Navigation;

using Terms;

#pragma warning disable CS8618

[DebuggerDisplay($"{{{nameof(Identifier)}}}")]
public abstract class Navaid : Geo, IIdentity, IIcao, INamed
{
    /// <include file='Comments.xml' path="doc/member[@name='Navaid']/*"/>
    [Field(14, 17), Primary]
    public string Identifier { get; set; }

    [Field(20, 21), Primary]
    public string IcaoCode { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='Frequency']/*"/>
    [Field(23, 27), Float(10)]
    public float Frequency { get; set; }

    /// <inheritdoc cref="NavaidType"/>
    [Field(28, 29), Decode<NondirectionalTypeConverter, NavaidType>]
    public NavaidType Type { get; set; }

    /// <inheritdoc cref="NavaidCoverage"/>
    [Character(30), Transform<NondirectionalCoverageConverter, NavaidCoverage>]
    public NavaidCoverage Coverage { get; set; }

    /// <inheritdoc cref="NavaidInfo"/>
    [Character(31)]
    public NavaidInfo Info { get; set; }

    /// <inheritdoc cref="NavaidCollocation"/>
    [Character(32)]
    public NavaidCollocation Collocation { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='Datum']/*"/>
    [Field(91, 93)]
    public string? Datum { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='Name']/*"/>
    [Field(94, 118), Field<NondirectionalBeacon>(94, 123)]
    public string? Name { get; set; }
}
