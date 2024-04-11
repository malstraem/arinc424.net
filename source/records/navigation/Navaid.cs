using System.Diagnostics;

using Arinc424.Attributes;
using Arinc424.Converters;

namespace Arinc424.Navigation;

#pragma warning disable CS8618

[DebuggerDisplay($"{{{nameof(Identifier)}}}")]
public abstract class Navaid : Geo, IIcao, IIdentity
{
    /// <include file='Comments.xml' path="doc/member[@name='AidIdentifier']/*"/>
    [Field(14, 17), Primary]
    public string Identifier { get; set; }

    [Field(20, 21), Primary]
    public string IcaoCode { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='Frequency']/*"/>
    [Field(23, 27), Decode<TenthsConverter>]
    public float Frequency { get; set; }

    /// <inheritdoc cref="Terms.NavaidType"/>
    [Field(28, 29), Decode<NondirectionalTypeConverter>]
    public Terms.NavaidType Type { get; set; }

    /// <inheritdoc cref="Terms.NavaidCoverage"/>
    [Character(30), Transform<NondirectionalCoverageConverter>]
    public Terms.NavaidCoverage Coverage { get; set; }

    /// <inheritdoc cref="Terms.NavaidInfo"/>
    [Character(31), Transform<NavaidInfoConverter>]
    public Terms.NavaidInfo Info { get; set; }

    /// <inheritdoc cref="Terms.NavaidCollocation"/>
    [Character(32), Transform<NavaidCollocationConverter>]
    public Terms.NavaidCollocation Collocation { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='Datum']/*"/>
    [Field(91, 93)]
    public string? Datum { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='Name']/*"/>
    [Field(94, 118), Field<NondirectionalBeacon>(94, 123)]
    public string? Name { get; set; }
}
