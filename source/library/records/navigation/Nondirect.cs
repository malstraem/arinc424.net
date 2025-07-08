namespace Arinc424.Navigation;

/**<summary>
<c>NDB Navaid</c> primary record.
</summary>
<remarks>See section 4.1.3.1.</remarks>*/
[Section('D', 'B'), Icao(20, 21)]
public class Nondirect : Navaid
{
    /// <inheritdoc cref="Terms.NondirectType"/>
    [Field(28, 29)]
    public Terms.NondirectType Type { get; set; }

    /// <inheritdoc cref="Terms.NondirectCoverage"/>
    [Character(30)]
    public Terms.NondirectCoverage Coverage { get; set; }

    /// <inheritdoc cref="Terms.NondirectInfo"/>
    [Character(31)]
    public Terms.NondirectInfo Info { get; set; }

    /// <inheritdoc cref="Terms.NondirectCollocation"/>
    [Character(32)]
    public Terms.NondirectCollocation Collocation { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='MagneticVariation']/*"/>
    [Field(75, 79), Variation]
    public float Variation { get; set; }
}
