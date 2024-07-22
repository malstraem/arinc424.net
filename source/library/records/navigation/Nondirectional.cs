namespace Arinc424.Navigation;

using Terms;

/// <summary>
/// <c>NDB Navaid</c> primary record.
/// </summary>
/// <remarks>See section 4.1.3.1.</remarks>
[Section('D', 'B'), Continuous]
public class Nondirectional : Navaid
{
    /// <inheritdoc cref="NondirectType"/>
    [Field(28, 29)]
    public NondirectType Type { get; set; }

    /// <inheritdoc cref="NondirectCoverage"/>
    [Character(30)]
    public NondirectCoverage Coverage { get; set; }

    /// <inheritdoc cref="NondirectInfo"/>
    [Character(31)]
    public NondirectInfo Info { get; set; }

    /// <inheritdoc cref="NondirectCollocation"/>
    [Character(32)]
    public NondirectCollocation Collocation { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='MagneticVariation']/*"/>
    [Field(75, 79), Variation]
    public float Variation { get; set; }
}
